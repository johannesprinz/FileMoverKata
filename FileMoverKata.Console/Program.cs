using System;
using System.IO;

namespace FileMoverKata.Console
{
    class Program
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

    internal class FileMover
    {
        public void MoveFiles(string source, string target, string filter)
        {
            string[] logFiles = Directory.GetFiles(source, filter);

            foreach (var file in logFiles)
            {
                if (File.GetLastWriteTime(file) < DateTime.Now - TimeSpan.FromDays(1))
                    File.Move(file, Path.Combine(target, Path.GetFileName(file)));
            }
        }
    }
}
