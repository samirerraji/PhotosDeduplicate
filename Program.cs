using System;
using System.IO;
using System.Linq;

namespace PhotosDeduplicate
{
    public class Program
    {
        public static async void Main(string[] args)
        {
            var dirInfo = new DirectoryInfo(Environment.CurrentDirectory);
            var sampleDir = dirInfo.EnumerateDirectories("Sample").FirstOrDefault();
            if (sampleDir != null)
            {
                using (var db = new DAL.Context())
                {
                    foreach (var folder in sampleDir.EnumerateDirectories())
                    {
                        foreach (var file in folder.EnumerateFileSystemInfos("*", SearchOption.AllDirectories))
                        {
                            var info = file as FileInfo;
                            if (info == null)
                                continue;
                            db.Add(new DAL.File(info));
                            await db.SaveChangesAsync();
                        }

                    }

                }
            }
        }
    }
}