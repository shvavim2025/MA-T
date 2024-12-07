using ForTestMhat;
//פונקציות בסיס
static void Print(Node<int> head)
{
    if (head == null)
    {
        Console.WriteLine(); return;
    }
    Console.Write(head + " ");
    Print(head.GetNext());
}
static void PrintEnd(Node<int> head)
{
    if (head == null)
    {
        Console.WriteLine(); return;
    }
    PrintEnd(head.GetNext());
    Console.Write(head + " ");

}
//delete the head
static Node<int> RemoveHead(Node<int> h) => h.GetNext();
//delete the head
static void RemoveItem(Node<int> head, int index)
{
    if (head == null) return;
    if (index - 1 == 1)//נעצר באיבר שאליו רוצים לחבר עוד חוליה  
    {
        head.SetNext(head.GetNext().GetNext());

        return;
    }
    RemoveItem(head.GetNext(), index - 1);
}
//add in the start of list
static Node<int> AddStart(int value, Node<int> head) => new Node<int>(value, head);
//add in the end of the list
static void AddEnd(int value, Node<int> head)
{
    if (!head.HasNext())//נעצר באחרון 
    {
        head.SetNext(new Node<int>(value));
        return;
    }
    AddEnd(value, head.GetNext());
}
static void AddMiddle(int index, int value, Node<int> head)
{
    if (head == null) return;
    if (index - 1 == 1)//נעצר באיבר שאליו רוצים לחבר עוד חוליה  
    {
        head.SetNext(new Node<int>(value, head.GetNext()));

        return;
    }
    AddMiddle(index - 1, value, head.GetNext());
}
//תרגול
static int f11(int value, Node<int> head)
{
    if (head == null) return 0;
    if (head.GetValue() == value) return 0;
    return 1 + f11(value, head.GetNext());

}
static int f11_end(int value, Node<int> head)
{
    //לגמור
    //עמוד 10 11
    return 0;

}
//13
static bool IsSuper(Node<int> node)
{
    return IsSuper1(node, 0);
    //int sum = 0;
    //while(node.HasNext())
    //{
    //    sum += node.GetValue();
    //    node = node.GetNext();
    //    if(sum>node.GetValue()) return false;    
    //}
    //return true;    
}
static bool IsSuper1(Node<int> node, int sum)
{
    if (node == null) return true;
    return sum < node.GetValue() && IsSuper1(node.GetNext(), sum + node.GetValue());
}
static bool AddToSuper(Node<int> node, int value)
{
    int sum = node.GetValue();
    while (node.HasNext() && node.GetNext().GetValue() < value)
    {
        node = node.GetNext();
        sum += node.GetValue();

    }
    if (sum >= value)
        return false;
    if (IsSuper1(node.GetNext(), sum + value))
    {
        node.SetNext(new Node<int>(value, node.GetNext()));
        return true;
    }
    return false;
}
//main
//Node<int> head = new Node<int>(10,new Node<int>(5,new Node<int>(7)));
//head.GetNext().GetNext().SetNext(new Node<int>(15));
//AddMiddle(3,20,head);   
//Print(head);
//Node<int> head1 = new Node<int>(1);
//AddEnd(3, head1);
//AddEnd(6, head1);
//AddEnd(13, head1);
//AddEnd(27, head1);
//AddEnd(300, head1);
//AddEnd(600, head1);
//Print(head1);
////Console.WriteLine(IsSuper(head1));
////Console.WriteLine(IsSuper1(head1, 0));
//if (AddToSuper(head1, 60))
//    Print(head1);
//else Console.WriteLine("error");


//סיבוכיות
/*
 * פונקציה א
 * לולאה שרצה פעם אחת על כל הרשימה סיבוכיות O)N(
 * כאשר N מסמן אורך רשימה
 * פונקציה ב
 * לולאה ראשונה רצה עד מיקום מסוים בלולאה 
 * לולאה שניה רצה ממיקום זה עד סוף הרשימה
 * סך הכל O)N(
 * 
 * 
 * */

