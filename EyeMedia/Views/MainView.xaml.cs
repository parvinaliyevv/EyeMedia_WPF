namespace EyeMedia.Views;

public partial class MainView : Window
{
    public MainView()
    {
        InitializeComponent();

        DataContext = MainViewModel.GetInstance();
    }

    private void Application_Loaded(object sender, RoutedEventArgs e)
    {
        Icon = ImageService.GetImageFromPath(Directory.GetCurrentDirectory().Split("bin")[0] + "app_icon.png");
    }
}
