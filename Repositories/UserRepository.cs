using System.Collections.Generic;
using System.Threading.Tasks;
using KycApp.Data;
using KycApp.Interfaces;
using KycApp.Models;
using Microsoft.EntityFrameworkCore;

namespace KycApp.Repositories
{
    public class UserRepository : IRepository<User>
    {
        private readonly ApplicationDbContext _dbContext;

        public UserRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await _dbContext.Users.ToListAsync();
        }

        public async Task<User> GetById(int id)
        {
            return await _dbContext.Users
                .FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<User> GetByEmail(string email)
        {
            return await _dbContext.Users
                .FirstOrDefaultAsync(u => u.EmailId == email);
        }

        public async Task Add(User entity)
        {
            await _dbContext.Users.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Update(User entity)
        {
            var existingEntity = await _dbContext.Users
                .FirstOrDefaultAsync(u => u.Id == entity.Id);
            if (existingEntity != null)
            {
                _dbContext.Entry(existingEntity).CurrentValues.SetValues(entity);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task Delete(int id)
        {
            var entity = await _dbContext.Users
                .FirstOrDefaultAsync(u => u.Id == id);
            if (entity != null)
            {
                _dbContext.Users.Remove(entity);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}