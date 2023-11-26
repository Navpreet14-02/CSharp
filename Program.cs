using BloodGuardian.Common;
using BloodGuardian.Database;
using BloodGuardian.View;


internal class Program
{
    private static void Main(string[] args)
    {

        try
        {
            Console.WriteLine(Message.AppLogo);
            Console.WriteLine();
            UI.Start();
        }
        catch (Exception ex)
        {
            LogExceptions.Instance.Log(ex);
            Console.WriteLine(ex.StackTrace);
            Console.WriteLine(Message.UnexpectedError);
        }




    }
}
