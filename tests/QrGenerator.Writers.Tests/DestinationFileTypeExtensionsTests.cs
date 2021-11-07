using FluentAssertions;
using NUnit.Framework;
using QrGenerator.Abstract;
using QrGenerator.Writers;
using System.Collections.Generic;
using System.Drawing.Imaging;

namespace QrGenerators.Writers.Tests
{
    [TestFixture]
    public class DestinationFileTypeExtensionsTests
    {
        private static IEnumerable<TestCaseData> ToImageFormatTestCases
        {
            get
            {
                yield return new TestCaseData(DestinationFileType.BMP, ImageFormat.Bmp);
                yield return new TestCaseData(DestinationFileType.PNG, ImageFormat.Png);
                yield return new TestCaseData(DestinationFileType.JPG, ImageFormat.Jpeg);                
            }
        }

        [TestCaseSource(nameof(ToImageFormatTestCases))]
        public void ToImageFormat_Should_Return_Expected(DestinationFileType given, ImageFormat expected)
        {
            given.ToImageFormat().Should().Be(expected);
        }

        [TestCase(DestinationFileType.BMP, "bmp")]
        [TestCase(DestinationFileType.PNG, "png")]
        [TestCase(DestinationFileType.JPG, "jpg")]
        public void ToFileExtension_Should_Return_Expected(DestinationFileType given, string expected)
        {
            given.ToFileExtension().Should().Be(expected);
        }
    }
}