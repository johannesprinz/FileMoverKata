namespace FileMoverKata.Console
{
    public interface IDirectoryProvider
    {
        string[] GetFiles(string path, string filter);
    }
}