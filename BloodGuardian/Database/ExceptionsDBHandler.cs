using BloodGuardian.Common;
using Newtonsoft.Json;


namespace BloodGuardian.Database
{
    internal class ExceptionsDBHandler
    {
        private static ExceptionsDBHandler _handler;

        static private List<Exception> _exceptions;



        private ExceptionsDBHandler()
        {
            _exceptions = JsonConvert.DeserializeObject<List<Exception>>(File.ReadAllText(Message._exceptionsDataPath));
        }

        public static ExceptionsDBHandler Instance
        {
            get
            {
                if (_handler == null)
                {
                    _handler = new ExceptionsDBHandler();
                }
                return _handler;
            }

        }
        public void LogException(Exception ex)
        {
            _exceptions.Add(ex);
            Update(Message._exceptionsDataPath);
        }

        public void Update(string path)
        {
            string exceptionsDataJSON = JsonConvert.SerializeObject(_exceptions, Formatting.Indented);
            File.WriteAllText(Message._exceptionsDataPath, exceptionsDataJSON);
        }
    }
}
