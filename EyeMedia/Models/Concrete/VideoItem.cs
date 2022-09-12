namespace EyeMedia.Models.Concrete;

public class VideoItem : MediaBase
{
    public string Path { get; set; }


    public VideoItem(string path) : base(ImageService.GetImageFromPath(Directory.GetCurrentDirectory().Split("bin")[0] + "video_icon.png")) { Path = path; }
}
