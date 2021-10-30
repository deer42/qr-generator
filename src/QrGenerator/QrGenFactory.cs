using QrGenerator.Abstract;

namespace QrGenerator
{
    public static class QrGenFactory
    {
        public static IQrGen Create(QrOptions options, ISourceFileReader reader, IQrWriter writer)
        {
            return options.RunInParallel ? new ParallelQrGen(reader, writer) : new QrGen(reader, writer);
        }
    }
}
