using EmployeeApplication.Models;
using static EmployeeApplication.Models.RandomUsers;

namespace EmployeeApplication.Services
{
    interface IRandomUser
    {
        Task<dynamic> GetRandomUsersAsync(int count);
    }
}
