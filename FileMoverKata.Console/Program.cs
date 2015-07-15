using System;
using System.IO;

namespace FileMoverKata.Console
{
   public class Program
    {
        static void Main(string[] args)
        {
            var source = @"C:\SourceDirectory";
            var target = @"C:\TargetDirectory";
            var filter = "*.log";
            var fileMover = new FileMover();
            fileMover.MoveFiles(source, target, filter);
        }
    }

    public class FileMover
    {
        IDirectoryProvider directoryProvider;
        IFileProvider fileProvider;

        public FileMover(IDirectoryProvider directoryProvider = null, IFileProvider fileProvider = null)
        {
            this.directoryProvider = directoryProvider ?? new DirectoryProvider();
            this.fileProvider = fileProvider ?? new FileProvider(); 
        }
        public void MoveFiles(string source, string target, string filter)
        {
            string[] logFiles = directoryProvider.GetFiles(source, filter);

            foreach (var file in logFiles)
            {
                if (File.GetLastWriteTime(file) < DateTime.Now - TimeSpan.FromDays(1))
                    File.Move(file, Path.Combine(target, Path.GetFileName(file)));
            }
        }
    }

    public class DirectoryProvider : IDirectoryProvider
    {
        public string[] GetFiles (string source, string filter)
        {
            return Directory.GetFiles(source, filter);
        }
    }

    public class FileProvider : IFileProvider
    {
        public DateTime GetLastWriteTime(string file)
        {
            return File.GetLastWriteTime(file);
        }

        public void Move(string sourceFile, string targetFile)
        {
            File.Move(sourceFile, targetFile);
        }
    }
}
