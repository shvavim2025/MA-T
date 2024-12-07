using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForTestMhat
{
    internal class Series
    {
        public int First { get; set; }
        public int Amount { get; set; }
        public int Diff { get; set; }
        public Series(int a, int b, int c)
        {
            First = a;
                        Diff = b;
            Amount = c;
        }
        public int Last() => First + (Amount - 1) * Diff;

    }
}
