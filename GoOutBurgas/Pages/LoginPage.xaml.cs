using GoOutBurgas.Data;
using GoOutBurgas.Model;
using GoOutBurgas.Themes;
using Microsoft.Maui.ApplicationModel.Communication;
//using static Android.Graphics.ImageDecoder;
//using static Android.Provider.MediaStore;

namespace GoOutBurgas.Pages;

public partial class LoginPage : ContentPage
{
    Database notController = new Database();
    public LoginPage()
    {
        InitializeComponent();
    }
    private async void TapGestureRecognizer_Tapped_For_Logo(object sender, EventArgs e)
    {
        if (Email.Default.IsComposeSupported)
        {
            Location location = await Geolocation.Default.GetLastKnownLocationAsync();

            string subject = "In order to add your activity please atach a photo of the location:                                                                                                                                                                                                                                                                                                                                                                               ";
            string body = "Activity name: ";
            string[] recipients = new[] { "gooutburgas@gmail.com", "gooutburgas@gmail.com" };

            var message = new EmailMessage
            {
                Subject = body,
                Body = subject + location.ToString(),
                BodyFormat = EmailBodyFormat.PlainText,
                To = new List<string>(recipients)
            };

            // message.Attachments.Add(new EmailAttachment(burgaslogotest.png));
            await Email.Default.ComposeAsync(message);
        }

    }
    private async void LoginBtnClicked(object sender, EventArgs e)
    {
        var email = EntryEmail.Text;
        var pass = Pass.Text;


        if (EntryEmail.TextColor == Color.FromHex("#8b0000") || EntryEmail.TextColor == Color.FromHex("#FF0000")) //STAN
        {
            await DisplayAlert("Invalid Email", "You need to be using a valid email", "Ok");
        }
        else
        {
            if (string.IsNullOrEmpty(email) && string.IsNullOrEmpty(Pass.Text))
            {
                await DisplayAlert("Empty", "Email and password are both missing or epmty", "OK"); ;
            }
            else if (string.IsNullOrEmpty(email))
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
                    if (await notController.LoginCheck(email, Pass.Text) != null)
                    {
                        await Shell.Current.GoToAsync("MapPage");
                        //AppShell shell = new AppShell();
                        //await shell.GoToAsync("MapPage");
                        //AppShell.SetTabBarIsVisible(Shell.Current,false);
                        //await Navigation.PushAsync(new MapPage());

                        //await Navigation.PushAsync(new NavigationPage(new MapPage()));
                    }
                    else
                    {
                        await DisplayAlert("Wrong", "Email or password ", "OK");
                    }
                }
                catch (Exception ex)
                {
                    await DisplayAlert("Error", ex.Message, "PANIC");
                }
            }
        }

    }
    private async void TapGestureRecognizer_Tapped_For_SignUP(object sender, EventArgs e)
    {
        //await Navigation.PushAsync(RegisterPage());
        await Navigation.PushAsync(new RegisterPage());
        //await Navigation.PushAsync(new RegisterPage());

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
        var email = EntryEmail.Text;
        var pass = Pass.Text;

        if (EntryEmail.TextColor == Color.FromHex("#8b0000") || EntryEmail.TextColor == Color.FromHex("#FF0000"))
        {
            await DisplayAlert("Invalid Email", "You need to be using a valid email", "Ok");
        }
        else
        {
            if (string.IsNullOrEmpty(email) && string.IsNullOrEmpty(Pass.Text))
            {
                await DisplayAlert("Empty", "Email and password are both missing or epmty", "OK"); ;
            }
            else if (string.IsNullOrEmpty(email))
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
                    if (await notController.LoginCheck(email, Pass.Text) != null)
                    {
                        await Shell.Current.GoToAsync("MapPage");
                    }
                    else
                    {
                        await DisplayAlert("Wrong", "Email or password ", "OK");
                    }
                }
                catch (Exception ex)
                {
                    await DisplayAlert("Error", ex.Message, "PANIC");
                }
            }
        }
    }
    private void EmailCompleted(object sender, EventArgs e)
    {
        //string text = ((Entry)sender).Text;
        string text = Pass.Text;
    }

}
