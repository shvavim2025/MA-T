using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForTestMhat
{
    internal class TwoStack
    {
        public Stack<int> numbers { get; set; }
        public Stack<int> sums { get; set; }
        public TwoStack() { }
        public Stack<int> GetNums(int x)
        {
            Stack<int> res = new Stack<int>();
            Stack<int> temp = new Stack<int>();
            while (sums.Top() != x)
            {
                temp.Push(numbers.Pop());
                sums.Pop();
            }
            while (!sums.IsEmpty())
            {

                res.Push(numbers.Top());
                temp.Push(numbers.Pop());
                sums.Pop();
            }
            sums.Push(temp.Top());
            numbers.Push(temp.Pop());
            while (!temp.IsEmpty())
            {
                numbers.Push(temp.Pop());
                sums.Push(sums.Top()+numbers.Top());
            }
            return res;
        }
        public void EraseNum(int x)
        {
            Stack<int> temp = new Stack<int>();
            while (!numbers.IsEmpty())
            {
                if (numbers.Top() != x)
                    temp.Push(numbers.Pop());
                else
                {
                    numbers.Pop();
                }
                sums.Pop();
            }
            numbers.Push(temp.Top());
            sums.Push(temp.Pop());
            while (!temp.IsEmpty())
            {
                numbers.Push(temp.Pop());
                sums.Push(numbers.Top() + sums.Top());
            }
        }
        
       
    }
}
