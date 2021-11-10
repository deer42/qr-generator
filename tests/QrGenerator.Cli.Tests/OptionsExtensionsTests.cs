using FluentAssertions;
using NUnit.Framework;
using QrGenerator.TestHelpers;

namespace QrGenerator.Cli.Tests;

[TestFixture]
public class OptionsExtensionsTests
{
    [Test]
    public void ToQrOptions_Should_Return_Expected()
    {
        var result = TestValues.DefaultOptions.ToQrOptions();

        result.Should().BeEquivalentTo(TestValues.DefaultQrOptions);
    }

    [Test]
    public void ToQrOptions_Should_Return_Null()
    {
        var result = ((Options)null).ToQrOptions();

        result.Should().BeNull();
    }
}    
