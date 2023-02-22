using GoOutBurgas.Pages;

namespace GoOutBurgas;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		Routing.RegisterRoute("MapPage", typeof(MapPage));

        Routing.RegisterRoute("LoginPage", typeof(LoginPage));
    }
}
