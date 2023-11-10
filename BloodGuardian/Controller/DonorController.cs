using BloodGuardian.Database;
using BloodGuardian.Models;
using BloodGuardian.View;
using BloodGuardian.Common;
using BloodGuardian.Controller.Interfaces;

namespace BloodGuardian.Controller
{

    internal class DonorController : IDonor,IAdmin
    {

        private DonorUI _donorUI;
        private IBloodBank _bankController;

        public DonorController()
        {
            _donorUI=new DonorUI();
            _bankController=new BloodBankController();
        }

        public Donor AddDonor()
        {

           
            Donor newDonor = _donorUI.CreateUser();
            DonorDBHandler.Instance.Add(newDonor);

            return newDonor;
            
        }

        public Donor UpdateProfile(Donor d)
        {
            Console.WriteLine(Message.SingleDashDesign);
            Console.WriteLine(Message.ShowOldDetails);
            Console.WriteLine("Name: " + d.Name);
            Console.WriteLine("User Name: " + d.UserName);
            Console.WriteLine("Age: " + d.Age);
            Console.WriteLine("Phone: " + d.Phone);
            Console.WriteLine("Email: " + d.Email);
            Console.WriteLine("State: " + d.State);
            Console.WriteLine("City: " + d.City);
            Console.WriteLine("Address: " + d.Address);
            Console.WriteLine("Password: " + d.Password);
            if (d.Role == roles.BloodBankManager) Console.WriteLine("Blood Bank Name: " + _bankController.FindBloodBankbyDonor(d).BankName);


            Console.WriteLine(Message.DoubleDashDesign);
            Console.WriteLine(Message.EnterNewDetails);

            Donor updatedDonor = _donorUI.UpdatedUserInfo(d);



            DonorDBHandler.Instance.UpdateDonor(d, updatedDonor);


            return updatedDonor;

        }

        public void AdminViewDonors(Donor d)
        {

            var donors = DonorDBHandler.Instance.Read();

            if (donors == null || donors.Count == 0)
            {
                Console.WriteLine(Message.NoRegisteredDonors);
                return;
            }

            donors.ForEach(donor => {

                Console.WriteLine(Message.SingleDashDesign);
                Console.WriteLine("id: " + donor.Donorid);
                Console.WriteLine("Name: " + donor.Name);
                Console.WriteLine("UserName: " + donor.UserName);
                Console.WriteLine("Age: " + donor.Age);
                Console.WriteLine("Phone: " + donor.Phone);
                Console.WriteLine("Email: " + donor.Email);
                Console.WriteLine("Address: " + donor.Address);
                Console.WriteLine("Blood Group: " + donor.BloodGrp);
                Console.WriteLine("Role: " + donor.Role.ToString());
                Console.WriteLine(Message.SingleDashDesign);

            }
            );


        }

        public Donor FindDonor(string username, string password)
        {

            var donorList = DonorDBHandler.Instance.Read();
            Donor d = new Donor();
            if (password == null)
            {
                d = donorList.FirstOrDefault((donor) => donor.UserName == username);

            }
            else
            {
                d = donorList.Find((donor) => donor.UserName == username && donor.Password == password);

            }

            return d;
        }

        public Donor FindDonorByBank(BloodBank bank)
        {
            var donor = DonorDBHandler.Instance.Read().Find((dn) => dn.UserName == bank.ManagerUserName);

            return donor;
        }

        public void AdminRemoveDonor(Donor d)
        {

            AdminViewDonors(d);

            Console.WriteLine();

            Console.Write(Message.EnterDonorId);
            int donorId = InputHandler.InputId();

            var donor = DonorDBHandler.Instance.Read().ElementAtOrDefault(donorId);

            if (donor == null)
            {
                Console.WriteLine(Message.WrongDonorId);
            }
            else if (donor.Role == roles.BloodBankManager)
            {
                RemoveBloodBankManager(donor);
            }
            else
            {
                RemoveDonor(donor);
            }
            



        }

        public void RemoveDonor(Donor d)
        {
            DonorDBHandler.Instance.Delete(d);
            

        }

        private void RemoveBloodBankManager(Donor d)
        {
            var bank = _bankController.FindBloodBankbyDonor(d);
            DonorDBHandler.Instance.Delete(d);
            _bankController.RemoveBloodBank(bank);

        }

        public void ViewBloodDonationHistory(Donor d)
        {
            var BankdepositLists = new Dictionary<BloodBank, List<BloodTransferReceipt>>();
            _bankController.GetBloodBanks().ForEach(bank =>
            {
                BankdepositLists.Add(bank, bank.Blood_Deposit_Record);
            });


            var isFound = false;

            foreach (KeyValuePair<BloodBank, List<BloodTransferReceipt>> entry in BankdepositLists)
            {


                entry.Value.ForEach((receipt) =>
                {
                    if (receipt.CustomerEmail == d.Email && receipt.CustomerPhone == d.Phone)
                    {
                        isFound = true;

                        Console.WriteLine();
                        Console.WriteLine(Message.SingleDashDesign);
                        Console.WriteLine($"Bank Name: {entry.Key.BankName}");
                        Console.WriteLine($"Address: {entry.Key.Address}");
                        Console.WriteLine($"Date: {receipt.BloodTransferDate}");
                        Console.WriteLine(Message.SingleDashDesign);


                    }
                });



            }

            if (!isFound)
            {
                Console.WriteLine(Message.NoBloodDonated);
            }


        }

        public void AddAdmin(Donor d)
        {
            AdminUI adminUI = new AdminUI();
            Donor newAdmin = adminUI.InputAdmin(d);

            newAdmin.Role = roles.Admin;

            DonorDBHandler.Instance.Add(newAdmin);


        }
    }
}
