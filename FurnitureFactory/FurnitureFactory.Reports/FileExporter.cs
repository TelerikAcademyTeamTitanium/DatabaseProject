namespace FurnitureFactory.Reports
{
    using System.Collections.Generic;
    using System.IO;
    using Model;
    using Exporter.Models;

    public abstract class FileExporter
    {
        private string outputPath;

        public FileExporter(string outputPath, IList<ProductParse> data)
        {
            this.OutputPath = outputPath;
            this.Data = new List<ProductParse>(data);
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

        public IList<ProductParse> Data { get; set; }

        public abstract void Export();
    }
}