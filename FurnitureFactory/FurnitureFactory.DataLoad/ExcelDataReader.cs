namespace FurnitureFactory.DataLoad
{
    using System;
    using System.IO;
    using System.Data;
    using System.Data.OleDb;
    using System.Collections.Generic;
    /// <summary>
    /// 
    /// </summary>
    public class ExcelDataReader : IFileReader
    {
        private List<DataSet> excelDataSet = new List<DataSet>();
        
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

        public List<DataSet> ExcelData 
        {
            get
            {
                return this.excelDataSet;
            }
            private set
            {
                this.excelDataSet = value;
            }
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
        private DataSet ReadExcelFile(string filePath)
        {
            Console.WriteLine(filePath);

            OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + filePath + ";Extended Properties='Excel 8.0;HDR=No;IMEX=1;';");
            con.Open(); 
            OleDbDataAdapter da = new OleDbDataAdapter("select * from [Sheet1$]", con);

            DataSet ds = new DataSet();

            da.Fill(ds);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++) 
             { 
                 for (int j = 0; j < ds.Tables[0].Columns.Count; j++) 
                 { 
                     Console.Write(ds.Tables[0].Rows[i][j].ToString() + ' '); 
                 } 
                 Console.WriteLine(); 
             } 

            con.Close();
            return ds;
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
                        excelDataSet.Add(this.ReadExcelFile(currentFile.FullName));
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
