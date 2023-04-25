using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExtraEdge.Models
{
    [Table("Mobile")]
    public class Mobile
    {
        [Key]
        public int MobileId { get; set; }
        [Required]
        public int BrandId { get; set; }
        [Required]
        public string Model { get; set; }
        [Required]

        public string Description { get; set; }
        [Required]
        public int Price { get; set; }
    }
}
