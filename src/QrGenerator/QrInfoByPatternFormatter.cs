using QrGenerator.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace QrGenerator
{
    public class QrInfoByPatternFormatter : IQrContentFormatter
    {
        private const string Key = "{k}";
        private const string Value = "{v}";
        private const string NewLine = "{newLine}";
        private const string Tab = "{tab}";        

        private readonly string _pattern;        

        public QrInfoByPatternFormatter(string pattern)
        {
            ValidatePattern(pattern);

            _pattern = pattern;
        }        

        public string Generate(IList<string> row, IList<string> headers)
        {
            var contentBuilder = new StringBuilder();

            for (int i = 0; i < headers.Count; i++)
            {
                var content = GenerateFromPattern(headers[i], row[i]);
                contentBuilder.Append(content);
            }

            return contentBuilder.ToString();
        }

        private string GenerateFromPattern(string key, string value)
        {
            return _pattern
                .Replace(Key, key)
                .Replace(Value, value)
                .Replace(NewLine, Environment.NewLine)
                .Replace(Tab, "\t");
        }

        private static void ValidatePattern(string pattern)
        {
            if (string.IsNullOrWhiteSpace(pattern))
            {
                throw new ArgumentException("The given format string is empty. It should at least contain {v}", nameof(pattern));
            }
            if (!pattern.Contains(Value))
            {
                throw new ArgumentException($"The given format string \"{pattern}\" is invalid. It should at least contain {{v}}", nameof(pattern));
            }
        }
    }
}