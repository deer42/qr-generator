namespace QrGenerator.Readers;

public class ExcelReader : TableReaderBase
{
    private static readonly string[] _supportedFileTypes = new string[] { ".xls", ".xlsx" };

    public ExcelReader(QrOptions options) : base(options)
    {
    }

    protected override IExcelDataReader CreateReader(FileStream stream)
    {
        return ExcelReaderFactory.CreateReader(stream);
    }

    protected override string[] GetSupportedFileTypes()
    {
        return _supportedFileTypes;
    }
}
