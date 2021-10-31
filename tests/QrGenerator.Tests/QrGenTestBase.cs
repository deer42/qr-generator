using FluentAssertions;
using NUnit.Framework;
using QrGenerator.Abstract;
using QrGenerator.Readers;
using QrGenerator.Writers;
using System;
using System.IO;
using System.Reflection;

namespace QrGenerator.Tests
{
    public abstract class QrGenTestBase
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

        [Test]
        public virtual void Excecute_Should_Not_Throw()
        {
            var options = GetOptions();
            var reader = new ExcelReader(options);
            var writer = new QrImageWriter(options);
            var qrGen = QrGenFactory.Create(options, reader, writer);

            Action act = () => qrGen.Execute();

            act.Should().NotThrow();
        }

        [Test]
        public virtual void Excecute_Should_Create_QrCodes()
        {
            var options = GetOptions();
            var reader = new ExcelReader(options);
            var writer = new QrImageWriter(options);
            var qrGen = QrGenFactory.Create(options, reader, writer);

            qrGen.Execute();

            Directory.GetFiles(DestinationDir, "*.jpg").Should().HaveCount(267);
        }

        protected abstract QrOptions GetOptions();
    }
}