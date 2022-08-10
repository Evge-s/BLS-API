using System;

namespace BLS_API.Models.Dto.Request
{
    public class BlsUserRequest
    {
        public string Email { get; set; }

        public string RegisterTokenKey { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime UpdateDate { get; set; }
    }
}
