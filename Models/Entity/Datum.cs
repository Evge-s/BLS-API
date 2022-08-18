using System.Collections.Generic;

namespace BLS_API.Models.Entity
{
    public class Datum
    {
        public string? Year { get; set; }
        public string? Period { get; set; }
        public string? PeriodName { get; set; }
        public string? Latest { get; set; }
        public string? Value { get; set; }
        public List<Aspect>? Aspects { get; set; }
        public List<Footnote>? Footnotes { get; set; }
        public Calculation? Calculations { get; set; }
    }
}
