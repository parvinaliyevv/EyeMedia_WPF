namespace EyeMedia.Views;

public partial class BrowsePage : Page
{
    public BrowsePage()
    {
        InitializeComponent();

        DataContext = BrowsePageModel.GetInstance();
    }


    private void TabItem_DragAndDrop(object sender, DragEventArgs e)
    {
        var files = (string[])e.Data.GetData(DataFormats.FileDrop);
        var viewModel = DataContext as BrowsePageModel;

        ArgumentNullException.ThrowIfNull(viewModel);

        if (viewModel.IsImageItems)
        {
            foreach (var item in files)
            {
                if (item.EndsWith(".png") || item.EndsWith(".jpeg") || item.EndsWith(".jpg"))
                {
                    viewModel.Images.Add(new(item));
                }
            }
        }
        else
        {
            foreach (var item in files)
            {
                if (item.EndsWith(".mp4") || item.EndsWith(".avi") || item.EndsWith(".mov"))
                {
                    viewModel.Videos.Add(new(item));
                }
            }
        }
    }

    private void CloseApp_MenuItemClicked(object sender, RoutedEventArgs e) => Application.Current.Shutdown();

    private void CloseApp_MenuItemPressed(object sender, KeyEventArgs e) => CloseApp_MenuItemClicked(null, null);

    private void AboutApp_MenuItemClicked(object sender, RoutedEventArgs e)
        => MessageBox.Show("Program for viewing photos and videos.Not all features work.", "Information!", MessageBoxButton.OK, MessageBoxImage.Information);

    private void NotWorking_MenuItemClicked(object sender, RoutedEventArgs e)
        => MessageBox.Show("Unfortunately the function does not work.", "Information!", MessageBoxButton.OK, MessageBoxImage.Information);
}
