using BloodGuardianAPI.Business.Interfaces;
using BloodGuardianAPI.Data;
using BloodGuardianAPI.DataAccess.Interfaces;
using BloodGuardianAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace BloodGuardianAPI.Business
{

    public class BloodDonationCampBusiness : IBloodDonationCampBusiness
    {

        private readonly IBloodDonationCampsData _campsData;

        public BloodDonationCampBusiness(IBloodDonationCampsData campsData)
        {
            _campsData = campsData;
        }

        public IEnumerable<BloodDonationCamp> GetBloodDonationCampsByBankId(int bankId)
        {
            var camps=  _campsData.GetAllBloodDonationCamps().Where(camp=>camp.BankId==bankId);
            return camps;
        }

        public BloodDonationCamp GetBloodDonationCampDetails(int campId)
        {
            var camp = _campsData.GetAllBloodDonationCamps().FirstOrDefault(c=>c.Id==campId);
            return camp;
        }

        public IEnumerable<BloodDonationCamp> GetAllBloodDonationCamps()
        {
            var camps = _campsData.GetAllBloodDonationCamps();
            return camps;
        }

        public void AddBloodDonationCamp(int bankid, BloodDonationCamp camp)
        {
            var newCamp = new BloodDonationCamp()
            {
                BankId = bankid,
                Camp_Address= camp.Camp_Address,
                Camp_Date = camp.Camp_Date.Date,
                Camp_State=camp.Camp_State,
                Camp_City = camp.Camp_City,
                Start_Time = camp.Start_Time.ToLocalTime(),
                End_Time = camp.End_Time.ToLocalTime(),

            };

            _campsData.AddBloodDonationCamp(newCamp);

        }

        public bool RemoveBloodDonationCamp(int campId)
        {
            var selCamp = _campsData.GetAllBloodDonationCamps().FirstOrDefault(camp=>camp.Id==campId);
            if (selCamp == null) return false;

            _campsData.RemoveBloodDonationCamp(selCamp);
            return true;
        }

        public IEnumerable<BloodDonationCamp> SearchBloodDonationCamps(string state,string city)
        {
            var camps = _campsData.GetAllBloodDonationCamps().Where(camp => camp.Camp_State == state && camp.Camp_City == city);
            return camps;
        
        }
    }
}
