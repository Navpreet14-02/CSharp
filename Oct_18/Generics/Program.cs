internal class Program
{


    public class ListInt // This list class can only store Integers.
    {


        public int tempField;
        public void Add(int num)
        {

        }

        public int this[int index]
        {
            get { throw new IndexOutOfRangeException(); }
        }
    }

    // If we want to create a list of another type say char, then we will have to create a new class as shown below
    public class ListChar // This list class can only store Integers.
    {
        public void Add(char num)
        {

        }

        public char this[char index]
        {
            get { throw new IndexOutOfRangeException(); }
        }
    }

    // With this way, we will have to create multiple class having the same functionality but for different data types.
    // which is not recommended.
    // We can create a list of objects but that will have some performance penalty due to boxing and unboxing.
 
    // That is where Generics come: With generics, we create a class once and reuse it multiple types.
    public class GenericList<T> // T means that any kind of data type can be used at runtime.
    {
        public void add(T item)
        {

            throw new IndexOutOfRangeException();
        }

        public T this[T key]
        {
            get { throw new IndexOutOfRangeException(); }
        }
    }


    public class GenericDict<Tkey, Tvalue> where Tkey : IComparable,new() // If we want to create a restrictions related to which kind of data types can be put in the place of T, we can add constraints:

    {



        //public GenericDict()
        //{

        //}
    }


    // There can exist a generic method inside a non-generic class


    // Constraints:

    // T : Icomparable

    // T : product -> class or its subclasses
    //public class DiscountCal<TProduct> where  TProduct: ListInt // Any class or its subclasses


        // T :struct -> valueType 
        public class Nullable<T> where T : struct
    {
        private object _value;
        public Nullable(T value)
        {
            _value = value;

        }

        public bool HasValue()
        {
            return _value!= null;
        }


        public T GetValueOrDefault()
        {
            if (HasValue())
            {
                return (T)_value;
            }

            return default(T);
        }

    }
        // T : class -> reference Type

        // T : new()
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");


        var numList = new ListInt();
        var genList = new GenericList<int>();


        // All generics are present in System.Collections.Generic;


        var dict = new GenericDict<int, string>();
    }

}