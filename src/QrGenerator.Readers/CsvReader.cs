using ExcelDataReader;
using QrGenerator.Abstract;
using System.Data;
using System.IO;

namespace QrGenerator.Readers
{
    public class CsvReader : TableReaderBase
    {
        public CsvReader(QrOptions options) : base(options)
        {            
        }        

        protected override IExcelDataReader CreateReader(FileStream stream)
        {
            return ExcelReaderFactory.CreateCsvReader(stream);
        }
    }
}
