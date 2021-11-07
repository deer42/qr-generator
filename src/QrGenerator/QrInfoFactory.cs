using QrGenerator.Abstract;
using System;
using System.Collections.Generic;

namespace QrGenerator
{
    public class QrInfoFactory
    {
        public const string Prefix = "{prefix}";
        public const string Suffix = "{suffix}";
        public const string Key = "{key}";
        public const string Extension = "{extension}";

        private readonly Table _table;
        private readonly QrOptions _options;
        private readonly IQrContentFormatter _formatter;
        private readonly DestinationFileType _fileType;
        private readonly string _namePattern;
        private readonly string _prefix;
        private readonly string _suffix;        

        public QrInfoFactory(Table table, QrOptions options)
        {
            _table = table;
            _options = options;
            _formatter = new QrInfoByPatternFormatter(options.Format);
            _fileType = options.DestinationFileType;
            _namePattern = @$"{options.DestinationDirectoryPath}\{options.NamePattern}.{_fileType.ToFileExtension()}";
            _prefix = options.Prefix;
            _suffix = options.Suffix;
        }

        public IList<QrInfo> Create()
        {
            List<QrInfo> result = new();
            var colCount = _table.Headers.Count;

            foreach (var row in _table.Data)
            {
                if (row.Count != colCount )
                {
                    continue;
                }

                var content = _formatter.Generate(row, _table.Headers);
                var key = GetKey(row);
                var fileName = GetFileName(key);
                result.Add(new QrInfo(fileName, content));
            }

            return result;
        }              

        private string GetKey(IList<string> row)
        {
            if (_options?.Key is int key)
            {
                return row[key].ToString();
            }

            return Guid.NewGuid().ToString();
        }

        private string GetFileName(string key)
        {
            var fileName = _namePattern
                .Replace(Prefix, _prefix)
                .Replace(Key, key)
                .Replace(Suffix, _suffix)
                .Replace(Extension, _fileType.ToFileExtension());

            return fileName;
        }        
    }    
}
