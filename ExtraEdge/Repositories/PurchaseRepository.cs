using ExtraEdge.Data;
using ExtraEdge.Models;

namespace ExtraEdge.Repositories
{
    public class PurchaseRepository : IPurchaseRepository
    {
        private readonly ApplicationDbContext db;

        public PurchaseRepository(ApplicationDbContext db)
        {
            this.db = db;
        }

        public int AddPurchase(Purchase purchase)
        {
            db.purchases.Add(purchase);
            int res = db.SaveChanges();
            return res;
        }

        public int DeletePurchase(int id)
        {
            int res = 0;
            var emp = db.purchases.Find(id);
            if (emp != null)
            {
                db.purchases.Remove(emp);
                res = db.SaveChanges();
            }
            return res;
        }

        public Purchase GetPurchasebyId(int id)
        {
            var emp = db.purchases.Find(id);
            return emp;
        }

        public IEnumerable<Purchase> GetPurchases()
        {
            return db.purchases.ToList();
        }

        public int UpdatePurchase(Purchase purchase)
        {
            int res = 0;
            var p = db.purchases.Where(x => x.PurchaseId == purchase.PurchaseId).FirstOrDefault();
            if (p != null)
            {
                db.purchases.Update(purchase);
                res = db.SaveChanges();
            }
            return res;
        }
    }
}
