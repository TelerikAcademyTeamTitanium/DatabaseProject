namespace FurnitureFactory.XmlReporter
{
    using System.Collections.Generic;
    using System.IO;

    using FurnitureFactory.XmlReporter.Objects;

    public abstract class FileExporter
    {
        private string outputPath;

        protected FileExporter(string outputPath, IList<Orders> data)
        {
            this.OutputPath = outputPath;
            this.Data = new List<Orders>(data);
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

        public IList<Orders> Data { get; set; }

        public abstract void Export();
    }
}
