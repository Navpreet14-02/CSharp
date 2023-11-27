using BloodGuardian.Models;

namespace BloodGuardian.Database.Interface
{
    public interface IRequestDBHandler : IDB<Request>
    {
        IRequestDBHandler Instance { get; }
    }
}
