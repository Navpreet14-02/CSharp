using ExceptionHandling;

internal class Program
{

    public class Calculator
    {
        public int divide(int a, int b) => a / b;
    }
    private static void Main(string[] args)
    {

        StreamReader sr=null; 
        try
        {
            //sr=new StreamReader(@"C:\file.zip");
            //Calculator cal = new Calculator();
            //int n = cal.divide(5,0);


            //var content = sr.ReadToEnd();

            //using (var streamReader = new StreamReader(@"C:\file.zip"))
            //{
            //    var content = sr.ReadToEnd();
            //}

            var api = new YoutubeApi();
            var videos = api.GetVideos("Navi");

        }
        catch (Exception ex) when (sr!=null)
        {
            Console.WriteLine(ex.Message);
        }
        //catch(DivideByZeroException ex)
        //{
        //    Console.WriteLine("You cannot divide by zero.");
        //}
        //catch(ArithmeticException ex)
        //{

        //}
        //catch (Exception ex)
        //{
        //    Console.WriteLine("Sorry, an unexpected error has occurred");
        //}
        //finally //This block is used to call the dispose method of the class that uses unmanaged resources.
        //{
        //    //IDisposable 
        //    if(sr != null)
        //    {
        //        sr.Dispose();
        //    }
        //    sr.Dispose();
        //    Console.WriteLine();
        //}


    }
}