using System;

namespace FileMoverKata.Console
{
    public interface IFileProvider
    {
        DateTime GetLastWriteTime(string file);
        void Move(string sourceFile, string targetFile);
    }
}