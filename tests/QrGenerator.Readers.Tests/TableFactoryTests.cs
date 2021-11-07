using ExcelDataReader;
using FluentAssertions;
using NUnit.Framework;
using QrGenerator.Abstract;
using QrGenerator.TestHelpers;
using System.Data;
using System.IO;

namespace QrGenerator.Readers.Tests
{
    [TestFixture]
    public class TableFactoryTests
    {
        [Test]
        public void Create_Should_Return_Table_With_Expected_Headers()
        {
            var options = TestValues.DefaultQrOptions;
            var dataSet = GetDataSet(options);

            var result = TableFactory.Create(dataSet);

            result.Headers.Should().BeEquivalentTo(TestValues.DefaultHeaders);
        }

        [Test]
        public void Create_Should_Return_Table_With_Expected_Data()
        {
            var options = TestValues.DefaultQrOptions;
            var dataSet = GetDataSet(options);

            var result = TableFactory.Create(dataSet);

            result.Data.Should().HaveCount(TestValues.DefaultDataRowCount);
        }

        private static DataSet GetDataSet(QrOptions options)
        {
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

            using var stream = File.Open(options.SourceFilePath, FileMode.Open, FileAccess.Read);
            using var reader = ExcelReaderFactory.CreateCsvReader(stream);
            var config = new ExcelDataSetConfiguration()
            {
                UseColumnDataType = true,
                FilterSheet = (tableReader, sheetIndex) => true,
                ConfigureDataTable = (tableReader) => new ExcelDataTableConfiguration
                {
                    UseHeaderRow = options.HasHeader,
                    ReadHeaderRow = (rowReader) =>
                    {
                        for (int i = 0; i < options.SkipRows; i++)
                        {
                            rowReader.Read();
                        }
                    }
                }
            };
            return reader.AsDataSet(config);
        }
    }
}