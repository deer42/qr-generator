using FluentAssertions;
using NUnit.Framework;
using QrGenerator.Abstract;
using System.IO;
using System.Reflection;

namespace QrGenerator.Cli.Tests
{
    [TestFixture]
    public class OptionsExtensionsTests
    {
        private readonly string _sourceFileDir = $"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}\\DataIn";
        private readonly string _destinationDir = $"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}\\DataOut";

        [Test]
        public void ToQrOptions_Should_Return_Expected()
        {
            var options = new Options()
            {
                SourceFilePath = $"{_sourceFileDir}\\testdata.csv",
                DestinationDirectoryPath = _destinationDir,
                DestinationFileType = DestinationFileType.JPG,
                RunInParallel = true,
                HasHeader = true,
                PixelsPerModule = 8,
                Format = "123",
                SkipRows = 1
            };

            var qrOptions = new QrOptions()
            {
                SourceFilePath = $"{_sourceFileDir}\\testdata.csv",
                DestinationDirectoryPath = _destinationDir,
                DestinationFileType = DestinationFileType.JPG,
                RunInParallel = true,
                HasHeader = true,
                PixelsPerModule = 8,
                Format = "123",
                SkipRows = 1
            };

            var result = options.ToQrOptions();

            result.Should().BeEquivalentTo(qrOptions);
        }

        [Test]
        public void ToQrOptions_Should_Return_Null()
        {
            var result = ((Options)null).ToQrOptions();

            result.Should().BeNull();
        }
    }
}