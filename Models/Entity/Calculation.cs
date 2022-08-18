using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BLS_API.Models.Entity
{
    public class Calculation
    {
        [JsonPropertyName("net_changes")]
        public Dictionary<string, string>? Net_changes { get; set; }

        [JsonPropertyName("pct_changes")]
        public Dictionary<string, string>? Pct_changes { get; set; }
    }
}
