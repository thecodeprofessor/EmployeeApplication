using EmployeeApplication.Models;
using EmployeeApplication.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeApplication.Services
{
    interface IEmployeeDataStore<T>
    {
        Task<IEnumerable<Employee>> GetEmployeesAsync(int count);
    }
}