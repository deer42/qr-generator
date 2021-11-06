using QRCoder;
using QrGenerator.Abstract;
using System;

namespace QrGenerator.Writers
{
    public class QrImageWriter : IQrWriter, IDisposable
    {
        private readonly QRCodeGenerator _qrCodeGenerator = new();
        private readonly int _pixelsPerModule;        
        private readonly DestinationFileType _fileType;        
        private bool _disposed = false;

        public QrImageWriter(QrOptions options)
        {            
            _pixelsPerModule = options.PixelsPerModule;
            _fileType = options.DestinationFileType;            
        }        

        public void Write(QrInfo info)
        {
            using var qrCodeData = _qrCodeGenerator.CreateQrCode(info.Content, QRCodeGenerator.ECCLevel.Q);
            using var qrCode = new QRCode(qrCodeData);
            var qrCodeImage = qrCode.GetGraphic(_pixelsPerModule);            
            qrCodeImage.Save(info.FileName, _fileType.ToImageFormat());
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