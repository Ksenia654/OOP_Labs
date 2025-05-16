using OOPsl.DocumentFunctions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPsl.Adapter
{
    public class MarkdownConverter : IDocumentConverter
    {
        public string Convert(Document doc)
        {
            return $"# {doc.FileName}\n\n{doc.Content}";
        }

        public void SaveToFile(Document doc, string filePath)
        {
            string baseName = Path.GetFileName(filePath).Split('.')[0];
            string directory = Path.GetDirectoryName(filePath);
            string newPath = Path.Combine(directory, baseName + ".md");
            File.WriteAllText(newPath, Convert(doc));
        }
    }
}
