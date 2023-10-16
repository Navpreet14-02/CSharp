using System.Collections;
using System.Text;

public class A
{

    //public string name;
    public A()
    {
        Console.WriteLine("Class A constructor");
    }

    public void ab()
    {
        Console.WriteLine("Class A function");
    }
     

}
internal class Program


{

    public class B : A
    {
        public B() => Console.WriteLine("Class B constructor");

        public void abfunc()
        {
            Console.WriteLine("Class B Functions");
        }
    }

    private static void Main(string[] args)
    {
        int[] nums = new int[] { 1, 2, 3, 4, 5 };

        Object[] arr = new Object[] { 1, "Navi", 'a',new int[] {1,2,3,4 }};


        B bobj = new B();

        A aobj = bobj;
        //if(aobj is B b)
        //{
        //    b.abfunc();
        //}

        B obj2 = aobj as B;
        if (obj2 != null)
        {
            obj2.abfunc();
        }

        //A obj = new A(2,4);

        //int[,] multiArr = new int[2, 3];
        //=============== Arrays ===================


        //Console.WriteLine("Length: {0}", arr.Length);

        // IndexOf()

        //var index = Array.IndexOf(arr, 'a');
        //Console.WriteLine("Index of 4: {0}",index);

        ////Clear
        //Array.Clear(nums, 0, 2);
        //foreach(int i in nums) Console.Write(i);

        //Console.WriteLine();
        //// copy
        //int[] copyArr = new int[3];
        //Array.Copy(nums, copyArr, 3);
        //foreach (int i in copyArr) Console.Write(i);

        //// Sort
        //Console.WriteLine();
        //Array.Sort(nums);
        //foreach (int i in nums) Console.Write(i);

        //// Reverse
        //Console.WriteLine();
        //Array.Reverse(nums);
        //foreach (int i in nums) Console.Write(i);

        //Object nums2 = (int[])arr[3];

        //Console.WriteLine(((int[])arr[3])[1]);
        //Console.WriteLine(nums[1]);

        // =============== Lists =====================
        //var numList = new List<int>(); //{ 1, 5, 4, 3, 2 };
        //numList.Add(10);
        //numList.Add(20);
        //numList.Add(30);
        //numList[2] = 2;
        //Console.WriteLine(numList.Capacity);
        //numList.TrimExcess();
        //Console.WriteLine(numList.Count);
        //Console.WriteLine(numList.Capacity);


        //numList.AddRange(new int[8] {24,35,47,12,1,2,12,12});
        //numList.RemoveAll(x => x==12);
        //numList.in
        //foreach (int i in numList) Console.Write(i);

        //foreach(var num in numList) Console.WriteLine(num);

        //Console.WriteLine( numList.IndexOf(35));
        //Console.WriteLine(numList.LastIndexOf(1));

        //Console.WriteLine(numList.Count);

        //numList.Remove(1);
        //foreach (var num in numList) Console.WriteLine(num);

        //// If we want to remove all occurrences of an element, we should use for loop

        //numList.Clear();
        //Console.WriteLine(numList.Count);

        // ArrayList 

        ArrayList al = new ArrayList();
        al.Add(1);
        al.Add("Navi");
        al.Add('c');
        al.Add(3);
        al.Add(4);
        //Console.WriteLine(al.Count);
        //Console.WriteLine(al.Capacity);
        //al.TrimToSize();
        //Console.WriteLine(al.Count);
        //Console.WriteLine(al.Capacity);

        //Console.WriteLine(al.Count);
        //Console.WriteLine(al.Capacity);
        ////al.TrimToSize();
        //Console.WriteLine(al.Count);
        //Console.WriteLine(al.Capacity);

        //al.Add(new int[] { 1, 2, 3}) ;

        //foreach(var num in al) Console.WriteLine(num);

        //Console.WriteLine(al.Capacity);


        //Console.WriteLine(((int[])al[3])[2]);


        // =============== StringBuilder =================

        //StringBuilder sb = new StringBuilder("Hello");


        //sb
        //  .Append('-', 10)
        //  .AppendLine()
        //  .Append("Header")
        //  .AppendLine()
        //  .Append('-', 10);

        //IComparable

        //sb.ToString().CompareTo
        //sb.AppendJoin(',', 1, 2, 3, 4);

        //Stream s = new MemoryStream();
        //sb[3] = 'x';
        //Console.WriteLine(sb);
        //sb.Replace('-', '+');
        //sb.Remove(0, 10);
        //sb.Insert(0, new string('-', 10));

        //Console.WriteLine(sb);

        //File
    }
}