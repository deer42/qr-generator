using CommandLine;
using QrGenerator.Abstract;

namespace QrGenerator.Cli
{
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

        [Option('f', "format", Required = false, Default ="k:v/n", HelpText = "Sets the pattern to format the data")]
        public string Format { get; set; }

        [Option('x', "turbo", Required = false, HelpText = "Try to export in parallel")]
        public bool RunInParallel { get; set; }
    }
}
