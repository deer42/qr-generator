using QrGenerator.Abstract;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QrGenerator
{
    public class ParallelQrGen : QrGenBase
    {
        public ParallelQrGen(ISourceFileReader reader, IQrWriter writer, QrOptions options) : base(reader, writer, options)
        {
        }        

        protected override void ExportQrCodes(IList<QrInfo> qrCodes)
        {
            Parallel.ForEach(qrCodes, qrCode => Writer.Write(qrCode));            
        }
    }
}
