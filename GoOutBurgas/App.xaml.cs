using GoOutBurgas.Pages;

namespace GoOutBurgas;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
	}
}
