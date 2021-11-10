using FluentAssertions;
using NUnit.Framework;
using QrGenerator.Abstract;
using QrGenerator.TestHelpers;
using System.Collections.Generic;

namespace QrGenerator.Tests;

[TestFixture]
public class QrInfoFactoryTests
{
    [Test]
    public void Create_Should_Return_Expected_With_Key()
    {
        IList<QrInfo> expected = new List<QrInfo>
            {
                new QrInfo(@"C:\Users\Dennis\Documents\GitHub\qr-generator\tests\QrGenerator.Tests\bin\Debug\net5.0\DataOut\pre_123_suf.jpg", "ArticleNo: 123\r\nLength: 100mm\r\nWidth: 50mm\r\n"),
                new QrInfo(@"C:\Users\Dennis\Documents\GitHub\qr-generator\tests\QrGenerator.Tests\bin\Debug\net5.0\DataOut\pre_124_suf.jpg", "ArticleNo: 124\r\nLength: 110mm\r\nWidth: 60mm\r\n")
            };

        var table = new Table()
        {
            Headers = new List<string>
                {
                    "ArticleNo", "Length", "Width"
                },
            Data = new List<IList<string>>
                {
                    new List<string>
                    {
                        "123", "100mm", "50mm"
                    },
                    new List<string>
                    {
                        "124", "110mm", "60mm"
                    }
                }
        };

        var options = TestValues.DefaultQrOptions;

        var factory = new QrInfoFactory(table, options);
        var result = factory.Create();

        result.Should().BeEquivalentTo(expected);
    }

    [Test]
    public void Create_Should_Return_Expected_With_Guid()
    {
        IList<QrInfo> expected = new List<QrInfo>
            {
                new QrInfo(@"C:\Users\Dennis\Documents\GitHub\qr-generator\tests\QrGenerator.Tests\bin\Debug\net5.0\DataOut\*.jpg", "ArticleNo: 123\r\nLength: 100mm\r\nWidth: 50mm\r\n"),
                new QrInfo(@"C:\Users\Dennis\Documents\GitHub\qr-generator\tests\QrGenerator.Tests\bin\Debug\net5.0\DataOut\*.jpg", "ArticleNo: 124\r\nLength: 110mm\r\nWidth: 60mm\r\n")
            };

        var table = new Table()
        {
            Headers = new List<string>
                {
                    "ArticleNo", "Length", "Width"
                },
            Data = new List<IList<string>>
                {
                    new List<string>
                    {
                        "123", "100mm", "50mm"
                    },
                    new List<string>
                    {
                        "124", "110mm", "60mm"
                    }
                }
        };

        var options = TestValues.DefaultQrOptions;

        var factory = new QrInfoFactory(table, options);
        var result = factory.Create();

        result[0].Content.Should().BeEquivalentTo(expected[0].Content);
        result[1].Content.Should().BeEquivalentTo(expected[1].Content);
        result[0].FileName.Should().Match(expected[0].FileName);
        result[1].FileName.Should().Match(expected[1].FileName);
    }

    [Test]
    public void Create_Should_Not_Create_QrInfo_When_Number_Of_Headers_Is_Not_Equal_To_Number_Of_Columns()
    {
        var table = new Table()
        {
            Headers = new List<string>
                {
                    "ArticleNo", "Length", "Width"
                },
            Data = new List<IList<string>>
                {
                    new List<string>
                    {
                        "123", "100mm"
                    },
                    new List<string>
                    {
                        "124", "110mm"
                    }
                }
        };

        var options = TestValues.DefaultQrOptions;

        var factory = new QrInfoFactory(table, options);
        var result = factory.Create();

        result.Should().BeEmpty();
    }
}
