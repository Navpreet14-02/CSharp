using BloodGuardian.Common;
using BloodGuardian.Models;
using Newtonsoft.Json;

namespace BloodGuardian.Database
{
    internal class RequestDBHandler : DB<Request>
    {


        private static RequestDBHandler _handler = null;

        static private List<Request> _bloodRequests;



        private RequestDBHandler()
        {
            _bloodRequests = JsonConvert.DeserializeObject<List<Request>>(File.ReadAllText(Message._requestDataPath));
        }

        public static RequestDBHandler Instance
        {
            get
            {
                if (_handler == null)
                {
                    _handler = new RequestDBHandler();
                }
                return _handler;
            }

        }

        public List<Request> Read()
        {

            return _bloodRequests;
        }

        public void Add(Request r)
        {
            r.RequestId = _bloodRequests.Count;
            _bloodRequests.Add(r);

            Update(Message._requestDataPath);

        }

        public void Delete(Request r)
        {
            _bloodRequests.Remove(r);
            foreach (var (request, ind) in _bloodRequests.Select((val, i) => (val, i)))
            {
                request.RequestId = ind;
            }

            Update(Message._requestDataPath);

        }

        public void Update(string path)
        {
            string requestDataJSON = JsonConvert.SerializeObject(_bloodRequests, Formatting.Indented);
            File.WriteAllText(Message._requestDataPath, requestDataJSON);
        }
    }
}
