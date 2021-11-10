using System.Collections.Generic;

namespace QrGenerator.Abstract;

public record Table
{
    public IList<string> Headers { get; set; }
    public IList<IList<string>> Data { get; set; }

    public Table()
    {
        Data = new List<IList<string>>();
    }
}  
