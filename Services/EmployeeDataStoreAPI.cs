using EmployeeApplication.Models;
using EmployeeApplication.Services;
using Newtonsoft.Json;

namespace EmployeeApplication.Services
{
    class EmployeeDataStoreAPI : IEmployeeDataStore<Employee>
    {
        private static string API => "https://randomuser.me/api/";

        public async Task<IEnumerable<Employee>> GetEmployeesAsync(int count)
        {
            var service = DependencyService.Get<IWebClientService>();
            var jsonString = await service.GetAsync($"{API}?results={count}");

            var employees = JsonConvert.DeserializeObject<Root>(jsonString).results;

            return employees;
        }
    }
}
