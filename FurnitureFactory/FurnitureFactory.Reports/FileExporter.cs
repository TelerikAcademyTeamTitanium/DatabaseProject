namespace FurnitureFactory.Reports
{
    using System.Collections.Generic;

    using FurnitureFactory.Reports.Objects;

    public abstract class FileExporter
    {
        public FileExporter(string outputPath, IList<Product> data)
        {
            this.OutputPath = outputPath;
            this.Data = new List<Product>(data);
        }

        // TODO add validation
        public string OutputPath { get; set; }

        public IList<Product> Data { get; set; }

        public abstract void Export();
    }
}
