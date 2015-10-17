namespace FurnitureFactory.DataLoad
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class LoaderTest
    {
        public static void Main()
        {
            ZipFileReader zipReader = ZipFileReader.Create();
            zipReader.ReadFile("exam.zip");
        }
    }
}
