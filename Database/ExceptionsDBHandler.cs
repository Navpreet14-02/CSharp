using BloodGuardian.Common;
using BloodGuardian.Database.Interface;

namespace BloodGuardian.Database
{
    internal class LogExceptions : ILogger
    {
        private static LogExceptions _handler;

        private LogExceptions() { }

        public static LogExceptions Instance
        {
            get
            {
                if (_handler == null)
                {
                    _handler = new LogExceptions();
                }
                return _handler;
            }

        }
        public void Log(object ex)
        {

            File.AppendAllText(Message._exceptionsDataPath, ex.ToString() + '\n');
        }

    }
}
