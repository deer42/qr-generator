using FluentAssertions;
using NUnit.Framework;
using QrGenerator.TestHelpers;
using QrGenerator.Writers;

namespace QrGenerator.Cli.Tests
{
    [TestFixture]
    public class QrWriterFactoryTests
    {
        [Test]
        public void Create_Should_Return_QrImageWriter()
        {   
            var result = QrWriterFactory.Create(TestValues.DefaultQrOptions);

            result.Should().BeOfType<QrImageWriter>();
        }
    }
}