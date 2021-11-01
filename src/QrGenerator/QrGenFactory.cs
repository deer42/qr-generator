using QrGenerator.Abstract;

namespace QrGenerator
{
    public static class QrGenFactory
    {
        public static IQrGen Create(ISourceFileReader reader, IQrWriter writer, QrOptions options)
        {
            return options.RunInParallel ? new ParallelQrGen(reader, writer, options) : new QrGen(reader, writer, options);
        }
    }
}
