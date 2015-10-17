namespace FurnitureFactory.DataLoad
{
    using System;
    using System.IO;
    using System.IO.Compression;
    using System.Linq;

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
                        var temp = entry.FullName.Split('/');
                        this.ValidateFolderName(temp[temp.Length-2]);
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

        private void ValidateFolderName(string input)
        {
            string[] months = { "JAN", "FEB", "MAR", "APR", "MAY", "JUN", "JUL", "AUG", "SEP", "OCT", "NOV", "DEC"};
            var date = input.Split('-').ToArray();
            if (months.Contains(date[1])){
                Console.WriteLine("Month validated!");
            }
        }
    }
}
