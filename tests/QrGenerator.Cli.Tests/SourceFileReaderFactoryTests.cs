using FluentAssertions;
using NUnit.Framework;
using QrGenerator.Readers;
using QrGenerator.TestHelpers;
using System;
using System.IO;

namespace QrGenerator.Cli.Tests
{
    [TestFixture]
    public class SourceFileReaderFactoryTests
    {
        [TestCase("xlsx")]
        [TestCase("xls")]
        public void Create_Should_Return_ExcelReader(string extension)
        {
            var qrOptions = TestValues.DefaultQrOptions with { SourceFilePath = $"{TestValues.SourceFileDir}\\testdata.{extension}" };

            var result = SourceFileReaderFactory.Create(qrOptions);

            result.Should().BeOfType<ExcelReader>();
        }

        [TestCase("csv")]
        [TestCase("txt")]
        public void Create_Should_Return_CsvReader(string extension)
        {
            var qrOptions = TestValues.DefaultQrOptions with { SourceFilePath = $"{TestValues.SourceFileDir}\\testdata.{extension}" };

            var result = SourceFileReaderFactory.Create(qrOptions);

            result.Should().BeOfType<CsvReader>();
        }

        [TestCase("json")]
        [TestCase("xml")]
        public void Create_Should_Throw_When_File_Type_Is_Not_Supported(string extension)
        {
            var qrOptions = TestValues.DefaultQrOptions with { SourceFilePath = $"{TestValues.SourceFileDir}\\testdata.{extension}" };

            Action act = () => SourceFileReaderFactory.Create(qrOptions);

            act.Should().Throw<InvalidDataException>().WithMessage("*not supported*");
        }
    }
}