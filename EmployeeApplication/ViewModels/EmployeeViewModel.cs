using CommunityToolkit.Mvvm.Input;
using EmployeeApplication.Models;
using EmployeeApplication.Services;
using MvvmHelpers;
using System.Windows.Input;
using static System.Net.Mime.MediaTypeNames;

namespace EmployeeApplication.ViewModels
{
    internal class EmployeeViewModel : ObservableObject, IQueryAttributable
    {
        private Employee _employee;

        public int Id { get => _employee.Id; set { _employee.Id = value; } }
        public string Name { get => _employee.Name; set { _employee.Name = value; } }
        public string Email { get => _employee.Email; set { _employee.Email = value;} }
        public string Image { get => _employee.Image; set { _employee.Image = value;} }

        public IEmployeeDataStore SqliteDataStore => DependencyService.Get<IEmployeeDataStore>();
        public ICommand SaveCommand { get; set; }
        public ICommand DeleteCommand { get; set; }

        public EmployeeViewModel()
        {
            _employee = new Employee();
            SaveCommand = new AsyncRelayCommand(Save);
            DeleteCommand = new AsyncRelayCommand(Delete);
        }

        public EmployeeViewModel(Employee employee)
        {
            _employee = employee;
        }


        async void IQueryAttributable.ApplyQueryAttributes(IDictionary<string, object> query)
        {
            if (!query.ContainsKey("id"))
                return;

            var id = Convert.ToInt32(query["id"].ToString());
            _employee = await SqliteDataStore.GetEmployeeAsync(id);
            OnPropertyChanged(nameof(Name));
            OnPropertyChanged(nameof(Email));
        }

        public async Task Save()
        {
            await SqliteDataStore.SaveEmployeeAsync(_employee);

            await Shell.Current.GoToAsync($"..");
        }

        public async Task Delete()
        {
            await SqliteDataStore.DeleteEmployeeAsync(_employee);
            
            await Shell.Current.GoToAsync($"..");
        }
    }
}
