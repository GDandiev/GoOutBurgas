using GoOutBurgas.Data;
using GoOutBurgas.Model;
using GoOutBurgas.Themes;
namespace GoOutBurgas.Pages;

public partial class LoginPage : ContentPage
{
    Database notController = new Database();
    public LoginPage()
    {
        InitializeComponent();
        ICollection<ResourceDictionary> mergedDictionaries = Application.Current.Resources.MergedDictionaries;

        Application.Current.UserAppTheme = AppTheme.Light;
        //if (mergedDictionaries != null)
        //{
        //    mergedDictionaries.Clear();
        //    mergedDictionaries.Add(new LightTheme());
        //}
    }

    private async void GoToRegister(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new NavigationPage(new RegisterPage()));
    }

    private async void OnButtonClicked(object sender, EventArgs e)
    {
        //  await Navigation.PushAsync(new NavigationPage(new MapPage()));

        var email = Email.Text;
        var pass = Pass.Text;
     
        if (string.IsNullOrEmpty(Email.Text) && string.IsNullOrEmpty(Pass.Text))
        {
            await DisplayAlert("Empty", "Empty textboxes not good no good", "OK");
        }
        else if (string.IsNullOrEmpty(Email.Text))
        {
            await DisplayAlert("Empty", "Email missing", "OK");
        }
        else if (string.IsNullOrEmpty(Pass.Text))
        {
            await DisplayAlert("Empty", "Password missing", "OK");
        }
        else
        {
            User loginTable = new User();

            try
            {
                if (await notController.LoginCheck(Email.Text, Pass.Text) != null)
                {
                    await Navigation.PushAsync(new NavigationPage(new MapPage()));
                }
                else
                {
                    await DisplayAlert("Wrong", "Email or password ", "OK");
                }
            }
            catch (Exception ex)
            {

                await DisplayAlert("Error", "Something wrong happened: " + ex.Message, "PANIC");
            }
        }
    }
    private async void TapGestureRecognizer_Tapped_For_SignUP(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new NavigationPage(new RegisterPage()));
    }

    void OnCheckBoxCheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        if (Check.IsChecked == true)
        {
            Pass.IsPassword = false;
        }
        else
        {
            Pass.IsPassword = true;
        }
    }

    private async void OnPasswordCompleted(object sender, EventArgs e)
    {
        //  await Navigation.PushAsync(new NavigationPage(new MapPage()));

        var email = Email.Text;
        var pass = Pass.Text;

        if (string.IsNullOrEmpty(Email.Text) && string.IsNullOrEmpty(Pass.Text))
        {
            await DisplayAlert("Empty", "Empty textboxes not good no good", "OK");
        }
        else if (string.IsNullOrEmpty(Email.Text))
        {
            await DisplayAlert("Empty", "Email missing", "OK");
        }
        else if (string.IsNullOrEmpty(Pass.Text))
        {
            await DisplayAlert("Empty", "Password missing", "OK");
        }
        else
        {
            User loginTable = new User();

            try
            {
                if (await notController.LoginCheck(Email.Text, Pass.Text) != null)
                {
                    await Navigation.PushAsync(new NavigationPage(new MapPage()));
                }
                else
                {
                    await DisplayAlert("Wrong", "Email or password ", "OK");
                }
            }
            catch (Exception ex)
            {

                await DisplayAlert("Error", "Something wrong happened: " + ex.Message, "PANIC");
            }
        }

    }
    private  void EmailCompleted(object sender, EventArgs e)
    {
       //string text = ((Entry)sender).Text;
        string text = Pass.Text;
    }

}
