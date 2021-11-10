namespace QrGenerator.Readers.Tests;

[TestFixture]
public class CsvReaderTests : TableReaderTestBase
{
    [TestCase("txt")]
    [TestCase("csv")]
    public override void Read_Should_Read_All_Rows(string extension)
    {
        base.Read_Should_Read_All_Rows(extension);
    }


    [TestCase("xlsx")]
    public override void Read_Should_Throw_If_File_Type_Is_Not_Supported(string extension)
    {
        base.Read_Should_Throw_If_File_Type_Is_Not_Supported(extension);
    }

    protected override ISourceFileReader GetReader(QrOptions options)
    {
        return new CsvReader(options);
    }
}
