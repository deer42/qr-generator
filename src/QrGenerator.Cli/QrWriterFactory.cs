using QrGenerator.Writers;

namespace QrGenerator.Cli;

public static class QrWriterFactory
{
    public static IQrWriter Create(QrOptions options)
    {
        return new QrImageWriter(options);
    }
}
