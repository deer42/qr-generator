using FluentAssertions;
using NUnit.Framework;
using QrGenerator.Abstract;
using QrGenerator.Readers;
using System;
using System.IO;
using System.Reflection;

namespace QrGenerator.Cli.Tests
{
    [TestFixture]
    public class SourceFileReaderFactoryTests
    {
        private readonly string _sourceFileDir = $"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}\\DataIn";
        private readonly string _destinationDir = $"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}\\DataOut";

        [TestCase("xlsx")]
        [TestCase("xls")]
        public void Create_Should_Return_ExcelReader(string extension)
        {
            var qrOptions = new QrOptions()
            {
                SourceFilePath = $"{_sourceFileDir}\\testdata.{extension}",
                DestinationDirectoryPath = _destinationDir,
                DestinationFileType = DestinationFileType.JPG,
                RunInParallel = true,
                HasHeader = true,
                PixelsPerModule = 8,
                Format = "123",
                SkipRows = 1
            };

            var result = SourceFileReaderFactory.Create(qrOptions);

            result.Should().BeOfType<ExcelReader>();
        }

        [TestCase("csv")]
        [TestCase("txt")]
        public void Create_Should_Return_CsvReader(string extension)
        {
            var qrOptions = new QrOptions()
            {
                SourceFilePath = $"{_sourceFileDir}\\testdata.{extension}",
                DestinationDirectoryPath = _destinationDir,
                DestinationFileType = DestinationFileType.JPG,
                RunInParallel = true,
                HasHeader = true,
                PixelsPerModule = 8,
                Format = "123",
                SkipRows = 1
            };

            var result = SourceFileReaderFactory.Create(qrOptions);

            result.Should().BeOfType<CsvReader>();
        }

        [TestCase("json")]
        [TestCase("xml")]
        public void Create_Should_Throw_When_File_Type_Is_Not_Supported(string extension)
        {
            var qrOptions = new QrOptions()
            {
                SourceFilePath = $"{_sourceFileDir}\\testdata.{extension}",
                DestinationDirectoryPath = _destinationDir,
                DestinationFileType = DestinationFileType.JPG,
                RunInParallel = true,
                HasHeader = true,
                PixelsPerModule = 8,
                Format = "123",
                SkipRows = 1
            };

            Action act = () => SourceFileReaderFactory.Create(qrOptions);

            act.Should().Throw<InvalidDataException>().WithMessage("*not supported*");
        }
    }
}