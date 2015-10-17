namespace FurnitureFactory.DataLoad
{
    /// <summary>
    /// IFileReader is an interface that gives two basic methods:
    ///     - ReadFile(string path)
    ///     - CanLoad(string path)
    /// </summary>
    public interface IFileReader
    {
        void ReadFile(string path);

        bool CanLoad(string path);
    }
}