#region Stack And Queue
static ForTestMhat.Stack<int> BuildSe(ForTestMhat.Stack<Series> s)
{
    ForTestMhat.Stack<Series> stack = new ForTestMhat.Stack<Series>();
    while (!s.IsEmpty())
    {
        stack.Push(s.Pop());
    }
    ForTestMhat.Stack<int> stack2 = new ForTestMhat.Stack<int>();
    while (!stack.IsEmpty())
    {
        int last = stack.Top().Last();
        for (int i = 0; i < stack.Top().Amount; i++)
        {
            stack2.Push(last);
            last -= stack.Top().Diff;
        }
        s.Push(stack.Pop());
    }
    return stack2;
}
static bool IsR(ForTestMhat.Queue<Series> q1)
{
    bool f = true;
    q1.Inseret(null);
    do
    {
        int l = q1.Head().Last();
        q1.Inseret(q1.Remove());
        if (q1.Head() != null && l != q1.Head().First)
            f = false;
    }
    while (f && q1.Head() != null);

    while (q1.Head() != null)
    {
        q1.Inseret(q1.Remove());
    }
    q1.Remove();//למחוק את הNull 
    return f;
}

ForTestMhat.Stack<Series> s = new ForTestMhat.Stack<Series>();
s.Push(new Series(17, -1, 5));
s.Push(new Series(12, 3, 4));
s.Push(new Series(21, -7, 2));
s.Push(new Series(14, 6, 4));
ForTestMhat.Stack<int> s1 = new ForTestMhat.Stack<int>();
s1 = BuildSe(s);
global::System.Console.WriteLine(s1);

#endregion
#region tree
static void BuildTree(int v, BinNode<int> x)
{

}

#endregion
#region revieForTest
#region ex.6
static int Sumleaves(BinNode<int> root)
{
    if (root == null) return 0;
    if (root.GetLeft() == null && root.GetRight() == null)
        return root.GetValue();
    return Sumleaves(root.GetLeft()) + Sumleaves(root.GetRight());
}
static int SumRights(BinNode<int> root)
{
    if (root == null) return 0;
    return root.GetRight() != null ? root.GetRight().GetValue() + SumRights(root.GetLeft())
        + SumRights(root.GetRight()) : SumRights(root.GetLeft());
}
static Node<int> createNewList(Node<BinNode<int>> list)
{
    Node<int> res, tail;
    int x = 0;
    if (list.GetValue() == null)
        return null;
    else
    {
        if (list.GetValue().GetValue() % 2 == 0)
            x = SumRights(list.GetValue());
        else
            x = Sumleaves(list.GetValue());
    }
    res = tail = new Node<int>(x);
    list =list.GetNext();
    while (list != null)
    {
        if (list.GetValue().GetValue() % 2 == 0)
            x = SumRights(list.GetValue());
        else
            x = Sumleaves(list.GetValue());
        tail.SetNext(new Node<int>(x));
        tail = tail.GetNext();
        list = list.GetNext();
    }
    return res;
}
#endregion
#region ex7
static void deletMax(BinNode<int> node,int max)
{
    if(node == null) return;
    if(node.GetRight() == null && node.GetLeft() == null&&node.GetValue()==max)
    {
        exChange(node, null);
        return;
    }
    if(node.GetLeft() != null&&node.GetLeft().GetValue()==max)
    {
        exChange(node, node.GetLeft());
        return;
    }
    if(node.GetRight() != null&& node.GetRight().GetValue() == max)
    {
        exChange(node, node.GetRight());
        return;
    }
    deletMax(node.GetLeft(), max);
    deletMax(node.GetRight(), max);
}
static void exChange(BinNode<int> node, BinNode<int>  value)
{
    if(node.GetLeft() == null&&node.GetRight()==null){
        value.SetValue(node.GetValue());
        node=null;
        return;
    }
    if (node.GetLeft() != null)
    {
        exChange(node.GetLeft(), value);
    }
    else
    {
        exChange(node.GetRight(), value);
    }
}
static void Extract_max(Node<ListMax> list)
{
    BinNode<int> tail, taill;
    while (list != null)
    {
        deletMax(list.GetValue().head, list.GetValue().valu);
        list = list.GetNext();
    }
}
#endregion
#region 1

