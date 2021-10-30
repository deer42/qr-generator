using QrGenerator.Abstract;
using System.Collections.Generic;

namespace QrGenerator
{
    public class QrGen : QrGenBase
    {
        public QrGen(ISourceFileReader reader, IQrWriter writer) : base(reader, writer)
        {
        }

        protected override void ExportQrCodes(Dictionary<string, string> qrCodeData)
        {
            foreach (var pair in qrCodeData)
            {
                Writer.Write(pair.Key, pair.Value);
            }
        }
    }
}
