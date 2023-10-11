using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;


// ======= Interfaces and Extensibility ======
// We want to design out app in such a way that changes can be made without changing any code.
// i.e by creating new classes or using interfaces.


namespace Oct_11
{


    public interface Ilogger
    {
        void LogError(string msg);
        void LogInfo(string msg);


    }


    public class ConsoleLogger : Ilogger
    {
        public void LogError(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(msg);
        }

        public void LogInfo(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(msg);
        }
    }

    // Now let's say instead of console, we want to log info on a file, we can create another class.

    public class FileLogger : Ilogger
    {
        private readonly string _path;

        public FileLogger(string path)
        {
            _path = path;
        }


        private void Log(string msg,string msgType)
        {
            using(var sw = new StreamWriter(_path, true))
            {
                sw.WriteLine(msgType+" : "+msg); // This gives us a FileResource that is not managed by CLR.
                // To dispose this after it's used, we need to wrap it in a using block or use sw.dispose().

            }

        }
        public void LogError(string msg)
        {

            Log(msg, "ERROR");

           
        }

        public void LogInfo(string msg)
        {

            Log(msg, "INFO");

        }
    }

    public class DBMigrator
    {
        private readonly Ilogger _logger;

        public DBMigrator(Ilogger logger) // This technique passing dependencies in the constructor is called Dependency Injection.
        {
            _logger = logger;
        }

        public void Migrate()
        {


            _logger.LogInfo($"Migration started at {DateTime.Now}");
            //Console.WriteLine($"Migration started at {DateTime.Now}");

            // Details of migrating the database

            _logger.LogInfo($"Migration finished at {DateTime.Now}"); 
            //Console.WriteLine($"Migration finished at {DateTime.Now}");



        }


    }
    internal class InterfaceExtensibility
    {
    }
}
