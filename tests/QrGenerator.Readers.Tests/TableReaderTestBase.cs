using FluentAssertions;
using NUnit.Framework;
using QrGenerator.Abstract;
using System;
using System.IO;
using System.Reflection;

namespace QrGenerator.Readers.Tests
{
    public abstract class TableReaderTestBase
    {
        protected readonly string SourceFileDir = $"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}\\DataIn";
        protected readonly string DestinationDir = $"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}\\DataOut";

        [SetUp]
        public void SetUp()
        {
            Directory.Exists(SourceFileDir).Should().BeTrue();

            if (!Directory.Exists(DestinationDir))
            {
                Directory.CreateDirectory(DestinationDir);
            }
        }

        [TearDown]
        public void TearDown()
        {
            Directory.Exists(DestinationDir).Should().BeTrue();
            Directory.Delete(DestinationDir, true);
        }
                
        public virtual void Read_Should_Read_All_Rows(string extension)
        {
            var options = new QrOptions()
            {
                SourceFilePath = $"{SourceFileDir}\\testdata.{extension}",
                DestinationDirectoryPath = DestinationDir,
                DestinationFileType = DestinationFileType.JPG,
                RunInParallel = false,
                HasHeader = true,
                PixelsPerModule = 8
            };
            var reader = GetReader(options);

            var result = reader.Read();

            result.Tables[0].Rows.Count.Should().Be(267);
        }

        public virtual void Read_Should_Throw_If_File_Type_Is_Not_Supported(string extension)
        {
            var options = new QrOptions()
            {
                SourceFilePath = $"{SourceFileDir}\\testdata.{extension}",
                DestinationDirectoryPath = DestinationDir,
                DestinationFileType = DestinationFileType.JPG,
                RunInParallel = false,
                HasHeader = true,
                PixelsPerModule = 8
            };

            Action act = () => GetReader(options);

            act.Should().Throw<InvalidDataException>();
        }

        protected abstract ISourceFileReader GetReader(QrOptions options);
    }
}