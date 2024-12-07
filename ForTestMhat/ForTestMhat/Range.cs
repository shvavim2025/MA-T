using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForTestMhat
{
    class Range
    {
        public Range(int l,int h)
        {
            this.High = h;
            this.Low = l;
        }

        public int  Low { get; set; }
        public int High { get; set; }

    }
}
