using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForTestMhat
{
    internal class Stack<T>
    {
    private    Node<T> node;
        public Stack()
        {

        }
        public void Push(T value)
        {
            node = new Node<T>(value, node);
        }
        public T Pop()
        {
            T value=node.GetValue();
            node=node.GetNext();
            return value;
        }
        public T Top()=>node.GetValue();
        public bool IsEmpty() => node == null;
        public override string ToString()
        {
            string str="";
            Node<T> h = node;
                while (h != null)
            {
                str += h+" ";
                h=h.GetNext();
            }
                return str; 
        }
    }
}
