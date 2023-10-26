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
    internal static class DBHandler
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

        public static void AddDonor(Donor d) {
            d.Donorid = _donors.Count;
            _donors.Add(d);
            UpdateDB();

            
        }
        public static Donor FindDonor(string email,string password)
        {

            var d =  _donors.Find((donor)=>donor.Email == email && donor.Password == password);

            return d;
        }

        public static void UpdateDonor(Donor oldDonor,Donor newDonor)
        {
            int donorIndex = oldDonor.Donorid;

            _donors[donorIndex] = newDonor;

            UpdateDB();
        }


        // -------------------------------------------------------------------------------------------------------------





        //-------------------------------------------------------------------------------------------------------------

        // Request methods

        public static void GetRequests()
        {
            foreach (var request in _bloodRequests)
            {
                Console.WriteLine("--------------------------------------");
                Console.WriteLine(request.RequestId);
                Console.WriteLine("Requester Name: "+request.RequesterName);
                Console.WriteLine("Requester Phone No: " + request.RequesterPhone);
                Console.WriteLine("Requested Blood Type: "+request.BloodRequirementType);
                Console.WriteLine("Requester Address: "+request.Address);
            }

        }

        public static void AddRequest(Request r)
        {
            r.RequestId = _bloodRequests.Count;
            _bloodRequests.Add(r);

            UpdateDB();
        }


        //-------------------------------------------------------------------------------------------------------------



        //-------------------------------------------------------------------------------------------------------------
        // Blood Bank Methods

        public static List<BloodBank> SearchBloodBank(string state,string city,string bloodType)
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

        public static void AddBloodBank(BloodBank bb)
        {
            bb.BankId = _bloodbanks.Count;
            _bloodbanks.Add(bb);
            UpdateDB();
        }


        public static BloodBank FindBloodBank(Donor d)
        {

            return _bloodbanks.Find((b) => b.ManagerEmail == d.Email);
        }

        public static void UpdateBloodBank(BloodBank oldBB,BloodBank newBB)
        {
            int bbIndex = oldBB.BankId;

            _bloodbanks[bbIndex] = newBB;

            UpdateDB();

        }

        public static void UpdateBloodBank(BloodBank bank,string bloodType,int newquantity,bool deposit)
        {

            if(deposit)_bloodbanks.Find(b => b.ManagerEmail == bank.ManagerEmail).BloodUnits[bloodType] += newquantity;
            else _bloodbanks.Find(b => b.ManagerEmail == bank.ManagerEmail).BloodUnits[bloodType] -= newquantity;

            UpdateDB();

        }


        //-------------------------------------------------------------------------------------------------------------




        //-------------------------------------------------------------------------------------------------------------
        // Database Methods



        private static void UpdateDB()
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
