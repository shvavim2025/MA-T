using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForTestMhat
{
    internal class BinNode<T>
    {
        BinNode<T> right,left;
        T value;

        public BinNode(T value,BinNode<T> right, BinNode<T> left )
        {
            this.right = right;
            this.left = left;
            this.value = value;
        }

        public BinNode(T value)
        {
            this.value = value;
        }

        public BinNode<T> GetRight()=>right;
        public BinNode<T> GetLeft() => left;
        public T GetValue() => value;
        public void SetLeft(BinNode<T> l) => left = l;
        public void SetRight(BinNode<T> r) => right = r;
        public void SetValue(T v)=>value = v;
        public bool HasRight()=>right!=null;
        public bool HasLeft()=>left!=null;


    }
}
