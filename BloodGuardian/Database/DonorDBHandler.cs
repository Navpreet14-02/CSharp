using BloodGuardian.Common;
using BloodGuardian.Models;
using Newtonsoft.Json;

namespace BloodGuardian.Database
{
    internal class DonorDBHandler : DB<Donor>
    {

        private static DonorDBHandler _handler = null;

        static private List<Donor> _donors;
        private DonorDBHandler()
        {

            _donors = JsonConvert.DeserializeObject<List<Donor>>(File.ReadAllText(Message._donorDataPath));


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
        public List<Donor> Read()
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

        public void Update(string path)
        {
            string donorDataJSON = JsonConvert.SerializeObject(_donors, Formatting.Indented);
            File.WriteAllText(Message._donorDataPath, donorDataJSON);
        }
        
            
    }
}
