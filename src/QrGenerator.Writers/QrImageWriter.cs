using QRCoder;
using System.Drawing;
using QrGenerator.Abstract;
using System;

namespace QrGenerator.Writers
{
    public class QrImageWriter : IQrWriter, IDisposable
    {
        private readonly QRCodeGenerator _qrCodeGenerator = new();
        private readonly int _pixelsPerModule;
        private readonly string _directory;
        private readonly DestinationFileType _fileType;
        private bool _disposed = false;

        public QrImageWriter(QrOptions options)
        {
            _directory = options.DestinationDirectoryPath;
            _pixelsPerModule = options.PixelsPerModule;
            _fileType = options.DestinationFileType;
        }

        public void Write(string name, string text)
        {
            using var qrCodeData = _qrCodeGenerator.CreateQrCode(text, QRCodeGenerator.ECCLevel.Q);
            using var qrCode = new QRCode(qrCodeData);
            var qrCodeImage = qrCode.GetGraphic(_pixelsPerModule);
            var fileName = @$"{_directory}\{name}_{_pixelsPerModule}.{_fileType.ToFileExtension()}";
            qrCodeImage.Save(fileName, _fileType.ToImageFormat());
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