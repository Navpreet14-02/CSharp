using BloodGuardianAPI.Models.DTO;
using System.Threading.Tasks;

namespace BloodGuardianAPI.Business.Interfaces
{
    public interface IAuthBusiness
    {
        Task<int> RegisterUser(RegisterUserModel user);
        Task<bool> LoginUser(LoginUserModel user);
        Task LogoutUser();
    }
}
