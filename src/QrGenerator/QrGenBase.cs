namespace QrGenerator;

public abstract class QrGenBase : IQrGen
{
    protected readonly ISourceFileReader Reader;
    protected readonly IQrWriter Writer;
    protected readonly QrOptions Options;

    protected QrGenBase(ISourceFileReader reader, IQrWriter writer, QrOptions options)
    {
        Reader = reader;
        Writer = writer;
        Options = options;
    }

    public void Execute()
    {
        var table = Reader.Read();
        var qrInfoFactory = new QrInfoFactory(table, Options);
        var qrInfos = qrInfoFactory.Create();
        ExportQrCodes(qrInfos);
    }

    protected abstract void ExportQrCodes(IList<QrInfo> qrCodes);
}
