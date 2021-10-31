using FluentAssertions;
using NUnit.Framework;
using QrGenerator.Abstract;
using QrGenerator.Writers;
using System.IO;
using System.Reflection;

namespace QrGenerator.Cli.Tests
{
    [TestFixture]
    public class QrWriterFactoryTests
    {
        private readonly string _sourceFileDir = $"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}\\DataIn";
        private readonly string _destinationDir = $"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}\\DataOut";

        [Test]
        public void Create_Should_Return_QrImageWriter()
        {
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
            
            var result = QrWriterFactory.Create(qrOptions);

            result.Should().BeOfType<QrImageWriter>();
        }
    }
}