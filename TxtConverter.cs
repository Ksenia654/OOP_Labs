using OOPsl.DocumentFunctions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPsl.Adapter
{
    public class TxtConverter : IDocumentConverter
    {
        public string Convert(Document doc)
        {
            return doc.Content;
        }

        public void SaveToFile(Document doc, string filePath)
        {
            string baseName = Path.GetFileName(filePath).Split('.')[0];
            string directory = Path.GetDirectoryName(filePath);
            string newPath = Path.Combine(directory, baseName + ".txt"); 
            File.WriteAllText(newPath, Convert(doc));
        }
    }
}
