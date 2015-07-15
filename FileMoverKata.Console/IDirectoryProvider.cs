namespace FileMoverKata.Console
{
    internal interface IDirectoryProvider
    {
        string[] GetFiles(string source, string filter);
    }
}