using BloodGuardian;
using BloodGuardian.View;
using BloodGuardian.Database;
using BloodGuardian.Models;

internal class Program
{
    private static void Main(string[] args)
    {



        DBHandler database = new DBHandler();
        try
        {
            Console.WriteLine("******************** BLOODGUARDIAN ***********************");
            Console.WriteLine();
            App.Start(database);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            Console.WriteLine("App Restarting...");
            App.Start(database);
        }




    }
}
