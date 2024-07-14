using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Data.Entity;
namespace MVCwithWebAPI.Models
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly SqlDbContext db = new SqlDbContext();
        public async Task Add(Employee employee)
        {
            employee.Id = Guid.NewGuid().ToString();
            db.Employee.Add(employee);
          
            try
            {
                await db.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task<Employee> GetEmployee(string id)
        {
            try
            {
                Employee employee = await db.Employee.FindAsync(id);               

                if (employee == null)
                {
                    return null;
                }
               
                return employee;
            }
            catch
            {
                throw;
            }
        }


        //public async Task<EmployeeDetailDTO> GetEmployeeDTO(string id)
        //{
        //    try
        //    {

        //        //var student = await db.Employee
        //        // .Include(s => s.Contacts)                    
        //        // .AsNoTracking()
        //        // .FirstOrDefaultAsync(m => m.Id == id);


        //        EmployeeDetailDTO employees = await db.Employee.Include(s => s.Contacts).Select(
        //        b => new EmployeeDetailDTO()
        //        {
        //            EmployeeID = b.Id,
        //            FristName = b.Name,
        //            LastName = b.Name,
        //            ContactType = b.Name,
        //            ContactInfo = b.Name,


        //        }).SingleOrDefaultAsync(c => c.EmployeeID == id);
        //        if (employees == null)
        //        {
        //            return null;
        //        }
        //        return employees;
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //}


        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            try
            {
                var employees = await db.Employee.ToListAsync();
                return employees.AsQueryable();
            }
            catch
            {
                throw;
            }
        }
        public async Task Update(Employee employee)
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

        private bool EmployeeExists(string id)
        {
            return db.Employee.Count(e => e.Id == id) > 0;
        }
    }
}