namespace EyeMedia.ViewModels;

public class MainViewModel: DependencyObject
{
    private static MainViewModel? _instance;

    public Page SelectedPage
    {
        get { return (Page)GetValue(SelectedPageProperty); }
        set { SetValue(SelectedPageProperty, value); }
    }
    public static readonly DependencyProperty SelectedPageProperty =
        DependencyProperty.Register("SelectedPage", typeof(Page), typeof(MainViewModel));


    private MainViewModel() => SelectedPage = new BrowsePage();


    public static MainViewModel GetInstance()
    {
        if (_instance is null) _instance = new MainViewModel();

        return _instance;
    }
}
