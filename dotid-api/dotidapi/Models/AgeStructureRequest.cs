using Microsoft.AspNetCore.Mvc;

namespace dotidapi.Models
{
    public class AgeStructureRequest
    {
        [FromRoute(Name = "code")]
        public int Code { get; set; }
        [FromRoute(Name = "sex")]
        public int Sex { get; set; }
    }

    public class AgeStructureDiffRequest
    {
        [FromRoute(Name = "code")]
        public int Code { get; set; }
        [FromRoute(Name = "sex")]
        public int Sex { get; set; }
        [FromRoute(Name = "year1")]
        public int Year1 { get; set; }
        [FromRoute(Name = "year2")]
        public int Year2 { get; set; }


    }
}
