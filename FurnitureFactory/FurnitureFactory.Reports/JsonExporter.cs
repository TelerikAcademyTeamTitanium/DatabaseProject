namespace FurnitureFactory.Reports
{
    using System.Collections.Generic;
    using System.IO;

    using Newtonsoft.Json;
    using Objects;

    public class JsonExporter : FileExporter
    {
        public JsonExporter(string outputPath, IList<Product> data)
            : base(outputPath, data)
        {
        }

        public override void Export()
        {
            foreach (var item in this.Data)
            {
                var serializedProduct = JsonConvert.SerializeObject(item, Formatting.Indented);
                string fileName = item.Id + ".json";
                File.WriteAllText(this.OutputPath + fileName, serializedProduct);
            }
        }
    }
}