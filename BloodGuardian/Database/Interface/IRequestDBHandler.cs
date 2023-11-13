using BloodGuardian.Models;

namespace BloodGuardian.Database.Interface
{
    internal interface IRequestDBHandler : IDB<Request>
    {
        public IRequestDBHandler Instance { get; }
    }
}
