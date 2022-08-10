using System.Text.Json.Serialization;

namespace BLS_API.Models.Dto.Request
{
    public class PopularSeriesReqest
    {
        [JsonPropertyName("survey")]
        public string? Survey { get; set; }
    }
}
