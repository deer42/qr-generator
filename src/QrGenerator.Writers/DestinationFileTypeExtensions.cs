using QrGenerator.Abstract;
using System.Drawing.Imaging;

namespace QrGenerator.Writers;

public static class DestinationFileTypeExtensions
{
    public static ImageFormat ToImageFormat(this DestinationFileType fileType)
    {
        return fileType switch
        {
            DestinationFileType.BMP => ImageFormat.Bmp,
            DestinationFileType.JPG => ImageFormat.Jpeg,
            DestinationFileType.PNG => ImageFormat.Png,
            _ => ImageFormat.Jpeg
        };
    }
}
