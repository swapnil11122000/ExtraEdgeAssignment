using ExtraEdge.Models;
using ExtraEdge.Repositories;

namespace ExtraEdge.Services
{
    public class PurchaseService:IPurchaseService
    {
        private readonly IPurchaseRepository repo;

        public PurchaseService(IPurchaseRepository repo)
        {
            this.repo = repo;
        }

        public int AddPurchase(Purchase purchase)
        {
            return repo.AddPurchase(purchase);
        }

        public int DeletePurchase(int id)
        {
            return repo.DeletePurchase(id);
        }

        public Purchase GetPurchasebyId(int id)
        {
            return repo.GetPurchasebyId(id);
        }

        public IEnumerable<Purchase> GetPurchases()
        {
            return repo.GetPurchases();
        }

        public int UpdatePurchase(Purchase purchase)
        {
            return repo.UpdatePurchase(purchase);
        }
    }
}
