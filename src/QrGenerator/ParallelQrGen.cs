using QrGenerator.Abstract;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QrGenerator
{
    public class ParallelQrGen : QrGenBase
    {
        public ParallelQrGen(ISourceFileReader reader, IQrWriter writer) : base(reader, writer)
        {
        }

        protected override void ExportQrCodes(Dictionary<string, string> qrCodeData)
        {
            Parallel.ForEach(qrCodeData, pair => Writer.Write(pair.Key, pair.Value));
        }
    }
}
