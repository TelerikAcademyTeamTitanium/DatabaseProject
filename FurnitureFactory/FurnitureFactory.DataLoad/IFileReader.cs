namespace FurnitureFactory.DataLoad
{
    public interface IFileReader
    {
        void ReadFile(string path);

        bool CanLoadFile(string path);
    }
}
