namespace FurnitureFactory.DataLoad
{
    using System.IO;
    using System.IO.Compression;

    class ZipFileReader : IFileReader
    {
        private ZipFileReader()
        {
        }

        public string ZipFilePath { get; private set; }

        public static ZipFileReader Create()
        {
            return new ZipFileReader();
        }

        public void ReadFile(string path)
        {
            if (this.TryLoadFile(path))
            {
                this.ZipFilePath = path;

                ZipArchive zip = ZipFile.OpenRead(this.ZipFilePath);

                foreach (ZipArchiveEntry entry in zip.Entries)
                {
                    if (Path.GetFileName(entry.FullName).Equals(string.Empty))
                    {
                        zip.ExtractToDirectory(Directory.GetCurrentDirectory());
                    }
                }
            }
        }

        public bool TryLoadFile(string path)
        {
            if (!File.Exists(path))
            {
                throw new FileNotFoundException("Invalid file path!");
            }

            if (!Path.GetExtension(path).Equals(".zip"))
            {
                throw new FileLoadException("Provided file is not a zip archive!");
            }

            return true;
        }
    }
}
