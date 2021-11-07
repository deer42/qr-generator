using QrGenerator.Abstract;
using QrGenerator.Cli;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace QrGenerator.TestHelpers
{
    public static class TestValues
    {
        public const string TestCsvFileName = "testdata.csv";
        public const string TestXlsxFileName = "testdata.xlsx";
        public const string TestTxtFileName = "testdata.txt";
        public const string DefaultNamePattern = "{prefix}_{key}_{suffix}";
        public const string DefaultPrefix = "pre";
        public const string DefaultSuffix = "suf";
        public const string DefaultFormat = "k:v/n";
        public const int DefaultDataRowCount = 267;

        public static readonly string SourceFileDir = $"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}\\DataIn";
        public static readonly string DestinationDir = $"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}\\DataOut";
        public static readonly string SourceCsvFilePath = $"{SourceFileDir}\\{TestCsvFileName}";
        public static readonly string SourceXlsxFilePath = $"{SourceFileDir}\\{TestXlsxFileName}";
        public static readonly string SourceTxtFilePath = $"{SourceFileDir}\\{TestTxtFileName}";

        public static readonly Options DefaultOptions = new()
        {
            SourceFilePath = SourceCsvFilePath,
            DestinationDirectoryPath = DestinationDir,
            DestinationFileType = DestinationFileType.JPG,
            PixelsPerModule = 8,
            HasHeader = true,
            SkipRows = 0,
            Format = DefaultFormat,
            RunInParallel = true,
            NamePattern = DefaultNamePattern,
            Prefix = DefaultPrefix,
            Suffix = DefaultSuffix,
            KeyColumn = 0
        };

        public static readonly QrOptions DefaultQrOptions = new()
        {
            SourceFilePath = SourceCsvFilePath,
            DestinationDirectoryPath = DestinationDir,
            DestinationFileType = DestinationFileType.JPG,
            PixelsPerModule = 8,
            HasHeader = true,
            SkipRows = 0,
            Format = DefaultFormat,
            RunInParallel = true,
            NamePattern = DefaultNamePattern,
            Prefix = DefaultPrefix,
            Suffix = DefaultSuffix,
            Key = 0
        };

        public static readonly IList<string> DefaultHeaders = new List<string>
        {
            "Artikelnummer","Bezeichnung","Gewicht"
        };
    }
}