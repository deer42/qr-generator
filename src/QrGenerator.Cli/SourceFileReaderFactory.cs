using QrGenerator.Abstract;
using QrGenerator.Readers;
using System.IO;

namespace QrGenerator.Cli;

public static class SourceFileReaderFactory
{
    public static ISourceFileReader Create(QrOptions options)
    {
        var fileInfo = new FileInfo(options.SourceFilePath);
        return fileInfo.Extension.ToLower() switch
        {
            ".xlsx" => new ExcelReader(options),
            ".xls" => new ExcelReader(options),
            ".csv" => new CsvReader(options),
            ".txt" => new CsvReader(options),
            _ => throw new InvalidDataException($"The given file with extension {fileInfo.Extension} is not supported"),
        };
    }
}
