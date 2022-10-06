using EmployeeApplication.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System.Dynamic;

namespace EmployeeApplication.Services
{
    class EmployeeDataStoreAPI : IEmployeeDataStore<Employee>
    {
        private static string API => "https://randomuser.me/api/";

        public async Task<IEnumerable<Employee>> GetEmployeesAsync(int count)
        {
            var service = DependencyService.Get<IWebClientService>();
            var json = await service.GetAsync($"{API}?results={count}");

            var employees = EmployeeBuilder(json);

            return employees;
        }
        private List<Employee> EmployeeBuilder(string json)
        {

            var response = JsonConvert.DeserializeObject<dynamic>(json);
            var users = response.results;

            var employees = new List<Employee>();

            foreach (var user in users)
            {
                var firstName = user.name.first.ToString();
                var lastName = user.name.last.ToString();
                var name = $"{firstName} {lastName}";
                var email = user.email.ToString();
                var image = user.picture.medium.ToString();

                employees.Add(new Employee(name, email, image));

            }

            return employees;
        }

        public static class UserBuilder
        {
           
        }
    }
}
