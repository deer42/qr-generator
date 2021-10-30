namespace QrGenerator.Abstract
{
    public record QrOptions
    {        
        public string SourceFilePath { get; set; }
        
        public string DestinationDirectoryPath { get; set; }
                
        public DestinationFileType DestinationFileType { get; set; }
                
        public int PixelsPerModule { get; set; }
                
        public bool SkipHeader { get; set; }
                
        public string Format { get; set; }

        public bool RunInParallel { get; set; }
    }
}
