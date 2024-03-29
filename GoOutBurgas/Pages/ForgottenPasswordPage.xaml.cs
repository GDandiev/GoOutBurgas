using GoOutBurgas.Data;

namespace GoOutBurgas.Pages;

public partial class ForgottenPasswordPage : ContentPage
{
    Database notController = new Database();

    public ForgottenPasswordPage()
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

    private async void OnButtonClicked(object sender, EventArgs e)
    {
        try
        {
            if (Pass.Text == Password.Text)
            {
                string email = Email.Text;
                string password = Pass.Text;
                var success = await notController.UpdateUser(email, password);
                await DisplayAlert("Reset", "Your password has been successfully reset.", "Login");
            }
            else
            {
                await DisplayAlert("Error", "The passwords are not the same", "OK");
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", ""+ ex, "OK");
        }
    }

}