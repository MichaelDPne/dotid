using Microsoft.EntityFrameworkCore;

namespace dotidapi.Models
{
    [Keyless]
    public class AgeDifferenceModel
    {
        public int Year { get; set; }
        public string Age { get; set; }

        public int Population { get; set; }
    }
}
