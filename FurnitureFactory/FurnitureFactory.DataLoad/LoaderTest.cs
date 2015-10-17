namespace FurnitureFactory.DataLoad
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class LoaderTest
    {
        public static void Main()
        {
            string zipFilePath = "../../../../ExcelTables/test.zip";
            FileInfo info = new FileInfo(zipFilePath);
            ZipFileReader zipReader = ZipFileReader.Create();
            zipReader.ReadFile(zipFilePath);
            ExcelDataReader excelReader = ExcelDataReader.Create();
            excelReader.ReadFile(info.DirectoryName);
        }
    }
}
