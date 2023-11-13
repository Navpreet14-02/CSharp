using BloodGuardian.Common;


namespace BloodGuardian.Database
{
    internal class ExceptionsDBHandler
    {
        private static ExceptionsDBHandler _handler;

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

            File.AppendAllText(Message._exceptionsDataPath, ex.ToString() + '\n');
        }

    }
}
