using Newtonsoft.Json;
using OOPsl.DocumentFunctions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPsl.Adapter
{
    public class JsonConverter : IDocumentConverter
    {
        public string Convert(Document doc)
        {
            return JsonConvert.SerializeObject(doc, Formatting.Indented);
        }

        public void SaveToFile(Document doc, string filePath)
        {
            string baseName = Path.GetFileName(filePath).Split('.')[0];
            string directory = Path.GetDirectoryName(filePath);
            string newPath = Path.Combine(directory, baseName + ".json");
            File.WriteAllText(newPath, Convert(doc));
        }
    }
}
