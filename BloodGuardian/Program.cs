using BloodGuardian;
using BloodGuardian.View;
using BloodGuardian.Database;
using BloodGuardian.Models;

internal class Program
{
    private static void Main(string[] args)
    {

        DBHandler database = new DBHandler();


        App.Start(database);



    }
}
