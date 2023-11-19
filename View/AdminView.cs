using BloodGuardian.Common;
using BloodGuardian.Common.Enums;
using BloodGuardian.Controller;
using BloodGuardian.Controller.Interfaces;
using BloodGuardian.View.Interfaces;
using BloodGuardian.Database;
using BloodGuardian.Models;

namespace BloodGuardian.View
{
    public class AdminView : IAdminView
    {

        public Donor InputAdminDetails()
        {

            Donor newAdmin = new Donor();

            Console.WriteLine(Message.EnterAdminName);
            newAdmin.Name = InputHandler.InputName(false);

            Console.WriteLine(Message.EnterAdminUserName);
            newAdmin.UserName = InputHandler.InputUserName(false);

            Console.WriteLine(Message.EnterAdminAge);
            newAdmin.Age = InputHandler.InputAge(false);


            Console.WriteLine(Message.EnterAdminPhone);
            newAdmin.Phone = InputHandler.InputPhone(false);

            Console.WriteLine(Message.EnterAdminEmail);
            newAdmin.Email = InputHandler.InputEmail(false);

            Console.WriteLine(Message.EnterAdminState);
            newAdmin.State = InputHandler.InputState(false);

            Console.WriteLine(Message.EnterAdminCity);
            newAdmin.City = InputHandler.InputCity(false);


            Console.WriteLine(Message.EnterAdminAddress);
            newAdmin.Address = InputHandler.InputAddress(false);


            Console.WriteLine(Message.EnterAdminPassword);
            newAdmin.Password = InputHandler.InputPassword(false);

            Console.WriteLine(Message.EnterBloodGroup);
            newAdmin.BloodGrp = InputHandler.InputBloodGroup(false);


            return newAdmin;

        }
    }
}
