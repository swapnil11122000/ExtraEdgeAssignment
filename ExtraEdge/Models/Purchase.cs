using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExtraEdge.Models
{

    [Table("Purchase")]
    public class Purchase
    {
        [Key]
        public int PurchaseId { get; set; }
        [Required]
        public int CustomerId { get; set; }
        [Required]
        public int MobileId  { get; set; }
        [Required]
        public string  PurchaseDate { get; set; }
        [Required]
        public int PurchasePrice { get; set; }
        [Required]
        public int Discount { get; set; }
        [Required]
        public int FinalPrice { get; set; }
    }
}
