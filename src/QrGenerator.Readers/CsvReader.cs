using ExcelDataReader;
using QrGenerator.Abstract;
using System.IO;

namespace QrGenerator.Readers
{
    public class CsvReader : TableReaderBase
    {
        private static readonly string[] _supportedFileTypes = new string[] { ".csv", ".txt" };

        public CsvReader(QrOptions options) : base(options)
        {            
        }        

        protected override IExcelDataReader CreateReader(FileStream stream)
        {
            return ExcelReaderFactory.CreateCsvReader(stream);
        }

        protected override string[] GetSupportedFileTypes()
        {
            return _supportedFileTypes;
        }
    }
}
