using BLS_API.Models;
using BLS_API.Models.Dto.Request;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text.Json;
using System.Text;
using BLS_API.Models.Entity;
using Newtonsoft.Json.Linq;

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

        public async Task<BlsServiceResponse<string>> MultipleSeries(MultipleReqest request)
        {
            return await SendRequest(request, _urlV2.MultipleSeriesJson);
        }

        public async Task<BlsServiceResponse<string>> OptionalParametersSeries(OptionalParametersReqest request)
        {
            return await SendRequest(request, _urlV2.OptionalParametersSeriesJson);
        }

        public async Task<BlsServiceResponse<string>> LatestSeriesData(LatestSeriesDataReqest request)
        {
            string uri = $"{_urlV2.LatestSeriesDataJson}{request.SeriesId}?latest=true";
            return await SendRequest(null, uri);
        }

        public async Task<BlsServiceResponse<string>> PopularSeriesData(PopularSeriesReqest request)
        {
            if (!string.IsNullOrEmpty(request.Survey))
                return await SendRequest(null, $"{_urlV2.PopularSeriesJson}?survey={request.Survey}");
            return await SendRequest(null, _urlV2.PopularSeriesJson);
        }

        public async Task<BlsServiceResponse<string>> AllSurveysData()
        {
            return await SendRequest(null, _urlV2.AllSurveys);
        }

        public async Task<BlsServiceResponse<string>> SingleSurveyData(SingleSurveyReqest request)
        {
            return await SendRequest(request, _urlV2.SingleSurveyJson);
        }

        private async Task<BlsServiceResponse<string>> SendRequest(object? request, string url)
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

            JObject responseObj = JObject.Parse(response);
            var res = DeserializeBlsResponse(responseObj.SelectToken("Results").ToString());

            return new BlsServiceResponse<string>
            {
                Status = responseObj.Property("status").Value.ToString(),
                Message = responseObj.Property("message").Value.ToString(),
            };
        }

        // Deserialize by using Generic System Text Json
        private Result? DeserializeBlsResponse(string json)
        {
            var blsResponse = JsonSerializer.Deserialize<Result>(json, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

            return blsResponse;
        }
    }
}
