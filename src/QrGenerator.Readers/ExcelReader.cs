using ExcelDataReader;
using QrGenerator.Abstract;
using System.IO;

namespace QrGenerator.Readers
{
    public class ExcelReader : TableReaderBase
    {
        public ExcelReader(QrOptions options) : base(options)
        {            
        }        

        protected override IExcelDataReader CreateReader(FileStream stream)
        {
            return ExcelReaderFactory.CreateReader(stream);
        }
    }
}
