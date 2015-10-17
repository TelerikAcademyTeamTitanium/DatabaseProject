namespace FurnitureFactory.DataLoad
{
    public interface IFileReader
    {
        void ReadFile(string path);

        bool CanLoad(string path);
    }
}