static int[] Multiply(int[] arr1,in int[] arr2)
{
    int [] arrRes= new int[arr1.Length];
    int k= Math.Min(arr1.Length, arr2.Length);
    for(int i = 0; i < k; i++)
        arrRes[i]= arr1[i]*arr2[i];
    int[]arr=arr1.Length==k?arr1 : arr2;
    for (int i = k + 1; i < arr.Length; i++)
        arrRes[i] = arr[i];
    return arrRes;
}
#endregion
#region 2
static bool IsPerfect(int[] arr)
{
  bool flag = false;
    int count = 1,i=0,j;
    for ( i = 0; i < arr.Length; i++)
    {
        if (arr[i] == 0) { flag = true; break; }
    }
    if (flag)
    {
        i = 0;
        while (arr[i] != 0)
        {
            count++;
            j = arr[i];
            arr[i] = 0;
            i = j;
        }
        if(count!=arr.Length)
            flag = false;
    }
    return flag;
}
int[] arr = { 3, 0, 1, 4, 2 };
int[] arr2 = { 3, 4,1,5,6,0,2 };
//Console.WriteLine(IsPerfect(arr));
//Console.WriteLine(IsPerfect(arr2));

#endregion
#region 3
static bool IsIncluded(Node<int>lst1, Node<ForTestMhat.Range>lst2)
{
    while(lst2!=null&&lst1!=null)
    {
        if(lst1.GetValue()>=lst2.GetValue().Low && lst1.GetValue() <= lst2.GetValue().High)
            lst1=lst1.GetNext();
        else
        lst2=lst2.GetNext();
    }
    return lst1 == null;
}
// Create nodes for list 1 (integer values)
Node<int> node1 = new Node<int>(5);
Node<int> node2 = new Node<int>(10);
Node<int> node3 = new Node<int>(25);  // This value will not fit in the range
node1.SetNext(node2);
node2.SetNext(node3);

// Create nodes for list 2 (range values)
Node<ForTestMhat.Range> range1 = new Node<ForTestMhat.Range>(new ForTestMhat.Range(0, 15));  // This range doesn't include 25
Node<ForTestMhat.Range> range2 = new Node<ForTestMhat.Range>(new ForTestMhat.Range(20, 30));  // This range includes 25
range1.SetNext(range2);

// Test the IsIncluded function
bool result = IsIncluded(node1, range1);

Console.WriteLine($"Is lst1 included in lst2 ranges? {result}");
#endregion
#region 5
 static string Erase(string str)
{
    string res = "";
    for (int i = 1; i < str.Length; i++)
    {
        res += str[i];
    }
    return res;
}
static bool WordFromRoot(BinNode<char> tree,string str)
{
    if (str == "")
        return true;
    if(tree==null)
        return false;

    return tree.GetValue() == str[0] &&
        (WordFromRoot(tree.GetLeft(), Erase(str)) ||
        WordFromRoot(tree.GetRight(), Erase(str)));
}
#endregion
#region 7
static int SumQueue(ForTestMhat.Queue<int> q)
{
    int sum = 0;
    ForTestMhat.Stack<int> stack = new ForTestMhat.Stack<int>();
    while (!q.IsEmpty())
    {
        stack.Push(q.Remove());
        sum += stack.Top();
    }
    while (!stack.IsEmpty())
    {
        q.Inseret(stack.Pop());
    }
    return sum;
}
static int LastValue(ForTestMhat.Queue<int> q)
{
    ForTestMhat.Stack<int> stack = new ForTestMhat.Stack<int>();
    while (!q.IsEmpty())
    {
        stack.Push(q.Remove());
    }
    int x = stack.Top();
    while (!stack.IsEmpty())
    {
        q.Inseret(stack.Pop());
    }
    return x;
}

static ForTestMhat.Queue<int> func(Node<ForTestMhat.Queue<int>> node)
{
    ForTestMhat.Queue<int> res= new ForTestMhat.Queue<int>();
    while (node != null) {
        if (node.GetValue().Head() % 2 == 0)
            res.Inseret(LastValue(node.GetValue()));
        else {
        res.Inseret(SumQueue(node.GetValue()));
        }
        node=node.GetNext();

    }
    return res;
}
#endregion
#endregion

