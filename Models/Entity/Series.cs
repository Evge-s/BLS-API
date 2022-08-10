using System.Collections.Generic;

namespace BLS_API.Models.Entity
{
    public class Series
    {
        public string? SeriesId { get; set; }
        public Catalog? Catalog { get; set; }
        public List<Datum>? Data { get; set; }
    }
}
