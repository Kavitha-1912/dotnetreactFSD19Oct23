using FirstWebApplication.Interfaces;
using FirstWebApplication.Models;
using FirstWebApplication.Repositories;

namespace FirstWebApplication.Services
{
    public class CustomerService : ICustomerService
    {
        IRepository<string, Customer> repository;
        public CustomerService(IRepository<string, Customer> repo)
        {
            repository = repo;
        }

        //public Customer Login(string email, string password)
        //{
        //    var result = GetCustomers(email);
        //    if (result != null)
        //    {
        //        if (result.ComparePassword(password))
        //        {
        //            return result;
        //        }
        //    }
        //    throw new Exception();
        //}
        public Customer GetCustomers(string email)
        {
            var result = repository.Get(email);
            return result == null ? throw new Exception() : result;
        }

        public List<Customer> GetCustomers()
        {
            var customers = repository.GetAll();
            if (customers.Count != 0)
                return customers.ToList();
            throw new Exception();
        }

        public Customer Register(Customer customer)
        {
            var result = repository.Add(customer);
            if (result != null)
                return result;
            throw new Exception();
        }
    }
}
