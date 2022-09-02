using BLS_API.Models;
using BLS_API.Models.Dto.Request;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text.Json;
using System.Text;
using BLS_API.Models.Entity;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace BLS_API.Services
{
    public class BlsService : IBlsService
    {
        private readonly HttpClient _httpClient;
        private readonly UrlsV2 _urlV2;
        public BlsService()
        {
            _urlV2 = new UrlsV2();
            _httpClient = new HttpClient();
        }

        public async Task<BlsServiceResponse<string>> MultipleSeries(MultipleRequest request)
        {
            var result = await SendRequest(request, _urlV2.MultipleSeriesJson);
            string savingResult = SaveBlsResponseData(result);
            return await GetBlsServiceResponse(result, savingResult);
        }

        public async Task<BlsServiceResponse<string>> OptionalParametersSeries(OptionalParametersRequest request)
        {
            var result = await SendRequest(request, _urlV2.OptionalParametersSeriesJson);
            string savingResult = SaveBlsResponseData(result);
            return await GetBlsServiceResponse(result, savingResult);
        }

        public async Task<BlsServiceResponse<string>> LatestSeriesData(LatestSeriesDataRequest request)
        {
            string uri = $"{_urlV2.LatestSeriesDataJson}{request.SeriesId}?latest=true";
            var result = await SendRequest(null, uri);
            return await GetBlsServiceResponse(result);
        }

        public async Task<BlsServiceResponse<string>> PopularSeriesData(PopularSeriesRequest request)
        {
            if (!string.IsNullOrEmpty(request.Survey))
            {
                var surveyResult = await SendRequest(null, $"{_urlV2.PopularSeriesJson}?survey={request.Survey}");
                return await GetBlsServiceResponse(surveyResult);
            }
            var result = await SendRequest(null, _urlV2.PopularSeriesJson);
            return await GetBlsServiceResponse(result);
        }

        public async Task<BlsServiceResponse<string>> AllSurveysData()
        {
            var result = await SendRequest(null, _urlV2.AllSurveys);
            return await GetBlsServiceResponse(result);
        }

        public async Task<BlsServiceResponse<string>> SingleSurveyData(SingleSurveyRequest request)
        {
            var result = await SendRequest(request, _urlV2.SingleSurveyJson);
            return await GetBlsServiceResponse(result);
        }

        private async Task<string> SendRequest(object? request, string url)
        {
            var blsRequest = new HttpRequestMessage(HttpMethod.Post, url);
            var response = string.Empty;

            if (request != null)
            {
                var payload = JsonSerializer.Serialize(request);
                blsRequest.Content = new StringContent(payload, Encoding.UTF8, "application/json");
                response = _httpClient.PostAsync(blsRequest.RequestUri, blsRequest.Content).Result.Content.ReadAsStringAsync().Result;
            }
            else
            {
                response = _httpClient.GetAsync(blsRequest.RequestUri).Result.Content.ReadAsStringAsync().Result;
            }

            return response;
        }

        // Deserialize by using Generic System Text Json
        private Result? DeserializeBlsResponse(string json)
        {
            var blsResponse = JsonSerializer.Deserialize<Result>(json, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

            return blsResponse;
        }

        private async Task<BlsServiceResponse<string>> GetBlsServiceResponse(string response, string savingResult = null)
        {
            JObject responseObj = JObject.Parse(response);

            return new BlsServiceResponse<string>
            {
                Status = responseObj.Property("status").Value.ToString(),
                Message = responseObj.Property("message").Value.ToString(),
                Data = savingResult
            };
        }

        private string SaveBlsResponseData(string response)
        {
            JObject responseObj = JObject.Parse(response);
            var result = DeserializeBlsResponse(responseObj.SelectToken("Results").ToString());
            var test = SplitSeries(result.Series);

            // there should be a save functionality

            if (test != null && test.Count > 0)
                return "Successfully saved";
            return "Failed to save";
        }

        private Dictionary<string, List<string>> SplitSeries(List<Series> series)
        {
            Dictionary<string, List<string>> result = new Dictionary<string, List<string>>();

            foreach (var serie in series)
            {
                if (serie.Catalog != null)
                {
                    string catalog = JsonSerializer.Serialize(serie.Catalog);
                    result.Add(serie.SeriesId, new List<string> { catalog });
                }
                if (serie.Data != null)
                {
                    foreach (var itemData in serie.Data)
                    {
                        string data = JsonSerializer.Serialize(itemData);
                        result[serie.SeriesId].Add(data);
                    }
                }
            }

            return result;
        }
    }
}
