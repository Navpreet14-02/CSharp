using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oct_12
{

    public interface IPractice
    {
        //public string name; cannot contains instance fields
        static string _name;
        private static int _id;

        public int ID
        {

            get { return _id; }
            set { _id = value; }
        }


        public int age
        {
            get { return age; }
            set
            {
                Console.WriteLine("Hello");
                age = value;
            }
        }


        //static IPractice()
        //{
        //   _id = id;
        //    _name = name;
        //}

        void IPractice() // If this is not static, value will not be assigned. 
        {
            _id = -1;
            _name = "Navi";
        }

        public static void PrintId() // static methods must have a definition
        {
            Console.WriteLine(_id);
        }


        public virtual void introduce() // Defualt Implementation
        {
            Console.WriteLine($"Hi, I'm {ID} : {_name}");
        }

    }




    public interface IDerived : IPractice
    {
        public void introduce()
        {
            Console.WriteLine($"I'm {_name}");
        }
        void IPractice.introduce()
        {
            Console.WriteLine($"I'm {_name}");
        }
    }

    public class MyClass : IPractice
    {

        //public static string _name;
        //public MyClass(int id,string n)
        //{
        //    //IPractice(id, n);
        //}

        //public void introduce()
        //{
        //Console.WriteLine($"Hello, I'm Navpreet");
        //}
    }



    // ========= EXPLICIT INTERFACE IMPLEMENTATION ===========
    public interface IShape
    {
        void Copy();
    }

    public interface IImage
    {
        void Copy();
    }

    public class MSOffice : IShape, IImage
    {
        //An explicit interface implementation doesn't have an
        //access modifier since it isn't accessible as a member
        //of the type it's defined in. 
        void IShape.Copy()
        {
            Console.WriteLine("Copying Shape to Clipboard");
        }

        void IImage.Copy()
        {
            Console.WriteLine("Copying Image to Clipboard");

        }
    }

    internal class Interfaces
    {
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
    }
}
