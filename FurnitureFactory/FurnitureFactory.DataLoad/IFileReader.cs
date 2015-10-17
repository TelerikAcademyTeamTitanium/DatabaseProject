namespace FurnitureFactory.DataLoad
{
    public interface IFileReader
    {
        void ReadFile(string path);

        bool TryLoadFile(string path);
    }
}
