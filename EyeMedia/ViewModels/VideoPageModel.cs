namespace EyeMedia.ViewModels;

public class VideoPageModel: DependencyObject
{
    public List<VideoItem> Videos { get; set; }
    public VideoItem CurrentVideo
    {
        get { return (VideoItem)GetValue(CurrentVideoProperty); }
        set { SetValue(CurrentVideoProperty, value); }
    }
    public static readonly DependencyProperty CurrentVideoProperty =
        DependencyProperty.Register("CurrentVideo", typeof(VideoItem), typeof(VideoPageModel));

    public RelayCommand PreviewVideoCommand { get; set; }
    public RelayCommand NextVideoCommand { get; set; }


    public VideoPageModel(List<VideoItem> videos, VideoItem currentVideo)
    {
        Videos = videos;
        CurrentVideo = currentVideo;

        PreviewVideoCommand = new RelayCommand((sender) => PreviewVideo(), (sender) => Videos[0] != CurrentVideo);
        NextVideoCommand = new RelayCommand((sender) => NextVideo(), (sender) => Videos[Videos.Count - 1] != CurrentVideo);
    }


    public void PreviewVideo()
    {
        for (int i = 0; i < Videos.Count; i++)
        {
            if (Videos[i] == CurrentVideo)
            {
                CurrentVideo = Videos[i - 1];
                break;
            }
        }
    }

    public void NextVideo()
    {
        for (int i = 0; i < Videos.Count; i++)
        {
            if (Videos[i] == CurrentVideo)
            {
                CurrentVideo = Videos[i + 1];
                break;
            }
        }
    }
}
