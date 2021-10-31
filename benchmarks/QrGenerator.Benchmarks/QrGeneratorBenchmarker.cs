using BenchmarkDotNet.Attributes;
using QrGenerator.Abstract;
using QrGenerator.Cli;
using System.IO;
using System.Reflection;

namespace QrGenerator.Benchmarks
{
    [MemoryDiagnoser]
    public class QrGeneratorBenchmarker
    {
        private readonly string _sourceFileDir = $"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}\\DataIn";
        private readonly string _destinationDir = $"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}\\DataOut";

        [GlobalSetup]
        public void SetUp()
        {
            if (!Directory.Exists(_destinationDir))
            {
                Directory.CreateDirectory(_destinationDir);
            }
        }

        [GlobalCleanup]
        public void TearDown()
        {
            if (Directory.Exists(_destinationDir))
            {
                Directory.Delete(_destinationDir, true);
            }            
        }

        [Benchmark]
        public void GenerateQrCodes()
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

            qrGen.Execute();            
        }

        [Benchmark]
        public void GenerateQrCodesInParallel()
        {
            var qrOptions = new QrOptions()
            {
                SourceFilePath = $"{_sourceFileDir}\\testdata.csv",
                DestinationDirectoryPath = _destinationDir,
                DestinationFileType = DestinationFileType.JPG,
                RunInParallel = true,
                HasHeader = true,
                PixelsPerModule = 8
            };

            ISourceFileReader reader = SourceFileReaderFactory.Create(qrOptions);
            IQrWriter writer = QrWriterFactory.Create(qrOptions);
            var qrGen = QrGenFactory.Create(qrOptions, reader, writer);

            qrGen.Execute();
        }
    }
}
