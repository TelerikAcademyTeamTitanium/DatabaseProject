namespace FurnitureFactory.XmlReporter
{
    using System.Collections.Generic;
    using FurnitureFactory.XmlReporter.Objects;

    public abstract class FileExporter
    {
        protected FileExporter()
        {
        }

        public abstract void ExportOrders();
    }
}
