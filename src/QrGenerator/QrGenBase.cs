using QrGenerator.Abstract;
using System;
using System.Collections.Generic;
using System.Data;

namespace QrGenerator
{
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
            var dataSet = Reader.Read();
            var qrCodeData = GetQrCodeData(dataSet);
            ExportQrCodes(qrCodeData);
        }        

        private Dictionary<string, string> GetQrCodeData(DataSet dataSet)
        {
            Dictionary<string, string> result = new();

            foreach (DataTable table in dataSet.Tables)
            {
                var headers = GetHeaders(table);
                var rows = table.Rows;

                for (int rowIndex = 0; rowIndex < rows.Count; rowIndex++)
                {
                    var cells = rows[rowIndex].ItemArray;

                    List<string> texts = new();
                    string key = GetKey(cells);

                    for (int cellIndex = 0; cellIndex < cells.Length; cellIndex++)
                    {
                        var text = $"{headers[cellIndex]}: {cells[cellIndex]}";
                        texts.Add(text);
                    }

                    var value = string.Join(Environment.NewLine, texts);
                    result.Add(key, value);
                }
            }

            return result;
        }

        private static string[] GetHeaders(DataTable table)
        {
            List<string> headers = new();
            foreach (DataColumn column in table.Columns)
            {
                headers.Add(column.ColumnName);
            }
            return headers.ToArray();
        }

        protected abstract void ExportQrCodes(Dictionary<string, string> qrCodeData);

        private string GetKey(object?[] cells)
        {
            if (cells is null)
            {
                throw new ArgumentNullException(nameof(cells), "Cells should contain values");
            }

            if (Options?.Key is int key)
            {
                return cells[key].ToString();                
            }
            
            return Guid.NewGuid().ToString();
        }
    }
}
