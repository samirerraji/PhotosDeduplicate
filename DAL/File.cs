using System;
using System.IO;
namespace PhotosDeduplicate.DAL
{
    public class File
    {
        public File()
        {

        }
        public File(string path) : this(new FileInfo(path))
        {

        }
        public File(FileInfo path)
        {
            Path = path.FullName;
            Size = path.Length;
            LastChange = path.LastWriteTime;
            Created = path.CreationTime;
        }
        public int FileId { get; set; }
        public string? Path { get; set; }
        public long Size { get; set; }

        public string? CheckSum { get; set; }
        public DateTime LastChange { get; set; }
        public DateTime Created { get; set; }
    }
}