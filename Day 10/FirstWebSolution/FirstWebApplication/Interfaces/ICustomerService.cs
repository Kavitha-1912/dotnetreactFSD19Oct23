using FirstWebApplication.Models;

namespace FirstWebApplication.Interfaces
{
    public interface ICustomerService
    {
        public Customer Register(Customer customer);
        //public Customer Login(string email, string password);
        public List<Customer> GetCustomers();
    }
}
