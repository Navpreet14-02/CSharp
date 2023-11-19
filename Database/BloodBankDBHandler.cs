using BloodGuardian.Common;
using BloodGuardian.Database.Interface;
using BloodGuardian.Models;
using Newtonsoft.Json;

namespace BloodGuardian.Database
{
    internal class BloodBankDBHandler : IBloodBankDBHandler
    {


        private static BloodBankDBHandler _handler;

        static private List<BloodBank> _bloodbanks;


        private BloodBankDBHandler()
        {

            try
            {
                _bloodbanks = JsonConvert.DeserializeObject<List<BloodBank>>(File.ReadAllText(Message._bankDataPath));
            }
            catch (Exception ex)
            {
                LogExceptions.Instance.Log(ex);
                Console.WriteLine(Message.UnexpectedError);
            }

        }

        public static BloodBankDBHandler Instance
        {
            get
            {
                if (_handler == null)
                {
                    _handler = new BloodBankDBHandler();
                }
                return _handler;
            }
        }

        public void Add(BloodBank bank)
        {
            bank.BankId = _bloodbanks.Count;
            _bloodbanks.Add(bank);
            Update(Message._bankDataPath);
        }

        public List<BloodBank> Get()
        {
            return _bloodbanks;
        }

        public void UpdateBloodBank(BloodBank oldBB, BloodBank newBB)
        {
            int bbIndex = oldBB.BankId;
            newBB.BankId = oldBB.BankId;

            _bloodbanks[bbIndex] = newBB;

            Update(Message._bankDataPath);

        }

        public void Delete(BloodBank bb)
        {
            _bloodbanks.Remove(bb);

            foreach (var (bank, ind) in _bloodbanks.Select((val, i) => (val, i)))
            {
                bank.BankId = ind;
            }

            Update(Message._bankDataPath);

        }


        public void UpdateBloodTransferRecord(BloodBank bank, string bloodType, int newquantity, bool deposit)
        {

            if (deposit) _bloodbanks.Find(b => b.ManagerUserName.Equals(bank.ManagerUserName,StringComparison.InvariantCultureIgnoreCase)).BloodUnits[bloodType] += newquantity;
            else _bloodbanks.Find(b => b.ManagerUserName.Equals(bank.ManagerUserName, StringComparison.InvariantCultureIgnoreCase)).BloodUnits[bloodType] -= newquantity;

            Update(Message._bankDataPath);

        }

        public BloodBank FindBloodBankbyDonor(Donor d)
        {
            
            return _bloodbanks.Find((b) => b.ManagerUserName.Equals(d.UserName,StringComparison.InvariantCultureIgnoreCase));
        }


        public Dictionary<BloodBank, List<BloodTransferReceipt>> GetDonorBloodDonationHistory(Donor d)
        {
            var bankdepositLists = new Dictionary<BloodBank, List<BloodTransferReceipt>>();
            _bloodbanks.ForEach(bank =>
            {
                bankdepositLists.Add(bank, bank.Blood_Deposit_Record);
            });

            return bankdepositLists;
        }

        public void Update(string path)
        {

            try
            {
                string bankDataJSON = JsonConvert.SerializeObject(_bloodbanks, Formatting.Indented);
                File.WriteAllText(path, bankDataJSON);
            }
            catch (Exception ex)
            {
                LogExceptions.Instance.Log(ex);
                Console.WriteLine(Message.UnexpectedError);
            }
        }


    }
}
