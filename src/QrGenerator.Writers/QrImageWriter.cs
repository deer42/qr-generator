using QRCoder;
using QrGenerator.Abstract;
using System;

namespace QrGenerator.Writers
{
    public class QrImageWriter : IQrWriter, IDisposable
    {
        public const string Prefix = "{prefix}";
        public const string Suffix = "{suffix}";
        public const string Key = "{key}";
        public const string Extension = "{extension}";

        private readonly QRCodeGenerator _qrCodeGenerator = new();
        private readonly int _pixelsPerModule;        
        private readonly DestinationFileType _fileType;
        private readonly string _namePattern;
        private readonly string _prefix;
        private readonly string _suffix;
        private bool _disposed = false;

        public QrImageWriter(QrOptions options)
        {            
            _pixelsPerModule = options.PixelsPerModule;
            _fileType = options.DestinationFileType;
            _namePattern = @$"{options.DestinationDirectoryPath}\{options.NamePattern}.{_fileType.ToFileExtension()}";
            _prefix = options.Prefix;
            _suffix = options.Suffix;
        }

        public void Write(string key, string value)
        {
            using var qrCodeData = _qrCodeGenerator.CreateQrCode(value, QRCodeGenerator.ECCLevel.Q);
            using var qrCode = new QRCode(qrCodeData);
            var qrCodeImage = qrCode.GetGraphic(_pixelsPerModule);
            var fileName = GetFileName(key);            
            qrCodeImage.Save(fileName, _fileType.ToImageFormat());
        }        

        public string GetFileName(string key)
        {   
            var fileName = _namePattern
                .Replace(Prefix, _prefix)
                .Replace(Key, key)
                .Replace(Suffix, _suffix)
                .Replace(Extension, _fileType.ToFileExtension());

            return fileName;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _qrCodeGenerator?.Dispose();
                }

                _disposed = true;
            }
        }
    }


}