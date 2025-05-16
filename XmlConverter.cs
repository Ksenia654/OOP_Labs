using System.Xml.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOPsl.DocumentFunctions;

namespace OOPsl.Adapter
{
    public class XmlConverter : IDocumentConverter
    {
        public string Convert(Document doc)
        {
            var docXml = new XDocument(
                new XElement("Document",
                    new XElement("FileName", doc.FileName),
                    new XElement("Content", doc.Content),
                    new XElement("VersionHistory",
                        doc.VersionHistory.Select(version => new XElement("Version", version))
                    )
                )
            );
            return docXml.ToString();
        }

        public void SaveToFile(Document doc, string filePath)
        {
            string baseName = Path.GetFileName(filePath).Split('.')[0];
            string directory = Path.GetDirectoryName(filePath);
            string newPath = Path.Combine(directory, baseName + ".xml");
            File.WriteAllText(newPath, Convert(doc));
        }
    }
}
