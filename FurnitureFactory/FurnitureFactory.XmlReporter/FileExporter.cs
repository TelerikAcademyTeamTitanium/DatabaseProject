namespace FurnitureFactory.XmlReporter
{
    using System.Collections.Generic;
    using FurnitureFactory.XmlReporter.Objects;

    public abstract class FileExporter
    {
        protected FileExporter(string outputPath, IList<Orders> data)
        {
            this.OutputPath = outputPath;
            this.Data = new List<Orders>(data);
        }
        
        public string OutputPath { get; set; }

        public IList<Orders> Data { get; set; }

        public abstract void Export();
    }
}
