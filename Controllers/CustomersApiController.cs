using MVCwithWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;


namespace MVCwithWebAPI.Controllers
{
    public class CustomersApiController : ApiController
    {
        private readonly ICustomerRepository _iCustomerRepository = new CustomerRepository();

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/customers/Get")]
        public async Task<IEnumerable<Customer>> Get()
        {
            return await _iCustomerRepository.GetCustomers();
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/customers/Create")]
        public async Task CreateAsync([FromBody]Customer customer)
        {
            if (ModelState.IsValid)
            {
                await _iCustomerRepository.Add(customer);
            }
        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/Customers/Details/{id}")]
        public async Task<Customer> Details(string id)
        {
            var result = await _iCustomerRepository.GetCustomer(id);
            return result;
        }

        [System.Web.Http.HttpPut]
        [System.Web.Http.Route("api/Customers/Edit")]
        public async Task EditAsync([FromBody]Customer customer)
        {
            if (ModelState.IsValid)
            {
                await _iCustomerRepository.Update(customer);
            }
        }

        [System.Web.Http.HttpDelete]
        [System.Web.Http.Route("api/Customers/Delete/{id}")]
        public async Task DeleteConfirmedAsync(string id)
        {
            await _iCustomerRepository.Delete(id);
        }
    }
}