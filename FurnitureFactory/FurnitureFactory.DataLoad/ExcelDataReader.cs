namespace FurnitureFactory.DataLoad
{
    using System;
    using System.IO;

    /// <summary>
    /// 
    /// </summary>
    public class ExcelDataReader : IFileReader
    {
        private ExcelDataReader()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static ExcelDataReader Create()
        {
            return new ExcelDataReader();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="directoryPath"></param>
        /// <returns></returns>
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="directoryPath"></param>
        public void ReadFile(string directoryPath)
        {
            if (this.CanLoad(directoryPath))
            {
                DirectoryInfo currentPathInfo = new DirectoryInfo(directoryPath);
                RecursiveDirectoryCrawler(currentPathInfo);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filePath"></param>
        private void ReadExcelFile(string filePath)
        {
            foreach (var worksheet in Workbook.Worksheets(filePath))
            {
                foreach (var row in worksheet.Rows)
                {
                    foreach (var cell in row.Cells)
                    {
                        //Do some logic here.
                    }
                }
            }
        }

        // Method that recursively walks through a directory tree from a given path.
        private void RecursiveDirectoryCrawler(DirectoryInfo root)
        {
            FileInfo[] filesToBeLoaded = null;

            DirectoryInfo[] rootSubDirectories = null;

            try
            {
                filesToBeLoaded = root.GetFiles("*.*");
            }
            catch (DirectoryNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }

            if (filesToBeLoaded != null)
            {
                foreach (FileInfo currentFile in filesToBeLoaded)
                {
                    this.ReadExcelFile(currentFile.FullName);
                }

                rootSubDirectories = root.GetDirectories();

                foreach (DirectoryInfo dirInfo in rootSubDirectories)
                {
                    this.RecursiveDirectoryCrawler(dirInfo);
                }
            }
        }
    }
}
