using EmployeeApplication.Models;
using Newtonsoft.Json;
using System.Reflection.Metadata.Ecma335;
using static EmployeeApplication.Models.RandomUsers;

namespace EmployeeApplication.Services
{
    class RandomUserAPI : IRandomUser
    {
        public static string API => "https://randomuser.me/api/";

        public async Task<dynamic> GetRandomUsersAsync(int count)
        {
            var service = DependencyService.Get<IWebClientService>();
            var json = await service.GetAsync($"{API}?results={count}");

            var response = JsonConvert.DeserializeObject<dynamic>(json);
            var users = response.results;

            return users;
        }
    }
}
