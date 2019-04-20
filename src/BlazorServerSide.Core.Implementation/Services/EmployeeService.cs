using BlazorServerSide.Core.Data;
using BlazorServerSide.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorServerSide.Core.Implementation.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly BlazorServerSideContext _context;
        public EmployeeService(BlazorServerSideContext context)
        {
            _context = context;
        }

        //To Get all employees details     
        public async Task<Employee[]> GetAllEmployees()
        {
            try
            {
                return await Task.FromResult(_context.Employee.AsNoTracking().ToArray());
            }
            catch
            {
                throw;
            }
        }
        //To Add new employee record       
        public void AddEmployee(Employee employee)
        {
            try
            {
                _context.Employee.Add(employee);
                _context.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
        //To Update the records of a particluar employee      
        public void UpdateEmployee(Employee employee)
        {
            try
            {
                _context.Entry(employee).State = EntityState.Modified;
                _context.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
        //Get the details of a particular employee      
        public Employee GetEmployee(int id)
        {
            try
            {
                var employee = _context.Employee.Find(id);
                _context.Entry(employee).State = EntityState.Detached;
                return employee;
            }
            catch
            {
                throw;
            }
        }
        //To Delete the record of a particular employee      
        public void DeleteEmployee(int id)
        {
            try
            {
                Employee emp = _context.Employee.Find(id);
                _context.Employee.Remove(emp);
                _context.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
    }
}
