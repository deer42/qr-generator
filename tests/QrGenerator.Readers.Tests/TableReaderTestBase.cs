using FluentAssertions;
using NUnit.Framework;
using QrGenerator.Abstract;
using QrGenerator.TestHelpers;
using System;
using System.IO;

namespace QrGenerator.Readers.Tests
{
    public abstract class TableReaderTestBase
    {
        [SetUp]
        public void SetUp()
        {
            Directory.Exists(TestValues.SourceFileDir).Should().BeTrue();

            if (!Directory.Exists(TestValues.DestinationDir))
            {
                Directory.CreateDirectory(TestValues.DestinationDir);
            }
        }

        [TearDown]
        public void TearDown()
        {
            Directory.Exists(TestValues.DestinationDir).Should().BeTrue();
            Directory.Delete(TestValues.DestinationDir, true);
        }
                
        public virtual void Read_Should_Read_All_Rows(string extension)
        {
            var options = TestValues.DefaultQrOptions with { SourceFilePath = $"{TestValues.SourceFileDir}\\testdata.{extension}" };

            var reader = GetReader(options);

            var result = reader.Read();

            result.Data.Count.Should().Be(TestValues.DefaultDataRowCount);
        }

        public virtual void Read_Should_Throw_If_File_Type_Is_Not_Supported(string extension)
        {
            var options = TestValues.DefaultQrOptions with { SourceFilePath = $"{TestValues.SourceFileDir}\\testdata.{extension}" };            

            Action act = () => GetReader(options);

            act.Should().Throw<InvalidDataException>();
        }

        protected abstract ISourceFileReader GetReader(QrOptions options);
    }
}