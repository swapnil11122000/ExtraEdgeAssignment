using ExtraEdge.Models;
namespace ExtraEdge.Services
{
    public interface IPurchaseService
    {
        IEnumerable<Purchase> GetPurchases();
        Purchase GetPurchasebyId(int id);
        int AddPurchase(Purchase purchase);
        int UpdatePurchase(Purchase purchase);
        int DeletePurchase(int id);


    }
}
