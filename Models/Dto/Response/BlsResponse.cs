using BLS_API.Models.Entity;
using System.Collections.Generic;

namespace BLS_API.Models.Dto.Response
{
    public class BlsResponse
    {
        public string? Status { get; set; }
        public int ResponseTime { get; set; }
        public List<object>? Message { get; set; }
        public List<Result>? Results { get; set; }
    }
}
