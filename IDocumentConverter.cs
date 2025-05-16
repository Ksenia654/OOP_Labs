using OOPsl.DocumentFunctions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPsl.Adapter
{
    interface IDocumentConverter
    {
        string Convert(Document doc);
        void SaveToFile(Document doc, string filePath);
    }
}
