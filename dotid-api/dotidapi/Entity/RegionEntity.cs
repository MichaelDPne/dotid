using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dotidapi.Entity
{
    [Table("DimRegion")]
    public class RegionEntity
    {
        [Key]
        public int Id { get; set; } = 0;

        public string Name { get; set; }
    }
}