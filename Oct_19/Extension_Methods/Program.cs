

// =========== EXTENSION METHODS =============

// Allow us to add methods to an exisitng class without
// - changing its source code, or
// - creating a new class that inherits from it  


// To run an extension method, the class that created it should be in the same namespace



using System.Runtime.CompilerServices;

public static class StringExtensions
{
    public static string Shorten(this string /*this is called a binding parameter */ s,int noOfWords)
    {
        //Binding parameters are those parameters which are used to bind the new method with the existing class or structure.It does not take any value when you are calling the extension method
        //because they are used only for binding not for any other use.
        //In the parameter list of the extension method binding parameter is always present at the first place if you write binding parameter to second, or third, or any other place rather than first place then the compiler will give an error.

        if(noOfWords < 0) throw new ArgumentOutOfRangeException("number of words should be greater than 0.");

        if (noOfWords == 0) return "";


        string[] words = s.Split(' ');

        if (words.Length <= noOfWords) return s;

        return string.Join(" ", words.Take(noOfWords))+"...";
    
    }
}


// Important Points:
// - Extension methods are always defined as a static method, but when they are bound with any class or structure they will convert into non-static methods.
// - When an extension method is defined with the same name and the signature of the existing method, then the compiler will print the existing method, not the extension method.
// - It cannot apply to fields, properties, or events.
// - Multiple binding parameters are not allowed means an extension method only contains a single binding parameter. But you can define one or more normal parameter in the extension method.






internal class Program

{
    private static void Main(string[] args)
    {


        string post = "This a very very very very very very long string blahh blahh blahh...";

        var shortenedStr = post.Shorten(4);

        Console.WriteLine(shortenedStr);
    }
}