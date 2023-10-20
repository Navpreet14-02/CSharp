using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionHandling
{


    public class YoutubeException : Exception
    {
        public YoutubeException(string msg, Exception innerException ):base(msg, innerException)
        {
            
        }
    }

    public class YoutubeApi
    {
        public List<string> GetVideos(string user)
        {
            try
            {
                // Access data from youtube web service
                // Read the Data
                // Create a list of video objects

                throw new Exception("Oops some low level youtube error");

            }
            catch (Exception ex)
            {

                // Log
                throw new YoutubeException("Could not fetch the videos from youtube",ex);
            }

            return new List<String>();
        }
    }


    internal class CustomException
    {
    }
}
