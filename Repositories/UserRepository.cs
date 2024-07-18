using System.Collections.Generic;
using System.Threading.Tasks;
using KycApp.Interfaces;
using KycApp.Models;

namespace KycApp.Repositories
{
    public class UserRepository : IRepository<User>
    {
        public Task<IEnumerable<User>> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Task<User> GetById(int id)
        {
            throw new System.NotImplementedException();
        }
        
        public Task<User> GetByEmail(string email)
        {
            throw new System.NotImplementedException();
        }

        public Task Add(User entity)
        {
            throw new System.NotImplementedException();
        }

        public Task Update(User entity)
        {
            throw new System.NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}