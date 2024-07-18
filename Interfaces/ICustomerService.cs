using System.Threading.Tasks;
using KycApp.Models;

namespace KycApp.Interfaces
{
    public interface ICustomerService : IUserService
    {
        Task AddCustomer(User user);

        Task AddKycRequest(KycRequest request);
    }
}