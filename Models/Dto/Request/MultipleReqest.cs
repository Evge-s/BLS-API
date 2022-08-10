using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BLS_API.Models.Dto.Request
{
    public class MultipleReqest
    {
        [JsonPropertyName("seriesid")]
        public List<string> SeriesId { get; set; }

        [JsonPropertyName("startyear")]
        public string StartYear { get; set; } = string.Empty;

        [JsonPropertyName("endyear")]
        public string EndYear { get; set; } = string.Empty;

        [JsonPropertyName("catalog")]
        public bool Catalog { get; set; } = false;

        [JsonPropertyName("calculations")]
        public bool Calculations { get; set; } = false;

        [JsonPropertyName("annualaverage")]
        public bool Annualaverage { get; set; } = false;

        [JsonPropertyName("registrationKey")]
        public string RegistrationKey { get; set; } = string.Empty;
    }
}
