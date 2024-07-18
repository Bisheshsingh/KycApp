using System.Collections.Generic;
using System.Threading.Tasks;
using KycApp.Interfaces;
using KycApp.Models;

namespace KycApp.Repositories
{
    public class KycRepository : IRepository<KycRequest>
    {
        public Task<IEnumerable<KycRequest>> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Task<KycRequest> GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task Add(KycRequest entity)
        {
            throw new System.NotImplementedException();
        }

        public Task Update(KycRequest entity)
        {
            throw new System.NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}