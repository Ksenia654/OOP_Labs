using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPsl.Decorator
{
    public class ItalicFormatter : ITextFormatter
    {
        private ITextFormatter wrappedFormatter; 

        public ItalicFormatter(ITextFormatter formatter)
        {
            wrappedFormatter = formatter;
        }

        public string Format(string text)
        {
            return $"*{wrappedFormatter.Format(text)}*"; 
        }
    }

}
