namespace QrGenerator.Tests;

[TestFixture]
public class QrGenFactoryTests
{
    private ISourceFileReader _reader;
    private IQrWriter _writer;

    [SetUp]
    public void Setup()
    {
        _reader = Substitute.For<ISourceFileReader>();
        _writer = Substitute.For<IQrWriter>();
    }

    [Test]
    public void Create_Should_Return_What_Implements_IQrGen([Values] bool runInParallel)
    {
        var options = TestValues.DefaultQrOptions with { RunInParallel = runInParallel };
        var qrGen = QrGenFactory.Create(_reader, _writer, options);

        qrGen.Should().BeAssignableTo<IQrGen>();
    }

    [Test]
    public void Create_Should_Return_Instance_Of_Type_QrGen()
    {
        var options = TestValues.DefaultQrOptions with { RunInParallel = false };
        var qrGen = QrGenFactory.Create(_reader, _writer, options);

        qrGen.Should().BeOfType<QrGen>();
    }

    [Test]
    public void Create_Should_Return_Instance_Of_Type_ParallelQrGen()
    {
        var options = TestValues.DefaultQrOptions with { RunInParallel = true };
        var qrGen = QrGenFactory.Create(_reader, _writer, options);

        qrGen.Should().BeOfType<ParallelQrGen>();
    }
}    
