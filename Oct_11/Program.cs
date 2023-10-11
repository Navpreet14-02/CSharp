
using Oct_11;
using System.Security.Principal;

internal class Program
{


    private static void Main(string[] args)
    {


        // ======= INTERFACE AND EXTENSIBILITY ==========
        //DBMigrator db = new DBMigrator(new ConsoleLogger());
        
        //DBMigrator db = new DBMigrator(new FileLogger("C:\\log.txt"));

        //db.Migrate();


        // Exercise - Design a workflow engine

        WorkFlow wk = new WorkFlow();
        wk.Add(new UploadVideo());
        wk.Add(new SendEmail());
        wk.Add(new UploadVideo());
        wk.Add(new SendEmail());

        WorkflowEngine wkEng = new WorkflowEngine();
        wkEng.Run(wk);


    }
}