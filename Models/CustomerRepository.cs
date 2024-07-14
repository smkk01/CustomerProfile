using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Data.Entity;

namespace MVCwithWebAPI.Models
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly SqlDbContext db = new SqlDbContext();
        public async Task Add(Customer customer)
        {
            customer.Id = Guid.NewGuid().ToString();
            db.Customer.Add(customer);

            try
            {
                await db.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }
        public async Task<Customer> GetCustomer(string id)
        {
            try
            {
                Customer customer = await db.Customer.FindAsync(id);

                if (customer == null)
                {
                    return null;
                }

                return customer;
            }
            catch
            {
                throw;
            }
        }                   
        public async Task<IEnumerable<Customer>> GetCustomers()
        {
            try
            {
                var customers = await db.Customer.ToListAsync();
                return customers.AsQueryable();
            }
            catch
            {
                throw;
            }
        }
        public async Task Update(Customer employee)
        {
            try
            {
                db.Entry(employee).State = EntityState.Modified;
                await db.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }
        public async Task Delete(string id)
        {
            try
            {
                Employee employee = await db.Employee.FindAsync(id);
                db.Employee.Remove(employee);
                await db.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }
        private bool CustomerExists(string id)
        {
            return db.Customer.Count(e => e.Id == id) > 0;
        }
    }
}