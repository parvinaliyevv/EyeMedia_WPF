namespace EyeMedia.Models.Concrete;

public class ImageItem : MediaBase
{
    public string Path { get; set; }


    public ImageItem(string path) : base(ImageService.GetImageFromPath(path)) { Path = path; }
}
