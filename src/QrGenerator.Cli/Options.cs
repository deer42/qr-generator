using CommandLine;

namespace QrGenerator.Cli;

public record Options
{
    [Option('s', "sourceFilePath", Required = true, HelpText = "Sets the path to the source file")]
    public string SourceFilePath { get; set; }

    [Option('o', "destinationDirectoryPath", Required = true, HelpText = "Sets the path to the destination files directory")]
    public string DestinationDirectoryPath { get; set; }

    [Option('t', "destinationFileType", Required = false, Default = DestinationFileType.JPG, HelpText = "Sets the destination file type. Allowed options: JPG, PNG, BMP")]
    public DestinationFileType DestinationFileType { get; set; }

    [Option('p', "pixelsPerModule", Required = false, Default = 8, HelpText = "Sets the size of each module in pixels")]
    public int PixelsPerModule { get; set; }

    [Option('h', "hasHeader", Required = false, Default = false, HelpText = "Use this to use headers")]
    public bool HasHeader { get; set; }

    [Option("skipRows", Required = false, Default = 0, HelpText = "Use this to skip the first x lines")]
    public int SkipRows { get; set; }

    [Option('f', "format", Required = false, Default = "{k}: {v}{newLine}", HelpText = "Sets the pattern to format the data. Valid blocks are {k} for the header, {v} for the value, {newLine} for a new line, {tab} for a tab")]
    public string Format { get; set; }

    [Option('x', "turbo", Required = false, HelpText = "Try to export in parallel")]
    public bool RunInParallel { get; set; }

    [Option("namePattern", Required = false, Default = "{key}", HelpText = "Examples: '{prefix}_{key}_{suffix}', '{key}', '{prefix}-{key}'")]
    public string NamePattern { get; set; }

    [Option("prefix", Required = false, Default = "")]
    public string Prefix { get; set; }

    [Option("suffix", Required = false, Default = "")]
    public string Suffix { get; set; }

    [Option("key", Required = false, HelpText = "Defines the column (first column = 0, second column = 1, ...) which contains the unique id or name of the qr code. If left empty an id will be generated instead.")]
    public int? KeyColumn { get; set; }
}
