namespace EyeMedia.Models.Abstract;

public abstract class MediaBase
{
    public ImageSource Icon { get; set; }

    public MediaBase(ImageSource image) => Icon = image;
}
