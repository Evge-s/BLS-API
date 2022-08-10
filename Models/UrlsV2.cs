namespace BLS_API.Models
{
    public class UrlsV2
    {
        public string MultipleSeriesJson { get; } = "https://api.bls.gov/publicAPI/v2/timeseries/data/";
        public string MultipleSeriesExcel { get; } = "https://api.bls.gov/publicAPI/v2/timeseries/data.xlsx";
        public string OptionalParametersSeriesJson { get; } = "https://api.bls.gov/publicAPI/v2/timeseries/data/";
        public string OptionalParametersSeriesExcel { get; } = "https://api.bls.gov/publicAPI/v2/timeseries/data/.xlsx";
        public string LatestSeriesDataJson { get; } = "https://api.bls.gov/publicAPI/v2/timeseries/data/";
        public string PopularSeriesJson { get; } = "https://api.bls.gov/publicAPI/v2/timeseries/popular";
        public string AllSurveys { get; } = "https://api.bls.gov/publicAPI/v2/surveys";
        public string SingleSurveyJson { get; } = "https://api.bls.gov/publicAPI/v2/surveys/";
    }
}
