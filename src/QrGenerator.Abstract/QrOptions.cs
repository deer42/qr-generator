namespace QrGenerator.Abstract;

public record QrOptions
{
    public string SourceFilePath { get; set; }

    public string DestinationDirectoryPath { get; set; }

    public DestinationFileType DestinationFileType { get; set; }

    public int PixelsPerModule { get; set; }

    public bool HasHeader { get; set; }

    public int SkipRows { get; set; }

    public string Format { get; set; }

    public bool RunInParallel { get; set; }

    public string NamePattern { get; set; }

    public string Prefix { get; set; }

    public string Suffix { get; set; }

    public int? Key { get; set; }
}
