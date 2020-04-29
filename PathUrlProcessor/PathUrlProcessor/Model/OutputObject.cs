using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PathUrlProcessor.Model
{
    public class PathValueObject
    {
        public PathValueObject(string url, int  size)
        {
            Url = url;
            Size = size;
        }

        public string Url { get; set; }
        public int Size { get; set; }
    }
}
