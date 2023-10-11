using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oct_11
{

    public interface IActivity
    {

        void Execute();
    }

    public class UploadVideo : IActivity
    {
        public void Execute() {
            Console.WriteLine("Uploading the video to the Cloud ");
        }
    }

    public class SendEmail : IActivity
    {
        public void Execute()
        {
            Console.WriteLine("Sending the Email. ");
        }
    }

    public class WorkFlow
    {
        private readonly IList<IActivity> _workflow;

        public WorkFlow()
        {
            _workflow = new List<IActivity>();
        }

        public void Add(IActivity activity)
        {
           _workflow.Add(activity);
        }


        public IEnumerable<IActivity> GetAll()
        {
            return _workflow;
        }

    }

    internal class WorkflowEngine
    {


        public void Run(WorkFlow wk)
        {
            foreach(var activity in wk.GetAll())
            {
                activity.Execute();
            }
        }
    }
}
