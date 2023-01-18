using GoOutBurgas.Model;
using GoOutBurgas.Data;


namespace GoOutBurgas.Pages;

public partial class RegisterPage : ContentPage
{
    Database notController = new Database();

    public RegisterPage()
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

    private async void OnButtonClicked(object sender, EventArgs e)
    {
        if (Pass.Text == Password.Text)
        {
            string email = Email.Text;
            string password = Pass.Text;
            await notController.Register(email, password);
            await DisplayAlert("Welcome", "You have been registered successfully ", "Login");
            await Navigation.PushAsync(new NavigationPage(new LoginPage()));
        }
        else
        {
            await DisplayAlert("Error", "The passwords are not the same", "OK");
        }
    }
}