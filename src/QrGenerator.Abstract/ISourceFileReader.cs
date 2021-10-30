using System.Data;

namespace QrGenerator.Abstract
{
    public interface ISourceFileReader
    {
        DataSet Read();
    }
}
