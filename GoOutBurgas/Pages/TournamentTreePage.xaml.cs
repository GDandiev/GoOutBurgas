namespace GoOutBurgas.Pages;

public partial class TournamentTreePage : ContentPage
{
	public TournamentTreePage()
	{
		InitializeComponent();
		//Bad();
	}
	public async void Bad()
	{
        await Shell.Current.GoToAsync("LoginPage");
    }
}