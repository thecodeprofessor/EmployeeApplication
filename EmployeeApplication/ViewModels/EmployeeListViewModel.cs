using CommunityToolkit.Mvvm.Input;
using EmployeeApplication.Models;
using EmployeeApplication.Services;
using MvvmHelpers;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace EmployeeApplication.ViewModels
{
    internal class EmployeeListViewModel
    {
        public IEmployeeDataStore SqliteDataStore => DependencyService.Get<IEmployeeDataStore>();
        public ObservableRangeCollection<EmployeeViewModel> Employees { get; set;}
        public ICommand PageAppearingCommand { get; set; }
        public ICommand SelectCommand { get; }
        public ICommand AddCommand { get; }

        public EmployeeListViewModel()
        {
            Employees = new ObservableRangeCollection<EmployeeViewModel>();
            PageAppearingCommand = new AsyncRelayCommand(PageAppearing);
            SelectCommand = new AsyncRelayCommand<EmployeeViewModel>(SelectAsync);
            AddCommand = new AsyncRelayCommand(AddAsync);
        }

        private async Task SelectAsync(EmployeeViewModel employee)
        {
            if (employee != null)
                await Shell.Current.GoToAsync($"{nameof(Views.EmployeePage)}?id={employee.Id}");
        }

        private async Task AddAsync()
        {
            await Shell.Current.GoToAsync(nameof(Views.EmployeePage));
        }

        public async Task Refresh()
        {
            var employees = await SqliteDataStore.GetEmployeesAsync();
            Employees.Clear();
            Employees.AddRange(new List<EmployeeViewModel>(employees.Select(employee => new EmployeeViewModel(employee))));
        }

        public async Task PageAppearing()
        {
            await Refresh();
        }
    }
}
