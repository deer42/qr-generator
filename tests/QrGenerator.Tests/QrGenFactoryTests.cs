using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using QrGenerator.Abstract;
using System;

namespace QrGenerator.Tests
{
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
        public void Create_Should_Return_What_Implements_IQrGen()
        {
            var options = new QrOptions { RunInParallel = false };
            var qrGen = QrGenFactory.Create(options, _reader, _writer);

            qrGen.Should().BeAssignableTo<IQrGen>();
        }

        [Test]
        public void Create_Should_Return_Instance_Of_Type_QrGen()
        {
            var options = new QrOptions { RunInParallel = false };
            var qrGen = QrGenFactory.Create(options, _reader, _writer);

            qrGen.Should().BeOfType<QrGen>();
        }

        [Test]
        public void Create_Should_Return_Instance_Of_Type_ParallelQrGen()
        {
            var options = new QrOptions { RunInParallel = true };
            var qrGen = QrGenFactory.Create(options, _reader, _writer);

            qrGen.Should().BeOfType<ParallelQrGen>();
        }
    }    
}