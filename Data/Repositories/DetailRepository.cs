using AgricultDetailMarket.Data.Interfaces;
using AgricultDetailMarket.Models;
using Microsoft.EntityFrameworkCore;

namespace AgricultDetailMarket.Data.Repositories
{
    public class DetailRepository : IBaseRepository<Detail>
    {
        private readonly ApplicationDbContext _db;

        public DetailRepository(ApplicationDbContext context)
        {
            _db = context;
        }

        public async Task Create(Detail entity)
        {
            await _db.Details.AddAsync(entity);
            await _db.SaveChangesAsync();
        }

        public async Task Delete(Detail entity)
        {
            _db.Details.Remove(entity);
            await _db.SaveChangesAsync();
        }

        public IQueryable<Detail> GetAll()
        {
            return _db.Details;
        }

        public async Task<Detail> Update(Detail entity)
        {
            _db.Details.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
    }
}
