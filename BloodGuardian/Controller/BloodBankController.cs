﻿using BloodGuardian.Common;
using BloodGuardian.Database;
using BloodGuardian.Models;
using BloodGuardian.View;

namespace BloodGuardian.Controller
{
    internal class BloodBankController
    {

        private BloodBankManagerUI _bloodbankManagerUI;

        public BloodBankController()
        {
            _bloodbankManagerUI = new BloodBankManagerUI();
        }

        public void AddBloodBank(Donor d)
        {

            BloodBank bank = _bloodbankManagerUI.createBloodBank(d);
            BloodBankDBHandler.Instance.Add(bank);

        }

        public List<BloodBank> GetBloodBanks()
        {
            return BloodBankDBHandler.Instance.Read();
        }

        public BloodBank FindBloodBankbyId(int bankid)
        {
            var banks = BloodBankDBHandler.Instance.Read();
            if (bankid < 0 || bankid > banks.Count) return null;
            return banks[bankid];

        }

        public BloodBank FindBloodBankbyDonor(Donor d)
        {
            var banks = BloodBankDBHandler.Instance.Read();
            return banks.Find((b) => b.ManagerUserName == d.UserName);
        }

        public void UpdateBloodBankDetails(Donor oldDonor, Donor newDonor)
        {
            var bank = FindBloodBankbyDonor(oldDonor);

            var newBank = new BloodBank();
                
            Console.WriteLine(Message.EnterBloodBankName);
            var newBankName = InputHandler.InputName(true); 


            newBank.BankName = newBankName == String.Empty ? bank.BankName : newBankName;

            newBank.ManagerEmail = newDonor.Email;
            newBank.ManagerName = newDonor.Name;
            newBank.Address = newDonor.Address;
            newBank.State = newDonor.State;
            newBank.City = newDonor.City;
            newBank.Contact = newDonor.Phone;
            newBank.BloodUnits = bank.BloodUnits;
            newBank.Blood_Deposit_Record = bank.Blood_Deposit_Record;
            newBank.Blood_WithDrawal_Record = bank.Blood_WithDrawal_Record;
            newBank.BloodDonationCamps = bank.BloodDonationCamps;
            newBank.ManagerUserName = bank.ManagerUserName;



            BloodBankDBHandler.Instance.UpdateBloodBank(bank, newBank);

        }

        public void AdminViewBloodBanks(Donor d)
        {
            BloodBankDBHandler.Instance.Read().ForEach(bank =>
            {
                Console.WriteLine(Message.SingleDashDesign);
                Console.WriteLine("Id: " + bank.BankId);
                Console.WriteLine("Bank Name: " + bank.BankName);
                Console.WriteLine("Bank UserName: " + bank.ManagerUserName);
                Console.WriteLine("Manager Name: " + bank.ManagerName);
                Console.WriteLine("Manager Email: " + bank.ManagerEmail);
                Console.WriteLine("Manager Contact: " + bank.Contact);
                Console.WriteLine("Address: " + bank.Address);
                Console.WriteLine(Message.SingleDashDesign);

            });

        }


        public void AdminRemoveBloodBank(Donor d)
        {
            AdminViewBloodBanks(d);

            Console.WriteLine(Message.DoubleDashDesign);
            Console.WriteLine(Message.EnterBloodBankId);


            int bankid = InputHandler.InputId();

            var bank = FindBloodBankbyId(bankid);

            if (bank == null)
            {
                Console.WriteLine(Message.WrongBankId);
            }
            else
            {
                DonorController donorController = new DonorController();
                var donor = donorController.FindDonorByBank(bank);
                donorController.RemoveDonor(donor);
                RemoveBloodBank(bank);
            }


        }

        public void RemoveBloodBank(BloodBank bank)
        {
            BloodBankDBHandler.Instance.Delete(bank);
        }


        public void UpdateDepositBloodRecord(BloodBank bank)
        {

            BloodTransferReceipt blood = _bloodbankManagerUI.CreateBloodDepositRecord();

            blood.Id = bank.Blood_Deposit_Record.Count;
            bank.Blood_Deposit_Record.Add(blood);
            BloodBankDBHandler.Instance.UpdateBloodBank(bank, bank);

            BloodBankDBHandler.Instance.UpdateBloodTransferRecord(bank, blood.BloodGroup, blood.BloodAmount, true);



        }


        public void UpdateWithdrawBloodRecord(BloodBank bank)
        {


            BloodTransferReceipt blood = _bloodbankManagerUI.CreateBloodWithdrawRecord();


            blood.Id = bank.Blood_WithDrawal_Record.Count;

            bank.Blood_WithDrawal_Record.Add(blood);
            BloodBankDBHandler.Instance.UpdateBloodBank(bank, bank);

            BloodBankDBHandler.Instance.UpdateBloodTransferRecord(bank, blood.BloodGroup, blood.BloodAmount, false);




        }
    }
}