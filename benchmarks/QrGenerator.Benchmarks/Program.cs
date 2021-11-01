using BenchmarkDotNet.Running;

namespace QrGenerator.Benchmarks
{
    static class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<QrGeneratorBenchmarker>();
        }
    }
}
