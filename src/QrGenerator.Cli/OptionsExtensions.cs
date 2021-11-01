using QrGenerator.Abstract;

namespace QrGenerator.Cli
{
    public static class OptionsExtensions
    {
        public static QrOptions ToQrOptions(this Options options)
        {
            if(options == null)
            {
                return null;
            }

            return new QrOptions
            {
                DestinationDirectoryPath = options.DestinationDirectoryPath,
                DestinationFileType = options.DestinationFileType,
                Format = options.Format,
                PixelsPerModule = options.PixelsPerModule,
                HasHeader = options.HasHeader,
                SkipRows = options.SkipRows,
                SourceFilePath = options.SourceFilePath,
                RunInParallel = options.RunInParallel,
                Key = options.KeyColumn,
                NamePattern = options.NamePattern,
                Prefix = options.Prefix,
                Suffix = options.Suffix
            };
        }
    }
}
