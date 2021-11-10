using FluentAssertions;
using NUnit.Framework;
using QrGenerator.Abstract;
using QrGenerator.TestHelpers;
using QrGenerator.Writers;
using System.IO;

namespace QrGenerator.Writers.Tests;

[TestFixture]
public class QrImageWriterTests
{
    [SetUp]
    public void SetUp()
    {
        if (!Directory.Exists(TestValues.DestinationDir))
        {
            Directory.CreateDirectory(TestValues.DestinationDir);
        }
        Directory.Exists(TestValues.DestinationDir).Should().BeTrue();
    }

    [TearDown]
    public void TearDown()
    {
        Directory.Exists(TestValues.DestinationDir).Should().BeTrue();
        Directory.Delete(TestValues.DestinationDir, true);
        Directory.Exists(TestValues.DestinationDir).Should().BeFalse();
    }

    [Test]
    public void Write_Should_Save([Values] DestinationFileType fileType)
    {
        var options = TestValues.DefaultQrOptions with { DestinationFileType = fileType };
        var expected = Path.Combine(TestValues.DestinationDir, $"{nameof(Write_Should_Save)}.{fileType.ToFileExtension()}");

        using (var writer = new QrImageWriter(options))
        {
            var qrInfo = new QrInfo(expected, nameof(Write_Should_Save));
            writer.Write(qrInfo);
        }

        File.Exists(expected).Should().BeTrue();
    }
}
