namespace EmployeeApplication;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

        Routing.RegisterRoute(nameof(Views.EmployeePage), typeof(Views.EmployeePage));
    }
}
