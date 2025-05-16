using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPsl.Decorator
{
    public class DefaultFormatter : ITextFormatter
    {
        public string Format(string text) => text;
    }

}
