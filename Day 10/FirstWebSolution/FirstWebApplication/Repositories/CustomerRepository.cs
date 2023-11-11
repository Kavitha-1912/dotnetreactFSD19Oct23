using FirstWebApplication.Contexts;
using FirstWebApplication.Interfaces;
using FirstWebApplication.Models;

namespace FirstWebApplication.Repositories
{
    public class CustomerRepository : IRepository<string, Customer>
    {
        private readonly ShoppingContext _context;

        public CustomerRepository(ShoppingContext context)
        {
            _context = context;
        }
        public Customer Add(Customer item)
        {
            _context.Customers.Add(item);
            _context.SaveChanges();
            return item;
        }

        public Customer Delete(string key)
        {
            var customer = Get(key);
            _context.Customers.Remove(customer);
            _context.SaveChanges();
            return customer;
        }

        public Customer Get(string key)
        {
            var customer = _context.Customers.SingleOrDefault();
            return customer;
        }

        public IList<Customer> GetAll()
        {
            var customer = _context.Customers.ToList();
            return customer;
        }

        public Customer Update(Customer item)
        {
            var customer = Get(item.Email);
            if (customer != null)
            {
                _context.Entry<Customer>(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
                return customer;
            }
            return null;
        }
    }
}
