using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace MVCwithWebAPI.Models
{
    public interface ICustomerRepository
    {
        Task Add(Customer customer);
        Task Update(Customer customer);
        Task Delete(string id);
        Task<Customer> GetCustomer(string id);
        Task<IEnumerable<Customer>> GetCustomers();
    }
}