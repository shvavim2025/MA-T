using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForTestMhat
{
    internal class MyNode
    {
        public int Value { get; set; }
        public int HowManyBig { get; set; }
        public MyNode Next { get; set; }

        public MyNode(int value)
        {
            Value = value;
        }
    }
}
