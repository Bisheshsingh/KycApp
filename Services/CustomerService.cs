using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KycApp.Interfaces;
using KycApp.Models;
using KycApp.Repositories;

namespace KycApp.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly KycRepository _kycRepository;
        private readonly UserRepository _userRepository;

        public CustomerService(KycRepository kycRepository, UserRepository userRepository)
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

        public async Task<List<KycRequest>> FetchAllKycRequests(int userId)
        {
            var user = await _userRepository.GetById(userId);
            if (user == null)
            {
                throw new KeyNotFoundException("User not found.");
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

        public async Task AddCustomer(User user)
        {
            await _userRepository.Add(user);
        }

        public async Task AddKycRequest(KycRequest request)
        {
            await _kycRepository.Add(request);
        }
    }
}
