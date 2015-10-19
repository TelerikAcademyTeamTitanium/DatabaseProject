namespace FurnitureFactory.XmlReporter
{
    using System.Collections.Generic;
    using System.IO;

    using FurnitureFactory.XmlReporter.Objects;

    public abstract class FileExporter
    {
<<<<<<< HEAD
        protected FileExporter()
=======
        private string outputPath;

        protected FileExporter(string outputPath, IList<Orders> data)
>>>>>>> origin/master
        {
        }
<<<<<<< HEAD
=======

        public string OutputPath
        {
            get
            {
                return this.outputPath;
            }
            set
            {
                if (!Directory.Exists(value))
                {
                    throw new DirectoryNotFoundException(string.Format("{0} not found.", value));
                }

                this.outputPath = value;
            }
        }
>>>>>>> origin/master

        public abstract void ExportOrders();
    }
}
