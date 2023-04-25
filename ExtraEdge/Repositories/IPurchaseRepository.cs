using ExtraEdge.Models;

namespace ExtraEdge.Repositories
{
    public interface IPurchaseRepository
    {
        IEnumerable<Purchase> GetPurchases();
        Purchase GetPurchasebyId(int id);
        int AddPurchase(Purchase purchase);
        int UpdatePurchase(Purchase purchase);
        int DeletePurchase(int id);
    }
}
