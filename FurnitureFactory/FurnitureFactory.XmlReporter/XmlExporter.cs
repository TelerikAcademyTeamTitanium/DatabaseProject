namespace FurnitureFactory.XmlReporter
{
    using System.Xml.Linq;
    using System.Collections.Generic;
    using FurnitureFactory.XmlReporter.Objects;

    public class XmlExporter : FileExporter
    {
        public XmlExporter(string outputPath, IList<Orders> data)
            : base(outputPath, data)
        { 
        }

        public override void Export()
        {
            foreach (Orders order in this.Data)
            {
                XElement report =
                    new XElement("sales",
                        new XElement("sale", new XAttribute("client", order.Client), 
                        new XElement("summary", 
                            new XAttribute("dueDate", order.DueData),
                            new XAttribute("status", order.Status))));

                report.Save(this.OutputPath);
            }
        }
    }
}
