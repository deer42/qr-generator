using FluentAssertions;
using NUnit.Framework;
using QrGenerator.Abstract;
using QrGenerator.Writers;
using System;
using System.IO;
using System.Reflection;

namespace QrGenerators.Writers.Tests
{
    [TestFixture]
    public class QrImageWriterTests
    {
        private readonly string _destinationDir = $"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}\\DataOut";

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
        public void Write_Should_Save_Jpeg()
        {
            var options = new QrOptions
            {
                PixelsPerModule = 1,
                DestinationDirectoryPath = _destinationDir,
                DestinationFileType = DestinationFileType.JPG
            };
            var expected = Path.Combine(_destinationDir, $"{nameof(Write_Should_Save_Jpeg)}_1.jpg");

            using (var writer = new QrImageWriter(options))
            {
                writer.Write(nameof(Write_Should_Save_Jpeg), nameof(Write_Should_Save_Jpeg));
            }

            File.Exists(expected).Should().BeTrue();
        }

        [Test]
        public void Write_Should_Save_Bmp()
        {
            var options = new QrOptions
            {
                PixelsPerModule = 1,
                DestinationDirectoryPath = _destinationDir,
                DestinationFileType = DestinationFileType.BMP
            };
            var expected = Path.Combine(_destinationDir, $"{nameof(Write_Should_Save_Bmp)}_1.bmp");

            using (var writer = new QrImageWriter(options))
            {
                writer.Write(nameof(Write_Should_Save_Bmp), nameof(Write_Should_Save_Bmp));
            }

            File.Exists(expected).Should().BeTrue();
        }

        [Test]
        public void Write_Should_Save_Png()
        {
            var options = new QrOptions
            {
                PixelsPerModule = 1,
                DestinationDirectoryPath = _destinationDir,
                DestinationFileType = DestinationFileType.PNG
            };
            var expected = Path.Combine(_destinationDir, $"{nameof(Write_Should_Save_Png)}_1.png");

            using (var writer = new QrImageWriter(options))
            {
                writer.Write(nameof(Write_Should_Save_Png), nameof(Write_Should_Save_Png));
            }

            File.Exists(expected).Should().BeTrue();
        }

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        public void Write_Should_Save_With_PixelsPerModule_In_Name(int pixelsPerModule)
        {
            var options = new QrOptions
            {
                PixelsPerModule = pixelsPerModule,
                DestinationDirectoryPath = _destinationDir,
                DestinationFileType = DestinationFileType.PNG
            };
            var expected = Path.Combine(_destinationDir, $"{nameof(Write_Should_Save_Png)}_{pixelsPerModule}.png");

            using (var writer = new QrImageWriter(options))
            {
                writer.Write(nameof(Write_Should_Save_Png), nameof(Write_Should_Save_Png));
            }

            File.Exists(expected).Should().BeTrue();
        }        
    }    
}