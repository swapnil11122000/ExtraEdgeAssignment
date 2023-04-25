using ExtraEdge.Data;
using ExtraEdge.Models;

namespace ExtraEdge.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ApplicationDbContext db;
        public CustomerRepository(ApplicationDbContext db)
        {
            this.db = db;
        }
        public int AddCustomer(Customer customer)
        {
            db.customers.Add(customer);
            int res=db.SaveChanges();
            return res;
        }

        public int DeleteCustomer(int id)
        {
            int res = 0;
            var emp = db.customers.Find(id);
            if (emp != null)
            {
                db.customers.Remove(emp);
                res = db.SaveChanges();
            }
            return res;
        }

        public Customer GetCustomerbyId(int id)
        {
            var emp = db.customers.Find(id);
            return emp;
        }

        public IEnumerable<Customer> GetCustomers()
        {
            return db.customers.ToList();
        }

        public int UpdateCustomer(Customer customer)
        {
            int res = 0;
            var e = db.customers.Where(x => x.CustomerId == customer.CustomerId).FirstOrDefault();
            if (e != null)
            {
                e.Name= customer.Name;
                e.Email= customer.Email;
                e.Phone= customer.Phone;
                e.Address= customer.Address;
                res = db.SaveChanges();
            }
            return res;
        }
    }
}
