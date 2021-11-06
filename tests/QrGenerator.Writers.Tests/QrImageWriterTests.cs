using FluentAssertions;
using NUnit.Framework;
using QrGenerator.Abstract;
using QrGenerator.Writers;
using System.IO;
using System.Reflection;

namespace QrGenerators.Writers.Tests
{
    [TestFixture]
    public class QrImageWriterTests
    {
        private readonly string _destinationDir = $"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}\\DataOut";
        private readonly QrOptions _defaultOptions = new QrOptions
        {
            PixelsPerModule = 1,
            DestinationDirectoryPath = $"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}\\DataOut",
            NamePattern = "{key}"
        };

        [SetUp]
        public void SetUp()
        {
            if (!Directory.Exists(_destinationDir))
            {
                Directory.CreateDirectory(_destinationDir);
            }
        }

        [TearDown]
        public void TearDown()
        {
            Directory.Exists(_destinationDir).Should().BeTrue();
            Directory.Delete(_destinationDir, true);
        }
        
        [Test]
        public void Write_Should_Save([Values] DestinationFileType fileType)
        {
            var options = _defaultOptions with { DestinationFileType = fileType };
            var expected = Path.Combine(_destinationDir, $"{nameof(Write_Should_Save)}.{fileType.ToFileExtension()}");

            using (var writer = new QrImageWriter(options))
            {
                var qrInfo = new QrInfo(expected, nameof(Write_Should_Save));
                writer.Write(qrInfo);
            }

            File.Exists(expected).Should().BeTrue();
        }
    }
}