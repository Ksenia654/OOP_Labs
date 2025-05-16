using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPsl.Decorator
{
    public class HeaderFormatter : ITextFormatter
    {
        private ITextFormatter wrappedFormatter; 
        private int level;

        public HeaderFormatter(ITextFormatter formatter, int level)
        {
            wrappedFormatter = formatter;
            this.level = level;
        }

        public string Format(string text)
        {
            return $"{new string('#', level)} {wrappedFormatter.Format(text)}"; 
        }
    }

}
