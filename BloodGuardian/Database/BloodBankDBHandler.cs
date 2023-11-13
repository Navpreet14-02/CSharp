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


        public BloodBankDBHandler()
        {

            _bloodbanks = JsonConvert.DeserializeObject<List<BloodBank>>(File.ReadAllText(Message._bankDataPath));


        }

        public IBloodBankDBHandler Instance
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

            if (deposit) _bloodbanks.Find(b => b.ManagerUserName == bank.ManagerUserName).BloodUnits[bloodType] += newquantity;
            else _bloodbanks.Find(b => b.ManagerUserName == bank.ManagerUserName).BloodUnits[bloodType] -= newquantity;

            Update(Message._bankDataPath);

        }

        public void Update(string path)
        {
            string bankDataJSON = JsonConvert.SerializeObject(_bloodbanks, Formatting.Indented);
            File.WriteAllText(path, bankDataJSON);
        }
    }
}
