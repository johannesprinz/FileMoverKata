using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileMoverKata.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] logFiles = Directory.GetFiles(@"C:\SourceDirectory", "*.log");

            foreach (var file in logFiles)
            {
                if (File.GetLastWriteTime(file) < DateTime.Now - TimeSpan.FromDays(1))
                    File.Move(file, Path.Combine(@"C:\TargetDirectory", Path.GetFileName(file)));
            }
        }
    }
}
