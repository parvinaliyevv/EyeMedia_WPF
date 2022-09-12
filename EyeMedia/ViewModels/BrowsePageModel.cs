namespace EyeMedia.ViewModels;

public class BrowsePageModel
{
    private static BrowsePageModel? _instance;

    public ObservableCollection<ImageItem> Images { get; set; }
    public ObservableCollection<VideoItem> Videos { get; set; }

    public RelayCommand OpenImageCommand { get; set; }
    public RelayCommand OpenVideoCommand { get; set; }

    public RelayCommand AddFileCommand { get; set; }
    public RelayCommand AddFolderCommand { get; set; }

    public RelayCommand GoToImageItemsCommand { get; set; }
    public RelayCommand GoToVideoItemsCommand { get; set; }

    public RelayCommand OpenFileCommand { get; set; }

    public bool IsImageItems { get; set; }


    private BrowsePageModel()
    {
        Images = new ObservableCollection<ImageItem>();
        Videos = new ObservableCollection<VideoItem>();
        
        AddFileCommand = new RelayCommand((sender) => AddFile());
        OpenFileCommand = new RelayCommand((sender) => OpenFile());
        AddFolderCommand = new RelayCommand((sender) => AddFolder());

        GoToImageItemsCommand = new RelayCommand((sender) => IsImageItems = true);
        GoToVideoItemsCommand = new RelayCommand((sender) => IsImageItems = false);
        
        OpenImageCommand = new RelayCommand((sender) => MainViewModel.GetInstance().SelectedPage = new ImagePage(Images.ToList(), (sender as Border).DataContext as ImageItem));
        OpenVideoCommand = new RelayCommand((sender) => MainViewModel.GetInstance().SelectedPage = new VideoPage(Videos.ToList(), (sender as Border).DataContext as VideoItem));
        
        IsImageItems = true;
    }


    public void AddFile()
    {
        var fileDialog = new VistaOpenFileDialog();

        fileDialog.Multiselect = true;
        fileDialog.InitialDirectory = Directory.GetCurrentDirectory();

        if (IsImageItems)
            fileDialog.Filter = "PNG Files(*.png)|*.png|JPEG Files(*.jpeg)|*.jpeg|JPG Files(*.jpg)|*.jpg";
        else
            fileDialog.Filter = "MP4 Files(*.mp4)|*.mp4|AVI Files(*.avi)|*.avi|MOV Files(*.mov)|*.mov";

        fileDialog.FilterIndex = 1;

        if (fileDialog.ShowDialog() is false) return;

        if (IsImageItems)
        {
            foreach (var item in fileDialog.FileNames)
            {
                Images.Add(new(item));
            }
        }
        else
        {
            foreach (var item in fileDialog.FileNames)
            {
                
                Videos.Add(new(item));
            }
        }
    }

    public void AddFolder()
    {
        var fileDialog = new VistaFolderBrowserDialog();

        if (fileDialog.ShowDialog() is false) return;

        if (IsImageItems)
        {
            var files = Directory.GetFiles(fileDialog.SelectedPath, "*.*", SearchOption.AllDirectories).Where(s => s.EndsWith(".png") || s.EndsWith(".jpeg") || s.EndsWith(".jpg"));

            foreach (var item in files)
            {
                Images.Add(new(item));
            }
        }
        else
        {
            var files = Directory.GetFiles(fileDialog.SelectedPath, "*.*", SearchOption.AllDirectories).Where(s => s.EndsWith(".mp4") || s.EndsWith(".avi") || s.EndsWith(".mov"));

            foreach (var item in files)
            {
                Videos.Add(new(item));
            }
        }
    }

    public void OpenFile()
    {
        var fileDialog = new VistaOpenFileDialog();

        fileDialog.Multiselect = true;
        fileDialog.InitialDirectory = Directory.GetCurrentDirectory();

        if (IsImageItems)
            fileDialog.Filter = "PNG Files(*.png)|*.png|JPEG Files(*.jpeg)|*.jpeg|JPG Files(*.jpg)|*.jpg";
        else
            fileDialog.Filter = "MP4 Files(*.mp4)|*.mp4|AVI Files(*.avi)|*.avi|MOV Files(*.mov)|*.mov";

        fileDialog.FilterIndex = 1;

        if (fileDialog.ShowDialog() is false) return;

        if (IsImageItems)
        {
            var images = new List<ImageItem>();

            foreach (var item in fileDialog.FileNames) images.Add(new(item));

            MainViewModel.GetInstance().SelectedPage = new ImagePage(images, images[0]);
        }
        else
        {
            var videos = new List<VideoItem>();

            foreach (var item in fileDialog.FileNames) videos.Add(new(item));

            MainViewModel.GetInstance().SelectedPage = new VideoPage(videos, videos[0]);
        }
    }

    public static BrowsePageModel GetInstance()
    {
        if (_instance is null) _instance = new BrowsePageModel();

        return _instance;
    }
}
