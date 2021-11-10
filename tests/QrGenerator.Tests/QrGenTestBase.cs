using FluentAssertions;
using NUnit.Framework;
using QrGenerator.Abstract;
using QrGenerator.Readers;
using QrGenerator.TestHelpers;
using QrGenerator.Writers;
using System;
using System.IO;

namespace QrGenerator.Tests;

public abstract class QrGenTestBase
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
    public virtual void Excecute_Should_Not_Throw()
    {
        var options = GetOptions();
        var reader = new ExcelReader(options);
        var writer = new QrImageWriter(options);
        var qrGen = QrGenFactory.Create(reader, writer, options);

        Action act = () => qrGen.Execute();

        act.Should().NotThrow();
    }

    [Test]
    public virtual void Excecute_Should_Create_QrCodes()
    {
        var options = GetOptions();
        var reader = new ExcelReader(options);
        var writer = new QrImageWriter(options);
        var qrGen = QrGenFactory.Create(reader, writer, options);

        qrGen.Execute();

        Directory.GetFiles(TestValues.DestinationDir, $"*.{options.DestinationFileType.ToFileExtension()}").Should().HaveCount(TestValues.DefaultDataRowCount);
    }

    protected abstract QrOptions GetOptions();
}
