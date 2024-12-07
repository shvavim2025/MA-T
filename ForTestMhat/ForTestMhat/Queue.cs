using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForTestMhat
{
    internal class Queue<T>
    {
        Node<T> start, end;
        public void Inseret(T value)
        {
            if(start == null)
            {
                start=end = new Node<T>(value);
            }
            else
            {
                end.SetNext(new Node<T>(value));
                end=end.GetNext();
            }
        }
        public T Remove()
        {
            T value= start.GetValue();
            start=start.GetNext();  
            return value;
        }
        public T Head()=>start.GetValue();
        public bool IsEmpty() => start == null;
        public override string ToString()
        {
            string str = "";
            Node<T> h = start;
            while (h != null)
            {
                str += h;
                h = h.GetNext();
            }
            return str;
        }
    }
}
