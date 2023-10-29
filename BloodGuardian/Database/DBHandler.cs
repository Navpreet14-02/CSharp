using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BloodGuardian.Models;
using Newtonsoft.Json;

namespace BloodGuardian.Database
{


    //internal interface DB
    //{

    //    // Donor Methods
    //    //void GetDonors();
    //    void AddDonor(Donor d);
    //    bool FindDonor(string email, string password);
    //    //void RemoveDonor();

    //    // Request Methods
    //    //void GetRequests();
    //    //void AddRequest();
    //    //void RemoveRequest();

    //    //BloodBank Methods
    //    void AddBloodBank(BloodBank bb);
    //    //void RemoveBloodBank();
    //    //void GetBloodBanks();

    //    // BloodDonationCamps


    //}
    internal class DBHandler
    {
        static private List<Donor> _donors;
        static private string _donorDataPath = @"C:\Users\nasingh\source\repos\BloodGuardian\Database\Donors.json";

        static private List<BloodBank> _bloodbanks;
        static private string _bankDataPath = @"C:\Users\nasingh\source\repos\BloodGuardian\Database\BloodBanks.json";

        static private List<Request> _bloodRequests;
        static private string _requestDataPath = @"C:\Users\nasingh\source\repos\BloodGuardian\Database\BloodRequests.json";

        static DBHandler()
        {

            _donors = JsonConvert.DeserializeObject<List<Donor>>(File.ReadAllText(_donorDataPath));

            _bloodbanks = JsonConvert.DeserializeObject<List<BloodBank>>(File.ReadAllText(_bankDataPath));

            _bloodRequests = JsonConvert.DeserializeObject<List<Request>>(File.ReadAllText(_requestDataPath));
        }



        //-----------------------------------------------------------------------------------------------------
        // Donor Methods

        public void AddDonor(Donor d) {
            d.Donorid = _donors.Count;
            d.LoggedIn = false;
            _donors.Add(d);
            UpdateDB();

            
        }

        public static List<Donor> ReadDonors()
        {
            return _donors;
        }


        public void UpdateDonor(Donor oldDonor,Donor newDonor)
        {
            int donorIndex = oldDonor.Donorid;

            _donors[donorIndex] = newDonor;

            UpdateDB();
        }


        public void DeleteDonor(int donorIndex)
        {

            // Removing Donor

            var bank = _bloodbanks.Find((bank) => bank.ManagerEmail == _donors[donorIndex].Email);

            _donors.RemoveAt(donorIndex);

            // Updating Donor IDs

            foreach (var (donor, ind) in _donors.Select((val, i) => (val, i)))
            {
                donor.Donorid = ind;
            }


            DeleteBloodBank(null,bank.BankId);

            UpdateDB();

        }





        // -------------------------------------------------------------------------------------------------------------





        //-------------------------------------------------------------------------------------------------------------

        // Request methods

        public static List<Request> GetRequests()
        {

            return _bloodRequests;
        }

        public void AddRequest(Request r)
        {
            r.RequestId = _bloodRequests.Count;
            _bloodRequests.Add(r);

            UpdateDB();
        }

        public void DeleteRequest(Request r)
        {
            _bloodRequests.Remove(r);
            foreach (var (request, ind) in _bloodRequests.Select((val, i) => (val, i)))
            {
                request.RequestId = ind;
            }

            UpdateDB();

        }


        //-------------------------------------------------------------------------------------------------------------



        //-------------------------------------------------------------------------------------------------------------
        // Blood Bank Methods

        public List<BloodBank> SearchBloodBank(string state,string city,string bloodType)
        {
            List<BloodBank> result;


            if (state == null || city == null) return null;
            else if(bloodType == null)
            {

                result = _bloodbanks.FindAll((bloodbank) => bloodbank.State == state && bloodbank.City == city);
            }
            else
            {
                result = _bloodbanks.FindAll((bloodbank) => bloodbank.State == state && bloodbank.City == city && bloodbank.BloodUnits[bloodType] > 0);

            }

            return result;
        }

        public void AddBloodBank(BloodBank bb)
        {
            bb.BankId = _bloodbanks.Count;
            _bloodbanks.Add(bb);
            UpdateDB();
        }

        public List<BloodBank> ReadBloodBanks()
        {
            return _bloodbanks;
        }

        public BloodBank FindBloodBank(Donor d,int bankid)
        {

            if(bankid== -1)
            {
                return _bloodbanks.Find((b) => b.ManagerEmail == d.Email);

            }
            else
            {
                return _bloodbanks[bankid];
            }
        }

        public void UpdateBloodBank(BloodBank oldBB,BloodBank newBB)
        {
            int bbIndex = oldBB.BankId;

            _bloodbanks[bbIndex] = newBB;

            UpdateDB();

        }

        public void DeleteBloodBank(Donor d,int bankIndex)
        {

            // Removing Blood Bank

            if (d == null)
            {
                _bloodbanks.RemoveAt(bankIndex);
            }
            else
            {
                _donors[d.Donorid].Role = roles.Donor;
                _bloodbanks.RemoveAt(bankIndex);
            }

            // Updating BloodBank Ids
            foreach (var (bank, ind) in _bloodbanks.Select((val, i) => (val, i)))
            {
                bank.BankId= ind;
            }

            UpdateDB();

        }

        public void UpdateBloodTransferRecord(BloodBank bank,string bloodType,int newquantity,bool deposit)
        {

            if(deposit)_bloodbanks.Find(b => b.ManagerEmail == bank.ManagerEmail).BloodUnits[bloodType] += newquantity;
            else _bloodbanks.Find(b => b.ManagerEmail == bank.ManagerEmail).BloodUnits[bloodType] -= newquantity;

            UpdateDB();

        }





        //-------------------------------------------------------------------------------------------------------------


        //-------------------------------------------------------------------------------------------------------------

        // Blood Donation Camp Methods
        public List<BloodDonationCamp> NearestBloodDonationCamps(Donor d)
        {

            var campsLists = _bloodbanks.Select((bank) => bank.BloodDonationCamps).ToList();

            List<BloodDonationCamp> camps=new List<BloodDonationCamp>();
            campsLists.ForEach((campList) => campList.ForEach((camp) =>
            {
                if (camp.Camp_State == d.State && camp.Camp_City == d.City) camps.Add(camp);
            }));

            return camps;

        }


        //-------------------------------------------------------------------------------------------------------------




        //-------------------------------------------------------------------------------------------------------------
        // Database Methods



        private void UpdateDB()
        {
            string donorDataJSON = JsonConvert.SerializeObject(_donors,Formatting.Indented);
            File.WriteAllText(_donorDataPath, donorDataJSON);

            string bankDataJSON = JsonConvert.SerializeObject(_bloodbanks, Formatting.Indented);
            File.WriteAllText(_bankDataPath, bankDataJSON);

            string requestDataJSON = JsonConvert.SerializeObject(_bloodRequests, Formatting.Indented);
            File.WriteAllText(_requestDataPath, requestDataJSON);
        }

    }
}
