namespace QrGenerator.Tests;

[TestFixture]
public class QrGenTests : QrGenTestBase
{
    protected override QrOptions GetOptions()
    {
        return TestValues.DefaultQrOptions with
        {
            SourceFilePath = TestValues.SourceXlsxFilePath,
            RunInParallel = false
        };
    }
}
