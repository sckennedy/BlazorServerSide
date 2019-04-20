using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorServerSide.Core.Interfaces
{
    public interface IEmployeeService
    {
        Task<Employee[]> GetAllEmployees();
        void AddEmployee(Employee employee);
        void UpdateEmployee(Employee employee);
        Employee GetEmployee(int id);
        void DeleteEmployee(int id);
    }
}
