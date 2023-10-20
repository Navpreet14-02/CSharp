using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;


// Thread States
// Unstarted
// Runnable
// Running
// Not Running
// Dead(terminated)
 
namespace AsyncProgramming
{
    internal class MultiThreading
    {

        public void getThread()
        {
            Thread t = Thread.CurrentThread;
            ////t.Name = "Navi";
            Console.WriteLine(t.Name);
        }

        public static void Thread1()
        {
            for(int i = 0; i < 5; i++)
            {
                Console.WriteLine("Thread1: "+DateTime.Now);
                Thread.Sleep(200);
            }
        }

        public static void Thread2()
        {
            for (int i = 5; i > 1; i--)
            {
                Console.WriteLine("Thread2: "+DateTime.Now);

            }
        }
    }
}
