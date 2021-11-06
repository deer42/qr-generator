namespace QrGenerator.Abstract
{
    public enum DestinationFileType
    {
        JPG, PNG, BMP
    }

    public static class DestinationFileTypeExtensions
    {
        public static string ToFileExtension(this DestinationFileType fileType)
        {
            return fileType.ToString().ToLower();
        }
    }
}
