namespace FurnitureFactory.Reports
{
    using System.Collections.Generic;
    using System.IO;

    using Newtonsoft.Json;
    using Model;
    using Exporter.Models;

    public class JsonExporter : FileExporter
    {
        public const string DefaultOutputPath = "../../../../Exports/Json/";
        public JsonExporter(string outputPath, IList<ProductParse> data)
            : base(outputPath, data)
        {
        }

        public override void Export()
        {
            foreach (var item in this.Data)
            {
                var serializedProduct = JsonConvert.SerializeObject(item, Formatting.Indented);
                string fileName = "product" + item.ProductId + ".json";
                File.WriteAllText(this.OutputPath + fileName, serializedProduct);
            }
        }
    }
}