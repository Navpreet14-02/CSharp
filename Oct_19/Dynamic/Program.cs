


// Type Resolution
// Static Languages: at compile-time
// Dynamic Languages: at run-time

// Reflection : A way to inspect the metadata about the type, and access properties and methods.


internal class Program
{


    public dynamic Func(int a, dynamic b) { return 1; }
    private static void Main(string[] args)
    {
        object obj = "Navi";
        //obj.GetHashCode();


        // Reflection 
        //var methodInfo = obj.GetType().GetMethod("GetHashCode");
        //methodInfo.Invoke(null,null);


        //dynamic excelObj = "Navi";
        //excelObj.Optimize(); // Gives an compiler-error if we don't use dynamic

        //dynamic name = "Mosh";
        //name = 10;
        //Console.WriteLine(name);

        //dynamic a = 10;
        //dynamic b = 20;
        //var c = a + b; // Becomes dynamic bcoz a and b are dynamic

        // Casting
        int i = 5;
        dynamic d = i;
        string l = d;


    }
}

//var v/s Dynamic

//type of var variable is known at compile time so error for var variable is generated at compile time but in case of dynamic, type of variable is unknown till runtime so error is generated for dynamic time variable at run time.
//This means the type of variable declared for var is decided by the compiler at compile time but the type of dynamic variable declared is decided by the compiler at runtime.
//Need of initialization for var is required at the time of declaration which is not the case for dynamic.
//We can not change the data type for a var keyword wherease we can do that for dynamic keyword.
//We can’t use the var keyword as a parameter for any function but the dynamic type can be used as parameter for any function .
//We can’t create a method with var as return type but we can create a method whose return type is dynamic.