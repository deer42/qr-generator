using FluentAssertions;
using NUnit.Framework;
using QrGenerator.Abstract;
using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace QrGenerator.Cli.Tests
{
    [TestFixture]
    public class BenchmarkTests
    {
        private readonly string _sourceFileDir = $"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}\\DataIn";
        private readonly string _destinationDir = $"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}\\DataOut";

        [SetUp]
        public void SetUp()
        {
            Directory.Exists(_sourceFileDir).Should().BeTrue();

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
        public void Benchmark_QrGen_Csv_To_Jpg()
        {
            var qrOptions = new QrOptions()
            {
                SourceFilePath = $"{_sourceFileDir}\\testdata.csv",
                DestinationDirectoryPath = _destinationDir,
                DestinationFileType = DestinationFileType.JPG,
                RunInParallel = false,
                HasHeader = true,
                PixelsPerModule = 8
            };

            ISourceFileReader reader = SourceFileReaderFactory.Create(qrOptions);
            IQrWriter writer = QrWriterFactory.Create(qrOptions);
            var qrGen = QrGenFactory.Create(qrOptions, reader, writer);

            var stopwatch = Stopwatch.StartNew();

            qrGen.Execute();

            stopwatch.Stop();

            stopwatch.ElapsedMilliseconds.Should().BeLessThanOrEqualTo(3000);
        }

        [Test]
        public void Benchmark_ParallelQrGen_Csv_To_Jpg()
        {
            var qrOptions = new QrOptions()
            {
                SourceFilePath = $"{_sourceFileDir}\\testdata.csv",
                DestinationDirectoryPath = _destinationDir,
                DestinationFileType = DestinationFileType.JPG,
                RunInParallel = true,
                HasHeader = true,
                PixelsPerModule = 8,                
            };

            ISourceFileReader reader = SourceFileReaderFactory.Create(qrOptions);
            IQrWriter writer = QrWriterFactory.Create(qrOptions);
            var qrGen = QrGenFactory.Create(qrOptions, reader, writer);

            var stopwatch = Stopwatch.StartNew();

            qrGen.Execute();

            stopwatch.Stop();

            stopwatch.ElapsedMilliseconds.Should().BeLessThanOrEqualTo(1500);
        }
    }
}