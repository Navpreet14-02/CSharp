using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


// ================== INTERFACES ======================
// Why? - To build loosely-couple applications.
//An interface looks like a class but has no implementation.
//The reason interfaces only provide declarations is that they are inherited by structs and classes, which must provide an implementation for each interface member declared.


//// Abstract Class v/s Interfaces:
//1.A class can implement any number of interfaces but a subclass can at most use only one abstract class.

//2.An abstract class can have non-abstract Methods(concrete methods) while in case of Interface all the methods has to be abstract.

//3.An abstract class can declare or use any variables while an interface is not allowed to do so.

//4.An abstract class can have constructor declaration while an interface can not do s

//5.An abstract Class is allowed to have all access modifiers for all of its member declaration while in interface we can not declare any access modifier(including public) as all the members of interface are implicitly public.


// Interfaces are not used to implement multiple inheritance. Inheritance is used for code reusability as a derived class can use the code written in the base class.
// In interfaces however, there is no implementation and each func has to be implemented in the derived class.

namespace Oct_11
{


    public interface IShape
    {
        public void Draw(); // Members of an interface can only be public.
        void Copy();
        void Select()
        {
            Console.WriteLine("sELECT");
        }
    }

    public class Shape : IShape
    {
        public void Draw()
        {
            Console.WriteLine("Drawing");
        }

        public void Copy()
        {
            Console.WriteLine("Copying");

        }

        public void Select()
        {
            Console.WriteLine("Selecting");
        }
    }


    internal class Interface
    {
    }
}
