using ExcelDataReader;
using QrGenerator.Abstract;
using System.IO;
using System.Linq;

namespace QrGenerator.Readers
{
    public abstract class TableReaderBase : ISourceFileReader
    {
        protected readonly string Path;
        protected readonly bool HasHeader;
        protected readonly int SkipRows;

        protected TableReaderBase(QrOptions options)
        {
            Path = options.SourceFilePath;
            HasHeader = options.HasHeader;
            SkipRows = options.SkipRows;
            ValidateFileType();
        }

        public Table Read()
        {
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

            using var stream = File.Open(Path, FileMode.Open, FileAccess.Read);
            using var reader = CreateReader(stream);
            var config = new ExcelDataSetConfiguration()
            {
                UseColumnDataType = true,
                FilterSheet = (tableReader, sheetIndex) => true,
                ConfigureDataTable = (tableReader) => new ExcelDataTableConfiguration
                {
                    UseHeaderRow = HasHeader,
                    ReadHeaderRow = (rowReader) =>
                    {
                        for (int i = 0; i < SkipRows; i++)
                        {
                            rowReader.Read();
                        }
                    }
                }
            };
            var dataSet = reader.AsDataSet(config);
            return TableFactory.Create(dataSet);
        }

        protected abstract IExcelDataReader CreateReader(FileStream stream);

        private void ValidateFileType()
        {
            var supportedFileTypes = GetSupportedFileTypes();
            var fileExtension = new FileInfo(Path).Extension;

            if (!supportedFileTypes.Contains(fileExtension))
            {
                throw new InvalidDataException($"File type {fileExtension} is not supported");
            }
        }

        protected abstract string[] GetSupportedFileTypes();
    }
}
