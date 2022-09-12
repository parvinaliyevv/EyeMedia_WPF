namespace EyeMedia.Views;

public partial class VideoPage : Page
{
    public bool IsPlay { get; set; }


    public VideoPage(List<VideoItem> videos, VideoItem currentVideo)
    {
        InitializeComponent();

        DataContext = new VideoPageModel(videos, currentVideo);
    }


    private void Media_Loaded(object sender, RoutedEventArgs e)
    {
        Media.Play();
        IsPlay = true;
    }

    private void RewingVideo_ButtonClicked(object sender, RoutedEventArgs e)
    {
        Media.Position -= TimeSpan.FromSeconds(5);
    }

    private void ResumeVideo_ButtonClicked(object sender, RoutedEventArgs e)
    {
        if (IsPlay)
        {
            Media.Pause();
            IsPlay = false;

            PlayOrStopButton.Content = new PackIcon() { Kind = PackIconKind.Play };
        }
        else
        {
            Media.Play();
            IsPlay = true;

            PlayOrStopButton.Content = new PackIcon() { Kind = PackIconKind.Pause };
        }
    }

    private void ForwardVideo_ButtonClicked(object sender, RoutedEventArgs e)
    {
        if (Media.Position.TotalSeconds + 5 >= Media.NaturalDuration.TimeSpan.TotalSeconds)
        {
            IsPlay = true;

            ResumeVideo_ButtonClicked(null, null);

            return;
        }

        Media.Position += TimeSpan.FromSeconds(5);
    }

    private void CheckBox_Unchecked(object sender, RoutedEventArgs e) => Media.Stretch = Stretch.Uniform;

    private void CheckBox_Checked(object sender, RoutedEventArgs e) => Media.Stretch = Stretch.Fill;

    private void ReturnMenu_ButtonClicked(object sender, RoutedEventArgs e)
        => MainViewModel.GetInstance().SelectedPage = new BrowsePage();
}
