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

            }
        }
    }
}
