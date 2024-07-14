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
    public class EmployeesApiController : ApiController
    {
        private readonly IEmployeeRepository _iEmployeeRepository = new EmployeeRepository();

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/Employees/Get")]
        public async Task<IEnumerable<Employee>> Get()
        {
            return await _iEmployeeRepository.GetEmployees();
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/Employees/Create")]
        public async Task CreateAsync([FromBody]Employee employee)
        {
            if (ModelState.IsValid)
            {
                await _iEmployeeRepository.Add(employee);
            }
        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/Employees/Details/{id}")]
        public async Task<Employee> Details(string id)
        {
            var result = await _iEmployeeRepository.GetEmployee(id);
            return result;
        }

        [System.Web.Http.HttpPut]
        [System.Web.Http.Route("api/Employees/Edit")]
        public async Task EditAsync([FromBody]Employee employee)
        {
            if (ModelState.IsValid)
            {
                await _iEmployeeRepository.Update(employee);
            }
        }

        [System.Web.Http.HttpDelete]
        [System.Web.Http.Route("api/Employees/Delete/{id}")]
        public async Task DeleteConfirmedAsync(string id)
        {
            await _iEmployeeRepository.Delete(id);
        }
    }
}