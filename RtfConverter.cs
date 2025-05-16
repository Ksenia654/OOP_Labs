using OOPsl.DocumentFunctions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPsl.Adapter
{
    public class RtfConverter : IDocumentConverter
    {
        public string Convert(Document doc)
        {
            // Генерируем RTF вручную
            return $@"{{\rtf1\ansi\deff0 {{\fonttbl {{\f0 Arial;}}}} \f0 {doc.Content} }}";
        }

        public void SaveToFile(Document doc, string filePath)
        {
            string rtfText = Convert(doc);
            string baseName = Path.GetFileName(filePath).Split('.')[0];
            string directory = Path.GetDirectoryName(filePath);
            string newPath = Path.Combine(directory, baseName + ".rtf");
            File.WriteAllText(newPath, rtfText);
        }
    }

}
