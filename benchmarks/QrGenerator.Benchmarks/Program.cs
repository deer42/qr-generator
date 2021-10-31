using BenchmarkDotNet.Running;

namespace QrGenerator.Benchmarks
{
    class Program
    {
        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<QrGeneratorBenchmarker>();
        }
    }
}
