using GoOutBurgas.Model;
using GoOutBurgas.Controller;


namespace GoOutBurgas.Pages;

public partial class RegisterPage : ContentPage
{
    Database notController = new Database();

    public RegisterPage()
    {
        InitializeComponent();
    }

    void OnSwitch(object sender, ToggledEventArgs e)
    {
        if (Switch.IsToggled == true)
        {
            Password.IsPassword = false;
            Password.Keyboard = Pass.Keyboard;
            Pass.IsPassword = false;
            Pass.Keyboard = Pass.Keyboard;
        }
        else
        {
            Password.IsPassword = true;
            Password.Keyboard = Pass.Keyboard;
            Pass.IsPassword = true;
            Pass.Keyboard = Pass.Keyboard;
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