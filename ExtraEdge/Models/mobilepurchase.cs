using System.ComponentModel.DataAnnotations;

namespace ExtraEdge.Models
{
    public class mobilepurchase
    {
        public int CustomerId { get; set; }
        public  DateTime PurchaseDate { get; set; }
        public int PurchasePrice { get; set; }
       
        public int Discount { get; set; }
       
        public int FinalPrice { get; set; }

        public int Price { get; set; }
    }
}
