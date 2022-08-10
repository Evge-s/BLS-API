using System.Text.Json.Serialization;

namespace BLS_API.Models.Dto.Request
{
    public class LatestSeriesDataReqest
    {
        [JsonPropertyName("seriesid")]
        public string SeriesId { get; set; }
    }
}
