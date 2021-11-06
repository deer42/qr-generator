using QrGenerator.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
        private readonly DestinationFileType _fileType;
        private readonly string _namePattern;
        private readonly string _prefix;
        private readonly string _suffix;

        public QrInfoFactory(Table table, QrOptions options)
        {
            _table = table;
            _options = options;

            _fileType = options.DestinationFileType;
            _namePattern = @$"{options.DestinationDirectoryPath}\{options.NamePattern}.{_fileType.ToFileExtension()}";
            _prefix = options.Prefix;
            _suffix = options.Suffix;
        }

        public IList<QrInfo> Create()
        {
            List<QrInfo> result = new();

            foreach (var row in _table.Data)
            {
                var content = GetQrContent(row);
                var key = GetKey(row);
                var fileName = GetFileName(key);
                result.Add(new QrInfo(fileName, content));
            }

            return result;
        }

        public string GetQrContent(IList<string> row)
        {
            var contentBuilder = new StringBuilder();

            for (int i = 0; i < _table.Headers.Count; i++)
            {
                contentBuilder.AppendLine($"{_table.Headers[i]}: {row[i]}");
            }

            return contentBuilder.ToString();
        }        

        private string GetKey(IList<string> row)
        {
            if (row is null || !row.Any())
            {
                throw new ArgumentNullException(nameof(row), "Row should contain values");
            }

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
