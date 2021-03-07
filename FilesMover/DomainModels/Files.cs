using System;
namespace FilesMover.DomainModels
{
    public class Files
    {
        public Files()
        {
        }

        public string FileName { set; get; }

        public long FileSize { set; get; }

        public string FileLocation { set; get; }

        public FileType FileType { set; get; }
    }
}
