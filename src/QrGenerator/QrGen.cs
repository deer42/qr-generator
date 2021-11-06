using QrGenerator.Abstract;
using System.Collections.Generic;

namespace QrGenerator
{
    public class QrGen : QrGenBase
    {
        public QrGen(ISourceFileReader reader, IQrWriter writer, QrOptions options) : base(reader, writer, options)
        {
        }        

        protected override void ExportQrCodes(IList<QrInfo> qrCodes)
        {
            foreach (var qrCode in qrCodes)
            {
                Writer.Write(qrCode);
            }
        }
    }    
}
