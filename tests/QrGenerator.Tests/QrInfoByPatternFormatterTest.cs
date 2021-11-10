using FluentAssertions;
using NUnit.Framework;
using QrGenerator.TestHelpers;
using System;
using System.Collections.Generic;

namespace QrGenerator.Tests;

[TestFixture]
public class QrInfoByPatternFormatterTest
{
    public static IEnumerable<TestCaseData> ValidTestCases()
    {
        yield return new TestCaseData(
            TestValues.DefaultFormat,
            new List<string> { "123", "100mm", "50mm" },
            new List<string> { "ArticleNo", "Length", "Width" },
            "ArticleNo: 123\r\nLength: 100mm\r\nWidth: 50mm\r\n")
            .SetArgDisplayNames("With default format");

        yield return new TestCaseData(
            "{k}: {v}{tab}",
            new List<string> { "123", "100mm", "50mm" },
            new List<string> { "ArticleNo", "Length", "Width" },
            "ArticleNo: 123\tLength: 100mm\tWidth: 50mm\t")
            .SetArgDisplayNames("With tab as line seperator");

        yield return new TestCaseData(
            "{k}: {v};",
            new List<string> { "123", "100mm", "50mm" },
            new List<string> { "ArticleNo", "Length", "Width" },
            "ArticleNo: 123;Length: 100mm;Width: 50mm;")
            .SetArgDisplayNames("With semicolon as line seperator");
    }

    [TestCaseSource(nameof(ValidTestCases))]
    public void Generate_Should_Return_Expected(string format, List<string> rows, List<string> headers, string expected)
    {
        var formatter = new QrInfoByPatternFormatter(format);

        var result = formatter.Generate(rows, headers);

        result.Should().BeEquivalentTo(expected);
    }

    [TestCase("", "The given format string is empty. It should at least contain {v}*")]
    [TestCase("{k}:{newLine}", "The given format string \"{k}:{newLine}\" is invalid. It should at least contain {v}*")]
    public void Constructor_Should_Throw(string format, string expected)
    {
        Action act = () => _ = new QrInfoByPatternFormatter(format);

        act.Should().Throw<ArgumentException>().WithMessage(expected);
    }
}
