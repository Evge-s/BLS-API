using System.Collections.Generic;

namespace BLS_API.Models.Entity
{
    public class Aspect
    {
        public string? Name { get; set; }
        public string? Value { get; set; }
        public List<Footnote>? Footnotes { get; set; }
    }
}
