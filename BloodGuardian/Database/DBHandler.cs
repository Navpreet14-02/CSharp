using BloodGuardian.Common;
using BloodGuardian.Models;
using Newtonsoft.Json;

namespace BloodGuardian.Database
{


    public interface DB<T>
    {


        void Add(T entity);
        void Delete(T entity);

        void Update(string path);
        List<T> Read();


    }
    //public sealed class DBHandler
    //{

    //    private static DBHandler _handler = null;

    //    static private List<Donor> _donors;
        

    //    static private List<BloodBank> _bloodbanks;
        

    //    static private List<Request> _bloodRequests;

    //    static private List<Exception> _exceptions;
        


    //    private DBHandler()
    //    {

    //        _donors = JsonConvert.DeserializeObject<List<Donor>>(File.ReadAllText(Message._donorDataPath));

    //        _bloodbanks = JsonConvert.DeserializeObject<List<BloodBank>>(File.ReadAllText(Message._bankDataPath));

    //        _bloodRequests = JsonConvert.DeserializeObject<List<Request>>(File.ReadAllText(Message._requestDataPath));

    //        _exceptions = JsonConvert.DeserializeObject<List<Exception>>(File.ReadAllText(Message._exceptionsDataPath));

    //    }


    //    public static DBHandler Instance
    //    {
    //        get
    //        {
    //            if (_handler== null)
    //            {
    //                _handler = new DBHandler();
    //            }
    //            return _handler;
    //        }
    //    }


    //    //-----------------------------------------------------------------------------------------------------
    //    // Donor Methods

    //    public void AddDonor(Donor d) {
    //        d.Donorid = _donors.Count;
    //        d.LoggedIn = false;
    //        _donors.Add(d);
    //        UpdateDB();

            
    //    }

    //    public List<Donor> ReadDonors()
    //    {
    //        return _donors;
    //    }


    //    public void UpdateDonor(Donor oldDonor,Donor newDonor)
    //    {
    //        int donorIndex = oldDonor.Donorid;

    //        _donors[donorIndex] = newDonor;

    //        UpdateDB();
    //    }


    //    public void DeleteDonor(int donorIndex)
    //    {

    //        // Removing Donor

    //        var bank = _bloodbanks.Find((bank) => bank.ManagerUserName == _donors[donorIndex].UserName);

    //        _donors.RemoveAt(donorIndex);

    //        // Updating Donor IDs

    //        foreach (var (donor, ind) in _donors.Select((val, i) => (val, i)))
    //        {
    //            donor.Donorid = ind;
    //        }

    //        if (bank != null)
    //        {
    //            DeleteBloodBank(null,bank.BankId);

    //        }


    //        UpdateDB();

    //    }





    //    // -------------------------------------------------------------------------------------------------------------





    //    //-------------------------------------------------------------------------------------------------------------

    //    // Request methods

    //    public List<Request> GetRequests()
    //    {

    //        return _bloodRequests;
    //    }

    //    public void AddRequest(Request r)
    //    {
    //        r.RequestId = _bloodRequests.Count;
    //        _bloodRequests.Add(r);

    //        UpdateDB();
    //    }

    //    public void DeleteRequest(Request r)
    //    {
    //        _bloodRequests.Remove(r);
    //        foreach (var (request, ind) in _bloodRequests.Select((val, i) => (val, i)))
    //        {
    //            request.RequestId = ind;
    //        }

    //        UpdateDB();

    //    }


    //    //-------------------------------------------------------------------------------------------------------------



    //    //-------------------------------------------------------------------------------------------------------------
    //    // Blood Bank Methods


    //    public void AddBloodBank(BloodBank bb)
    //    {
    //        bb.BankId = _bloodbanks.Count;
    //        _bloodbanks.Add(bb);
    //        UpdateDB();
    //    }

    //    public List<BloodBank> ReadBloodBanks()
    //    {
    //        return _bloodbanks;
    //    }

    //    public BloodBank FindBloodBank(Donor d,int bankid)
    //    {


            

    //        if(bankid== -1)
    //        {
    //            return _bloodbanks.Find((b) => b.ManagerUserName == d.UserName);

    //        }
    //        else
    //        {
    //            if (bankid < 0 || bankid > _bloodbanks.Count) return null;
    //            return _bloodbanks[bankid];
    //        }
    //    }

    //    public void UpdateBloodBank(BloodBank oldBB,BloodBank newBB)
    //    {
    //        int bbIndex = oldBB.BankId;
    //        newBB.BankId = oldBB.BankId;

    //        _bloodbanks[bbIndex] = newBB;

    //        UpdateDB();

    //    }

    //    public void DeleteBloodBank(Donor d,int bankIndex)
    //    {

    //        // Removing Blood Bank

    //        if (d == null)
    //        {
    //            _bloodbanks.RemoveAt(bankIndex);
    //        }
    //        else
    //        {
    //            DeleteDonor(d.Donorid);
    //            _bloodbanks.RemoveAt(bankIndex);
    //        }

    //        // Updating BloodBank Ids
    //        foreach (var (bank, ind) in _bloodbanks.Select((val, i) => (val, i)))
    //        {
    //            bank.BankId= ind;
    //        }

    //        UpdateDB();

    //    }

    //    public void UpdateBloodTransferRecord(BloodBank bank,string bloodType,int newquantity,bool deposit)
    //    {

    //        if(deposit)_bloodbanks.Find(b => b.ManagerUserName == bank.ManagerUserName).BloodUnits[bloodType] += newquantity;
    //        else _bloodbanks.Find(b => b.ManagerUserName == bank.ManagerUserName).BloodUnits[bloodType] -= newquantity;

    //        UpdateDB();

    //    }





    //    //-------------------------------------------------------------------------------------------------------------


    //    //-------------------------------------------------------------------------------------------------------------

    //    // Blood Donation Camp Methods
    //    //public List<BloodDonationCamp> NearestBloodDonationCamps(Donor d)
    //    //{

    //    //    var campsLists = _bloodbanks.Select((bank) => bank.BloodDonationCamps).ToList();

    //    //    List<BloodDonationCamp> camps=new List<BloodDonationCamp>();
    //    //    campsLists.ForEach((campList) => campList.ForEach((camp) =>
    //    //    {
    //    //        if (camp.Camp_State == d.State && camp.Camp_City == d.City) camps.Add(camp);
    //    //    }));

    //    //    return camps;

    //    //}


    //    //-------------------------------------------------------------------------------------------------------------





    //    //-------------------------------------------------------------------------------------------------------------
    //    // Database Methods


    //    public void LogException(Exception ex)
    //    {
    //        _exceptions.Add(ex);
    //        UpdateDB();
    //    }


    //    private void UpdateDB()
    //    {
    //        string donorDataJSON = JsonConvert.SerializeObject(_donors,Formatting.Indented);
    //        File.WriteAllText(Message._donorDataPath, donorDataJSON);

    //        string bankDataJSON = JsonConvert.SerializeObject(_bloodbanks, Formatting.Indented);
    //        File.WriteAllText(Message._bankDataPath, bankDataJSON);

    //        string requestDataJSON = JsonConvert.SerializeObject(_bloodRequests, Formatting.Indented);
    //        File.WriteAllText(Message._requestDataPath, requestDataJSON);

    //        string exceptionsDataJSON = JsonConvert.SerializeObject(_exceptions, Formatting.Indented);
    //        File.WriteAllText(Message._exceptionsDataPath, exceptionsDataJSON);
    //    }

    //}
}
