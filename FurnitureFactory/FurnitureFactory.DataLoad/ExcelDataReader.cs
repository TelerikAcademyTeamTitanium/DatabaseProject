namespace FurnitureFactory.DataLoad
{
    using System;
    using System.IO;
    using System.Data;
    using System.Data.OleDb;
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
            Console.WriteLine(filePath);

            OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + filePath + ";Extended Properties=Excel 8.0;");

            OleDbDataAdapter da = new OleDbDataAdapter("select * from [Sheet1$]", con);

            DataSet ds = new DataSet();

            da.Fill(ds);
            for (int i = 0; i < ds.Tables.Count; i++)
            {
                for (int j = 0; j < ds.Tables[i].Rows.Count; j++)
                {
                    for (int z = 0; z < ds.Tables[i].Rows[j].ItemArray.Length; z++)
                    {
                        if (!ds.Tables[i].Rows[j].ItemArray[z].ToString().Equals(string.Empty))
                        {
                            Console.WriteLine(ds.Tables[i].Rows[j].ItemArray[z].ToString());
                        }                        
                    }
                }
            }
                con.Close();
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
                    //The first path to list here is the zip itself - we dont need it!
                    if (!currentFile.Extension.Equals(".zip"))
                    {
                        this.ReadExcelFile(currentFile.FullName);
                    }
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
