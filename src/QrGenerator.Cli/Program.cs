using CommandLine;
using QrGenerator.Abstract;
using System;

namespace QrGenerator.Cli
{
    class Program
    {
        static void Main(string[] args)
        {
            Parser.Default.ParseArguments<Options>(args).WithParsed(RunOptions);
        }

        private static void RunOptions(Options options)
        {
            try
            {
                var qrOptions = options.ToQrOptions();
                ISourceFileReader reader = SourceFileReaderFactory.Create(qrOptions);
                IQrWriter writer = QrWriterFactory.Create(qrOptions);
                var qrGen = QrGenFactory.Create(qrOptions, reader, writer);
                qrGen.Execute();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
