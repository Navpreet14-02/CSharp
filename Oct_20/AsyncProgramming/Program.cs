

// Synchronous Program Execution
// - Program is executed line by line, one at a time.
// - When a function is called, program execution has to wait until the function returns.


// Asynchronous Program Execution
// When a function is called, program execution continues to hte next line,without waiting for the function to complete.
// Asynchronous programming improves responsiveness
// Real World Examples : Windows Media Player, Web Browser
// When? - Accessing the Web, Working with files, databases and images.
// How? - Older -> Multi-threading, Callbacks. Newer -> Async/Await



using System.Net;
using System.Text;
using AsyncProgramming;
internal class Program
{

    // Synchronous way
    public void DownloadHtml(string url,string path)
    {
        var webClient = new WebClient();
        var html = webClient.DownloadString(url);

        using(var sw= new StreamWriter(path + @"\result.html"))
        {
            sw.WriteLine(html);
        }

        Console.WriteLine("File Downloaded.");

    }

    // Asynchronous Way 
    public async Task DownloadHtmlAsync(string url, string path)
    {
        // Task is an object that encapsulates the state of an async operation.
        var webClient = new WebClient();
        var html = await webClient.DownloadStringTaskAsync(url);



        using (var sw = new StreamWriter(path + @"\result.html"))
        {
            await sw.WriteAsync(html);
            await Console.Out.WriteLineAsync("File Downloaded");
        }


    }


    public async void GetHtml(string url)
    {
        var wc = new WebClient();

        string html = await GetHtmlAsync("http://msdn.microsoft.com");
        //return html;
        await Console.Out.WriteLineAsync(html.Substring(0,15));
    }


    public async Task<String> GetHtmlAsync(string url)
    {
        var wc = new WebClient();

        return await wc.DownloadStringTaskAsync(url);
    }

    private static void Main(string[] args)
    {

        //string path = @"C:\Users\nasingh\Downloads\WorkingWithFiles";

        //Console.WriteLine("Starting..." + DateTime.Now);

        //var obj = new Program();
        ////Console.WriteLine("Fetching File..."+DateTime.Now);
        ////obj.DownloadHtmlAsync("http://msdn.microsoft.com", path);
        //obj.GetHtml("http://msdn.microsoft.com");


        //Console.WriteLine("Ending..."+DateTime.Now);



        // ======== MULTITHREADING =======
        //MultiThreading mt = new MultiThreading();

        //mt.getThread();

        Thread t1 = new Thread(new ThreadStart(MultiThreading.Thread1));
        Thread t2 = new Thread(new ThreadStart(MultiThreading.Thread2));

        t1.Start();
        t1.Join();
        t2.Start();

    }
}