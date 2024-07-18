using System.Collections.Generic;
using System.Threading.Tasks;
using KycApp.Models;

namespace KycApp.Interfaces
{
    public interface IAdminService : IUserService
    {
        Task DeleteKycRequest(int id);

        Task<KycRequest> UpdateKycRequest(int id, KycRequest request);

        Task<List<KycRequest>> FetchAllKycRequests();
    }
}