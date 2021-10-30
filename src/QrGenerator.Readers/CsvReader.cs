using ExcelDataReader;
using QrGenerator.Abstract;
using System.Data;
using System.IO;

namespace QrGenerator.Readers
{
    public class CsvReader : ISourceFileReader
    {
        private readonly string _path;
        private readonly bool _skipHeader;

        public CsvReader(QrOptions options)
        {
            _path = options.SourceFilePath;
            _skipHeader = options.SkipHeader;
        }

        public DataSet Read()
        {
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

            using var stream = File.Open(_path, FileMode.Open, FileAccess.Read);
            using var reader = ExcelReaderFactory.CreateCsvReader(stream);
            var config = new ExcelDataSetConfiguration()
            {
                UseColumnDataType = true,
                FilterSheet = (tableReader, sheetIndex) => true,
                ConfigureDataTable = (tableReader) => new ExcelDataTableConfiguration
                {
                    UseHeaderRow = _skipHeader
                }
            };
            return reader.AsDataSet(config);
        }
    }
}
