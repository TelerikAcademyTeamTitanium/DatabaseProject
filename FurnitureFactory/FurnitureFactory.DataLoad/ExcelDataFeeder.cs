namespace FurnitureFactory.DataLoad
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class ExcelDataReader : IFileReader
    {
        public bool CanLoad(string directoryPath)
        {
            if (!Directory.Exists(directoryPath))
            {
                throw new FileNotFoundException("Invalid directory path!");
            }

            if (Directory.GetFiles(directoryPath).Length == 0)
            {
                throw new FileLoadException("Provided directory is empty!");
            }

            return true;
        }

        public void ReadFile(string directoryPath)
        {
            if (this.CanLoad(directoryPath))
            {
                DirectoryInfo currentPathInfo = new DirectoryInfo(directoryPath);
                RecursiveDirectoryCrawler(currentPathInfo);
            }
        }

        private void RecursiveDirectoryCrawler(DirectoryInfo root)
        {
            FileInfo[] files = null;

            DirectoryInfo[] subDirs = null;

            try
            {
                files = root.GetFiles("*.*");
            }   
            catch (DirectoryNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }

            if (files != null)
            {
                foreach (FileInfo fi in files)
                {
                    Console.WriteLine(fi.FullName);
                }

                subDirs = root.GetDirectories();

                foreach (DirectoryInfo dirInfo in subDirs)
                {
                    RecursiveDirectoryCrawler(dirInfo);
                }
            }
        }
    }
}
