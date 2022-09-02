using System.Text.Json.Serialization;

namespace BLS_API.Models.Dto.Request
{
    public class PopularSeriesRequest
    {
        [JsonPropertyName("survey")]
        public string? Survey { get; set; }
    }
}
