using NUnit.Framework;
using QrGenerator.Abstract;

namespace QrGenerator.Tests
{
    [TestFixture]
    public class QrGenTests : QrGenTestBase
    {
        protected override QrOptions GetOptions()
        {
            return new QrOptions()
            {
                SourceFilePath = $"{SourceFileDir}\\testdata.xlsx",
                DestinationDirectoryPath = DestinationDir,
                DestinationFileType = DestinationFileType.JPG,
                RunInParallel = false,
                HasHeader = true,
                PixelsPerModule = 8,
                Key = 0,
                NamePattern = "{key}"
            };
        }
    }
}