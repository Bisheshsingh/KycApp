using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KycApp.Interfaces;
using KycApp.Models;
using KycApp.Repositories;

namespace KycApp.Services
{
    public class AdminService : IAdminService
    {
        private readonly KycRepository _kycRepository;
        private readonly UserRepository _userRepository;

        public AdminService(KycRepository kycRepository, UserRepository userRepository)
        {
            _kycRepository = kycRepository;
            _userRepository = userRepository;
        }

        public async Task VerifyCredentials(Credentials credentials)
        {
            var user = await _userRepository.GetByEmail(credentials.Email);

            if (user == null || user.Password != credentials.Password)
            {
                throw new UnauthorizedAccessException("Invalid credentials.");
            }
        }

        public async Task<List<KycRequest>> FetchAllKycRequests()
        {
            return (List<KycRequest>)await _kycRepository.GetAll();
        }

        public async Task<List<KycRequest>> FetchAllKycRequests(int userId)
        {
            var user = await _userRepository.GetById(userId);
            
            if (user == null)
            {
                return new List<KycRequest>();
            }

            return (List<KycRequest>)await _kycRepository.GetAll();
        }

        public async Task<User> UpdateProfile(int id, User user)
        {
            var existingUser = await _userRepository.GetById(id);
            
            if (existingUser == null)
            {
                throw new KeyNotFoundException("User not found.");
            }

            existingUser.FullName = user.FullName;
            existingUser.EmailId = user.EmailId;
            existingUser.Password = user.Password;

            await _userRepository.Update(existingUser);

            return existingUser;
        }

        public async Task DeleteKycRequest(int id)
        {
            await _kycRepository.Delete(id);
        }

        public async Task<KycRequest> UpdateKycRequest(int id, KycRequest request)
        {
            var existingRequest = await _kycRepository.GetById(id);
            
            if (existingRequest == null)
            {
                throw new KeyNotFoundException("KYC request not found.");
            }

            existingRequest.DocType = request.DocType;
            existingRequest.DocData = request.DocData;
            existingRequest.Status = request.Status;
            
            await _kycRepository.Update(existingRequest);

            return existingRequest;
        }
    }
} 