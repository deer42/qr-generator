using QrGenerator.Abstract;

namespace QrGenerator.Cli
{
    public static class OptionsExtensions
    {
        public static QrOptions ToQrOptions(this Options options) => new QrOptions
        {
            DestinationDirectoryPath = options.DestinationDirectoryPath,
            DestinationFileType = options.DestinationFileType,
            Format = options.Format,
            PixelsPerModule = options.PixelsPerModule,
            HasHeader = options.HasHeader,
            SkipRows = options.SkipRows,
            SourceFilePath = options.SourceFilePath,
            RunInParallel = options.RunInParallel
        };
    }
}
