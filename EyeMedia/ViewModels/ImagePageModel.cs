namespace EyeMedia.ViewModels;

public class ImagePageModel: DependencyObject
{
    public List<ImageItem> Images { get; set; }
    public ImageItem CurrentImage
    {
        get { return (ImageItem)GetValue(CurrentImageProperty); }
        set { SetValue(CurrentImageProperty, value); }
    }
    public static readonly DependencyProperty CurrentImageProperty =
        DependencyProperty.Register("CurrentImage", typeof(ImageItem), typeof(ImagePageModel));

    public RelayCommand PreviewImageCommand { get; set; }
    public RelayCommand NextImageCommand { get; set; }

    public RelayCommand StartAnimationChangeImageCommand { get; set; }
    public DispatcherTimer AnimationChangeImageTimer { get; set; }

    public object PlayButtonImage
    {
        get { return (object)GetValue(PlayButtonImageProperty); }
        set { SetValue(PlayButtonImageProperty, value); }
    }
    public static readonly DependencyProperty PlayButtonImageProperty =
        DependencyProperty.Register("PlayButtonImage", typeof(object), typeof(ImagePageModel));


    public ImagePageModel(List<ImageItem> images, ImageItem currentImage)
    {
        Images = images;
        CurrentImage = currentImage;

        StartAnimationChangeImageCommand = new RelayCommand((sender) => StartAnimationChangeImage(), null);
        PreviewImageCommand = new RelayCommand((sender) => PreviewImage(), (sender) => Images[0] != CurrentImage);
        NextImageCommand = new RelayCommand((sender) => NextImage(), (sender) => Images[Images.Count - 1] != CurrentImage);

        AnimationChangeImageTimer = new DispatcherTimer();
        AnimationChangeImageTimer.Tick += ImageChangeTimer_Tick;
        AnimationChangeImageTimer.Interval = TimeSpan.FromSeconds(2);

        PlayButtonImage = new PackIcon() { Kind = PackIconKind.Play };
    }

    
    public void PreviewImage()
    {
        for (int i = 0; i < Images.Count; i++)
        {
            if (Images[i] == CurrentImage)
            {
                CurrentImage = Images[i - 1];
                break;
            }
        }
    }

    public void NextImage()
    {
        for (int i = 0; i < Images.Count; i++)
        {
            if (Images[i] == CurrentImage)
            {
                CurrentImage = Images[i + 1];
                break;
            }
        }
    }

    public void StartAnimationChangeImage()
    {
        AnimationChangeImageTimer?.Start();
        PlayButtonImage = new PackIcon() { Kind = PackIconKind.Pause };
    }

    private void ImageChangeTimer_Tick(object? sender, EventArgs e)
    {
        if (Images[Images.Count - 1] != CurrentImage) NextImage();
        else
        {
            AnimationChangeImageTimer.Stop();
            PlayButtonImage = new PackIcon() { Kind = PackIconKind.Play };
        }
    }
}
