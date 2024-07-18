using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KycApp.Models;

namespace KycApp.Interfaces
{
    public interface IUserService
    {
        Task VerifyCredentials(Credentials credentials);
        
        Task<List<KycRequest>> FetchAllKycRequests(int userId);

        Task<User> UpdateProfile(int id, User user);
    }
}