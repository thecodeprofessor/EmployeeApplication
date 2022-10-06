using EmployeeApplication.Models;
using EmployeeApplication.Services;
using MvvmHelpers;
using MvvmHelpers.Commands;

namespace EmployeeApplication.ViewModels
{
    //https://devblogs.microsoft.com/dotnet/introducing-the-net-maui-community-toolkit-preview/#what-to-expect-in-net-maui-toolkit

    internal class EmployeeListViewModel
    {
        public IEmployeeDataStore<Employee> DataStore => DependencyService.Get<IEmployeeDataStore<Employee>>();
        public ObservableRangeCollection<Employee> Employees { get; set; }
        public AsyncCommand PageAppearingCommand { get; }

        public EmployeeListViewModel()
        {
            Employees = new ObservableRangeCollection<Employee>();
            PageAppearingCommand = new AsyncCommand(PageAppearing);
        }

        public async Task Refresh()
        {
            var employees = await DataStore.GetEmployeesAsync(20);

            Employees.AddRange(employees);
        }

        async Task PageAppearing()
        {
            await Refresh();
        }
    }
}
