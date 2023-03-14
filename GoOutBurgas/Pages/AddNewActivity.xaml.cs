namespace GoOutBurgas.Pages;

public partial class AddNewActivity : ContentPage
{
    Image image;
	public AddNewActivity()
	{
		InitializeComponent();

        var button = new Button
        {
            Text = "Pick Image"
        };
        button.Clicked += PickImage;

        image = new Image
        {
            WidthRequest = 300,
            HeightRequest = 300
        };

        Content = new StackLayout
        {
            Children = { button, image }
        };


        async void PickImage(object sender, EventArgs e)
        {
            var file = await FilePicker.PickAsync(new PickOptions
            {
                FileTypes = new FilePickerFileType(new Dictionary<DevicePlatform, IEnumerable<string>>
            {
                { DevicePlatform.Android, new[] { "image/*" } },
                { DevicePlatform.iOS, new[] { "public.image" } },
                { DevicePlatform.MacCatalyst, new[] { "public.image" } }
            })
            });
        }
    }
    
        //var newFile = await file.CopyAsync(FileSystem.AppDataDirectory, file.FileName, NameCollisionOption.GenerateUniqueName);

        //// Upload the selected image to a remote server
        //using (var stream = await file.OpenReadAsync())
        //{
        //    var httpClient = new HttpClient();
        //    var content = new MultipartFormDataContent();
        //    content.Add(new StreamContent(stream), "image", file.FileName);
        //    var response = await httpClient.PostAsync("https://example.com/upload", content);
        //}


    

}