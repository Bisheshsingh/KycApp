using System.Collections.Generic;
using System.Threading.Tasks;
using KycApp.Data;
using KycApp.Interfaces;
using KycApp.Models;
using Microsoft.EntityFrameworkCore;

namespace KycApp.Repositories
{
    public class KycRepository : IRepository<KycRequest>
    {
        private readonly ApplicationDbContext _dbContext;

        public KycRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<KycRequest>> GetAll()
        {
            return await _dbContext.KycRequests.ToListAsync();
        }

        public async Task<KycRequest> GetById(int id)
        {
            return await _dbContext.KycRequests
                .FirstOrDefaultAsync(r => r.KycId == id);
        }

        public async Task Add(KycRequest entity)
        {
            await _dbContext.KycRequests.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Update(KycRequest entity)
        {
            var existingEntity = await _dbContext.KycRequests
                .FirstOrDefaultAsync(r => r.KycId == entity.KycId);
            if (existingEntity != null)
            {
                _dbContext.Entry(existingEntity).CurrentValues.SetValues(entity);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task Delete(int id)
        {
            var entity = await _dbContext.KycRequests
                .FirstOrDefaultAsync(r => r.KycId == id);
            if (entity != null)
            {
                _dbContext.KycRequests.Remove(entity);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}