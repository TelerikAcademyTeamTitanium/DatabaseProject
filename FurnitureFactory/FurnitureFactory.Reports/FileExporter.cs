namespace FurnitureFactory.Reports
{
    using System.Collections.Generic;
    using System.IO;

    using FurnitureFactory.Reports.Objects;

    public abstract class FileExporter
    {
        private string outputPath;

        public FileExporter(string outputPath, IList<Product> data)
        {
            this.OutputPath = outputPath;
            this.Data = new List<Product>(data);
        }

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

        public IList<Product> Data { get; set; }

        public abstract void Export();
    }
}