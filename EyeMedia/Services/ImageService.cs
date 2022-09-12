namespace EyeMedia.Services;

public static class ImageService
{
    private static ImageSourceConverter Converter { get; set; } = new();


    public static ImageSource? GetImageFromPath(string path)
    {
        var source = Converter.ConvertFromString(path) as ImageSource;

        return source;
    }
}
