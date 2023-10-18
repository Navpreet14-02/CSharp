

//================== DELEGATE ===================
// An object that knows how to call a method(or a group of methods)
// A reference to a function with a particular parameter list and return type.
// Why? - For designing extensible and flexible apps (eg frameworks)



// Use a Delegate when:
// The caller doesn't need to access other properties or methods on the object implementing the method.

internal class Program
{

    public delegate int MathOperations(int a, int b);


    public int sum(int a, int b)
    {
        return (a+b);
    }
    public int sub(int a, int b)
    {
        return (a - b);

    }
    public int mul(int a,int b)
    {
        return (a * b);

    }
    public int divide(int a,int b)
    {
        return (a / b);

    }


    private static void Main(string[] args)
    {


        Program obj = new Program();
        MathOperations DObj = new MathOperations(obj.sum);
      

        DObj += new MathOperations(obj.sub);
        DObj += new MathOperations(obj.mul);
        DObj += new MathOperations(obj.divide);

        //Delegate[] arr = DObj.GetInvocationList();
        

        int arr = DObj(10,5);

        //Console.WriteLine(DObj.Invoke(6, 5));
        //Console.WriteLine(DObj.Invoke(6, 5));


        // We have two inbuilt delegates in c# :
        //System.Action<> points to a method that returns void
        //System.Func<> points to a method that returns value
    }
}