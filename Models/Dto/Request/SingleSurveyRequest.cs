using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BLS_API.Models.Dto.Request
{
    public class SingleSurveyRequest
    {
        [Required]
        [JsonPropertyName("surveyAbbreviation")]
        public string SurveyAbbreviation { get; set; }
    }
}