using BloodGuardian.Common;
using BloodGuardian.Database.Interface;
using BloodGuardian.Models;
using Newtonsoft.Json;

namespace BloodGuardian.Database
{
    internal class DonorDBHandler : IDonorDBHandler
    {

        private static DonorDBHandler _handler = null;

        private List<Donor> _donors;
        private DonorDBHandler()
        {

            try
            {
                _donors = JsonConvert.DeserializeObject<List<Donor>>(File.ReadAllText(Message._donorDataPath));

            }
            catch (Exception ex)
            {
                LogExceptions.Instance.Log(ex);
                Console.WriteLine(Message.UnexpectedError);
            }



        }



        public static DonorDBHandler Instance
        {
            get
            {
                if (_handler == null)
                {
                    _handler = new DonorDBHandler();
                }
                return _handler;
            }
        }

        public void Add(Donor d)
        {
            d.Donorid = _donors.Count;
            _donors.Add(d);
            Update(Message._donorDataPath);


        }

        public Donor FindDonorByUserName(string username)
        {
            return _donors.Find((donor) => donor.UserName.Equals(username, StringComparison.InvariantCultureIgnoreCase));

        }
        public List<Donor> Get()
        {
            return _donors;
        }

        public void Delete(Donor d)
        {

            _donors.Remove(d);

            foreach (var (donor, ind) in _donors.Select((val, i) => (val, i)))
            {
                donor.Donorid = ind;
            }
            Update(Message._donorDataPath);

        }

        public void UpdateDonor(Donor oldDonor, Donor newDonor)
        {
            int donorIndex = oldDonor.Donorid;

            _donors[donorIndex] = newDonor;

            Update(Message._donorDataPath);
        }

        public Donor FindDonorByCredentials(string username, string password)
        {
            return _donors.Find((donor) => donor.UserName == username && donor.Password == password);
        }

        public Donor FindDonorByBank(BloodBank bank)
        {
            var donor = _donors.Find((dn) => dn.UserName.Equals(bank.ManagerUserName, StringComparison.InvariantCultureIgnoreCase));
            return donor;
        }

        public void Update(string path)
        {

            try
            {
                string donorDataJSON = JsonConvert.SerializeObject(_donors, Formatting.Indented);
                File.WriteAllText(Message._donorDataPath, donorDataJSON);

            }
            catch (Exception ex)
            {
                LogExceptions.Instance.Log(ex);
                Console.WriteLine(Message.UnexpectedError);
            }
        }


    }
}
