using System.Collections.Generic;

namespace QrGenerator.Abstract
{
    public interface IQrContentFormatter
    {
        string Generate(IList<string> row, IList<string> headers);
    }
}