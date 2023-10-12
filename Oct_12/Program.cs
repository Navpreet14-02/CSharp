using System.Reflection.Metadata.Ecma335;
using System.Xml.Linq;




using Oct_12;
using ClassesAndStructs;

internal class Program


{

    public class SomeClass : InternalProtected
    {
        public void someFunc()
        {
            //func1(); With internal protection, the function is not accessible from any other assembly.
            func3(); // With internal protected modifier however, the func is accessible from a class that is inheriting from that class.
        }
    }


    private static void Main(string[] args)
    {


        // ============ INTERFACE ============= 

        //IPractice ip = new IPractice(); // Cannot create an instance of an interface.
        //IDerived._name = "abc";
        //Practice ip = new MyClass(1,"Navi14");


        IPractice ip = new MyClass();
        //ip.ID = -100;
        //ip.age = 5;
        //ip.introduce();
        //MyClass._name =;
        //Console.WriteLine(ip.age);
        //Console.WriteLine(ip.ID);

        //IPractice._name = "xyz";
        //Console.WriteLine(IPractice._name);
        //ip.introduce();



        //  ======= EXPLICIT INTERFACE IMPLEMENTATION =======
        //MSOffice ms = new MSOffice();
        //IShape shape = new MSOffice();
        //IImage img = new MSOffice();

        ////ms.Copy();
        //shape.Copy();
        //img.Copy();



        // === INTERNAL AND PROTECTED INTERNAL MODIFIERS===

        InternalProtected internalDemo = new InternalProtected();
        //internalDemo.func1(); -> Error as this method is internally protected in another assembly or namespace.
        //internalDemo.func2();
        //internalDemo.func3();
        SomeClass sm = new SomeClass();
        //sm.someFunc();


        //============ PROPERTIES ================

        Properties props = new Properties() { Name="Navpreet" };
        props.Age = 20;
        //props.Name = "Navpreet";
        Console.WriteLine($"{props.Age} : {props.Name}");
    }
}