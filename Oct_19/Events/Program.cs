

// ======= Events and Delegates ========
// Events: A mechanism for communication between objects.





using System.Security.Cryptography.X509Certificates;
public class Video
{
        
    public string Title { get; set; }
}


public class VideoEventArgs : EventArgs
{

    public Video Video { get; set; }

}
public class VideoEncoder
{

    // Steps to publish an Event
    // 1 - Define a delegate

    public delegate void VideoEncodedEventHandler(object source, VideoEventArgs args); // This defines the signature of the method that should be present
    // in the subscriber.
    // Source - Refers to class or object that publishes the event.
    // Eventargs - If we want to send some additional data with the event we can pass it here.




    // 2 - Define an event based on that delegate

    public event VideoEncodedEventHandler VideoEncoded;

    // Instead of creating our own delegate, C# comes with two event handler delegates: EventHandler and EventHandler<>
    //public event EventHandler<VideoEventArgs> VideoEncoded;
    // This line states that when VideoEncoded event is raised then all
    // methods that follow the delegate VideoEncodedEventHandler in the subscriber classes will run.

    // 3 - Raise the event

    protected virtual void OnVideoEncoded(Video v) // The method that raises the event should be protected and virtual
    {
        if(VideoEncoded != null) // this statement checks if there are any subscribers
        {
            VideoEncoded(this, new VideoEventArgs() { Video = v});
        }
    }

    public void Encode(Video video)
    {
        Console.WriteLine("Encoding Video...");
        Thread.Sleep(2000);

        OnVideoEncoded(video);
        
    }
}


public class MailService
{

    public void OnVideoEncoded(object src, VideoEventArgs args)
    {
        Console.WriteLine("Sending Email..."+ args.Video.Title);
    }


}

public class MessageService
{
    public void AfterVideoEncoded(object src, VideoEventArgs e)
    {
        Console.WriteLine("Sending Message..."+e.Video.Title);
    }

    public void Send()
    {
        Console.WriteLine("Message Sent");
    }
}

internal class Program
{



    private static void Main(string[] args)
    {
        Video video = new Video() { Title = "This is a video" };

        VideoEncoder ve = new VideoEncoder(); // publisher
        MailService ms = new MailService(); // Subscriber
        MessageService msg = new MessageService(); // Subscriber

        VideoEventArgs vea = new VideoEventArgs();

        //VideoEncoder.VideoEncodedEventHandler vdobj = new VideoEncoder.VideoEncodedEventHandler(ms.OnVideoEncoded);
        //vdobj += msg.AfterVideoEncoded;

        ve.VideoEncoded += ms.OnVideoEncoded;
        ve.VideoEncoded += msg.AfterVideoEncoded;


        ve.Encode(video);
        //ve.VideoEncoded += ms

    }

}