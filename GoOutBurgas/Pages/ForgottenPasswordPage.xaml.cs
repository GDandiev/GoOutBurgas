using AndroidX.Navigation;

namespace GoOutBurgas.Pages;

public partial class ForgottenPasswordPage : ContentPage
{
	public ForgottenPasswordPage()
	{
		InitializeComponent();
	}
    void OnCheckBoxCheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        if (Check.IsChecked == true)
        {
            Pass.IsPassword = false;
            Password.IsPassword = false;
        }
        else
        {
            Pass.IsPassword = true;
            Password.IsPassword = true;
        }
    }
    // Location location = await Geolocation.Default.GetLastKnownLocationAsync();


    private async void OnButtonClicked(object sender, EventArgs e)
    {
        if (Pass.Text == Password.Text)
        {
            string email = Email.Text;
            string password = Pass.Text;
            await notController.Register(email, password);
            await DisplayAlert("Welcome", "You have been registered successfully ", "Login");
            await Navigation.PushAsync(new LoginPage());
        }
        else
        {
            await DisplayAlert("Error", "The passwords are not the same", "OK");
        }
    }
}