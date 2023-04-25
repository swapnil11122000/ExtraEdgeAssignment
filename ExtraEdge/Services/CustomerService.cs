using ExtraEdge.Models;
using ExtraEdge.Repositories;

namespace ExtraEdge.Services
{
    public class CustomerService:ICustomerService
    {
        private readonly ICustomerRepository repo;

        public CustomerService(ICustomerRepository repo)
        {
            this.repo = repo;
        }

        public int AddCustomer(Customer customer)
        {
            return repo.AddCustomer(customer);
        }

        public int DeleteCustomer(int id)
        {
            return repo.DeleteCustomer(id);
        }

        public Customer GetCustomerbyId(int id)
        {
            return repo.GetCustomerbyId(id);
        }

        public IEnumerable<Customer> GetCustomers()
        {
            return repo.GetCustomers();
        }

        public int UpdateCustomer(Customer customer)
        {
            return repo.UpdateCustomer(customer);
        }
    }
}
