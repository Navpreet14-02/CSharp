using BloodGuardian.Common;
using BloodGuardian.Controller.Interfaces;
using BloodGuardian.Database.Interface;
using BloodGuardian.Models;

namespace BloodGuardian.Controller
{


    public class BloodDonationCampController : IAdminBloodDonationCamp, IBloodDonationCamp
    {

        private IBloodBankDBHandler _bankDBHandler;

        public BloodDonationCampController(IBloodBankDBHandler bankDBHandler)
        {
            _bankDBHandler = bankDBHandler;
        }

        public void OrganizeBloodDonationCamps(BloodBank bank, BloodDonationCamp newCamp)
        {


            newCamp.camp_id = bank.BloodDonationCamps.Count;

            bank.BloodDonationCamps.Add(newCamp);
            _bankDBHandler.UpdateBloodBank(bank, bank);

        }

        public void RemoveBloodDonationCamps(BloodBank bank, int campid)
        {

            var choosenCamp = bank.BloodDonationCamps.ElementAtOrDefault(campid);

            if (choosenCamp == null)
            {
                Console.WriteLine(Message.WrongCampId);
                return;
            }



            bank.BloodDonationCamps.Remove(choosenCamp);


            foreach (var (camp, ind) in bank.BloodDonationCamps.Select((val, i) => (val, i)))
            {
                camp.camp_id = ind;
            }

            _bankDBHandler.UpdateBloodBank(bank, bank);




        }

    }

}
