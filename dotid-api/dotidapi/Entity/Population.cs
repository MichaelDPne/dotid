using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dotidapi.Entity
{
    [Table("FactPopulation")]
    public class PopulationEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Age { get; set; } = string.Empty;

        public int Region {  get; set; }

        public int Sex { get; set; }

        public int State { get; set; }

        public int Year {  get; set; }

        public int Population { get; set; }
    }
}
