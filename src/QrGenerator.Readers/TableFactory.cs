using System.Data;
using System.Linq;

namespace QrGenerator.Readers;

public static class TableFactory
{
    public static Table Create(DataSet dataSet)
    {
        var resultTable = new Table();

        foreach (DataTable table in dataSet.Tables)
        {
            var headers = GetHeaders(table);
            resultTable.Headers = headers;
            var rows = table.Rows;

            foreach (DataRow row in rows)
            {
                resultTable.Data.Add(GetCells(row));
            }
        }

        return resultTable;
    }

    private static IList<string> GetHeaders(DataTable table)
    {
        List<string> headers = new();
        foreach (DataColumn column in table.Columns)
        {
            headers.Add(column.ColumnName);
        }
        return headers;
    }

    private static IList<string> GetCells(DataRow row)
    {
        return row.ItemArray.Select(x => x.ToString()).ToList();
    }
}
