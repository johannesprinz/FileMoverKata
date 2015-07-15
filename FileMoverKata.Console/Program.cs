﻿using System;
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
        IDirectoryProvider directoryProvider;

        public FileMover(IDirectoryProvider directoryProvider = null)
        {
            if (directoryProvider == null)
                this.directoryProvider = new DirectoryProvider();
            else this.directoryProvider = directoryProvider;
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

    internal class DirectoryProvider : IDirectoryProvider
    {
        public string[] GetFiles (string source, string filter)
        {
            return Directory.GetFiles(source, filter);
        }
    }
}
