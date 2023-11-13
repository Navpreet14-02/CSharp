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
            App.Start();
        }
        catch (Exception ex)
        {
            ExceptionsDBHandler.Instance.LogException(ex);
            Console.WriteLine(Message.UnexpectedError);
        }




    }
}
