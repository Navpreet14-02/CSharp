using BloodGuardian.View;
using BloodGuardian.Database;
using BloodGuardian.Common;


internal class Program
{
    private static void Main(string[] args)
    {



        try
        {
            Console.WriteLine(Message.AppLogo);
            Console.WriteLine();
            App.Start();
        }
        catch (Exception ex)
        {
            ExceptionsDBHandler.Instance.LogException(ex);
            Console.WriteLine(Message.UnexpectedError);
            Console.WriteLine(Message.RestartingApp);
            App.Start();
        }




    }
}
