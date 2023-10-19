

// ================ Nullable Types ======================

// Value Types - Cannot be null


//Nullable types do not support nested Nullable types.
//Nullable types do not support var type. If you use Nullable with var, then the compiler will give you a compile-time error.
internal class Program
{
    private static void Main(string[] args)
    {

        //DateTime date = null; // This type of variable cannot be null.
        // We can make it nullable by:
        //Nullable<DateTime> date2 = null;

        //DateTime? date3 = new DateTime(2002,10,14); // A nullable type can also be declared like this.
        //DateTime date4;/*date3*/ // Error - we can't assign the value of nullable datetime to normal datetime
        //date4 = date3.GetValueOrDefault();

        //date3 = date4; // A normal type can be converted to nullable type

        //Console.WriteLine(date3.GetValueOrDefault()); // Returns Actual value or Default Value
        //Console.WriteLine(date3.HasValue);// Checks whether the type has value.
        //Console.WriteLine(date3.Value); // Gives an exception if no null is provided.


        // NULL Coalescing Operator
        DateTime? date = null;
        DateTime date2;

        if (date != null)
        {
            date2 = date.GetValueOrDefault();
        }
        else
        {
            date2 = DateTime.Today;
        }

        // This above code can be written in a single line below
        //date2 = date ?? DateTime.Today;

        int? a = 42;
        int b = 34;
        Console.WriteLine(a*b); // null
        if ( b is int ValueOfA)
        {
            Console.WriteLine(ValueOfA);
        }
        else
        {
            Console.WriteLine("a does not have any value.");
        }



    }
}