namespace EyeMedia.Views;

public partial class ImagePage : Page
{
    public ImagePage(List<ImageItem> images, ImageItem currentImage)
    {
        InitializeComponent();

        DataContext = new ImagePageModel(images, currentImage);
    }

    private void ReturnMenu_ButtonClicked(object sender, RoutedEventArgs e) => MainViewModel.GetInstance().SelectedPage = new BrowsePage();

    private void CheckBox_Unchecked(object sender, RoutedEventArgs e) => Image.Stretch = Stretch.Uniform;

    private void CheckBox_Checked(object sender, RoutedEventArgs e) => Image.Stretch = Stretch.Fill;
}
