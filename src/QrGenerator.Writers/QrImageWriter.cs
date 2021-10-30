using QRCoder;
using System.Drawing;
using QrGenerator.Abstract;

namespace QrGenerator.Writers
{
    public class QrImageWriter : IQrWriter
    {
        private readonly int _pixelsPerModule;
        private readonly string _directory;
        private readonly DestinationFileType _fileType;        

        public QrImageWriter(QrOptions options)
        {
            _directory = options.DestinationDirectoryPath;
            _pixelsPerModule = options.PixelsPerModule;
            _fileType = options.DestinationFileType;
        }

        public void Write(string name, string text)
        {
            QRCodeGenerator qrGenerator = new();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(text, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new(qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(_pixelsPerModule);
            var fileName = @$"{_directory}\{name}_{_pixelsPerModule}.{_fileType.ToFileExtension()}";
            qrCodeImage.Save(fileName, _fileType.ToImageFormat());
        }
    }
}
