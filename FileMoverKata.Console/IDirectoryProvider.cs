namespace FileMoverKata.Console
{
    public interface IDirectoryProvider
    {
        string[] GetFiles(string source, string filter);
    }
}