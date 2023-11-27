using BloodGuardian.Common.Enums;
using BloodGuardian.Controller.Interfaces;
using BloodGuardian.Database.Interface;
using BloodGuardian.Models;

namespace BloodGuardian.Controller
{

    public class DonorController : IDonor, IAdmin
    {

        private IBloodBankDBHandler _bankDBHandler;
        private IDonorDBHandler _donorDBHandler;


        public DonorController(IBloodBankDBHandler bankDBHandler, IDonorDBHandler donorDBHandler)

        {
            _bankDBHandler = bankDBHandler;
            _donorDBHandler = donorDBHandler;
        }

        public List<Donor> GetDonors()
        {
            return _donorDBHandler.Get();
        }

        public void UpdateProfile(Donor oldDonor, Donor newDonor)
        { 

            _donorDBHandler.UpdateDonor(oldDonor, newDonor);

        }


        public Donor FindDonorByBank(BloodBank bank)
        {
            var donor = GetDonors().Find((dn) => dn.UserName.Equals(bank.ManagerUserName, StringComparison.InvariantCultureIgnoreCase));
            return donor;
        }

        public Donor FindDonorByUserName(string username)
        {
            var donorList = GetDonors();
            Donor d = donorList.Find((donor) => donor.UserName.Equals(username, StringComparison.InvariantCultureIgnoreCase));

            return d;
        }

        public void AdminRemoveDonor(Donor donor)
        {


            if (donor.Role == Roles.BloodBankManager)
            {
                RemoveBloodBankManager(donor);
            }
            else
            {
                RemoveDonor(donor);
            }




        }

        private void RemoveDonor(Donor d)
        {
            _donorDBHandler.Delete(d);


        }

        private void RemoveBloodBankManager(Donor d)
        {
            var bank = _bankDBHandler.FindBloodBankbyDonor(d);
            RemoveDonor(d);

            _bankDBHandler.Delete(bank);

        }

        public Dictionary<BloodBank, List<BloodTransferReceipt>> GetBloodDonationHistory(Donor d)
        {
            return _bankDBHandler.GetDonorBloodDonationHistory(d);
        }

        public void AddAdmin(Donor newAdmin)
        {

            newAdmin.Role = Roles.Admin;

            _donorDBHandler.Add(newAdmin);


        }
    }
}
