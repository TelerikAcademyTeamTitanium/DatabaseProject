﻿namespace FurnitureFactory.DataLoad
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.IO.Compression;
    using System.Linq;
    using System.Threading.Tasks;
    /// <summary>
    /// 
    /// </summary>
    public class ZipFileReader : IFileReader
    {
        private ZipFileReader()
        {
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static ZipFileReader Create()
        {
            return new ZipFileReader();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        public async void ReadFile(string path)
        {
            if (this.CanLoad(path))
            {
                FileInfo info = new FileInfo(path);
                ZipArchive zip = ZipFile.OpenRead(path);

                foreach (ZipArchiveEntry entry in zip.Entries)
                {
                    if (Path.GetFileName(entry.FullName).Equals(string.Empty))
                    {
                        var temp = entry.FullName.Split('/');
                        this.ValidateDirectoryName(temp[temp.Length - 2]);
                    }
                }
                //Currently not async not working!
                //await Task.Run(() => zip.ExtractToDirectory(info.Directory.ToString()));
                zip.ExtractToDirectory(info.DirectoryName);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public bool CanLoad(string path)
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

        private void ValidateDirectoryName(string dateToValidate)
        {
            try
            {
                DateTime.Parse(dateToValidate).ToString("dd-MMM-yyyy", CultureInfo.InvariantCulture);
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid Folder Name format at {0}!", dateToValidate);
            }
        }
    }
}
