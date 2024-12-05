using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
using Oqtane.Modules;
using System.Threading.Tasks;

namespace OE.Module.SigZag.Repository
{
    public class SigZagRepository : ITransientService
    {
        private readonly IDbContextFactory<SigZagContext> _factory;

        public SigZagRepository(IDbContextFactory<SigZagContext> factory)
        {
            _factory = factory;
        }

        public IEnumerable<Models.SigZag> GetSigZags()
        {
            using var db = _factory.CreateDbContext();
            return db.SigZag.ToList();
        }

        public Models.SigZag GetSigZag(int SigZagId)
        {
            return GetSigZag(SigZagId, true);
        }

        public Models.SigZag GetSigZag(int SigZagId, bool tracking)
        {
            using var db = _factory.CreateDbContext();
            if (tracking)
            {
                return db.SigZag.Find(SigZagId);
            }
            else
            {
                return db.SigZag.AsNoTracking().FirstOrDefault(item => item.SigZagId == SigZagId);
            }
        }

        public Models.SigZag AddSigZag(Models.SigZag SigZag)
        {
            using var db = _factory.CreateDbContext();
            db.SigZag.Add(SigZag);
            db.SaveChanges();
            return SigZag;
        }

        public Models.SigZag UpdateSigZag(Models.SigZag SigZag)
        {
            using var db = _factory.CreateDbContext();
            db.Entry(SigZag).State = EntityState.Modified;
            db.SaveChanges();
            return SigZag;
        }

        public void DeleteSigZag(int SigZagId)
        {
            using var db = _factory.CreateDbContext();
            Models.SigZag SigZag = db.SigZag.Find(SigZagId);
            db.SigZag.Remove(SigZag);
            db.SaveChanges();
        }


        public async Task<IEnumerable<Models.SigZag>> GetSigZagsAsync(int ModuleId)
        {
            using var db = _factory.CreateDbContext();
            return await db.SigZag.Where(item => item.ModuleId == ModuleId).ToListAsync();
        }

        public async Task<Models.SigZag> GetSigZagAsync(int SigZagId)
        {
            return await GetSigZagAsync(SigZagId, true);
        }

        public async Task<Models.SigZag> GetSigZagAsync(int SigZagId, bool tracking)
        {
            using var db = _factory.CreateDbContext();
            if (tracking)
            {
                return await db.SigZag.FindAsync(SigZagId);
            }
            else
            {
                return await db.SigZag.AsNoTracking().FirstOrDefaultAsync(item => item.SigZagId == SigZagId);
            }
        }

        public async Task<Models.SigZag> AddSigZagAsync(Models.SigZag SigZag)
        {
            using var db = _factory.CreateDbContext();
            db.SigZag.Add(SigZag);
            await db.SaveChangesAsync();
            return SigZag;
        }

        public async Task<Models.SigZag> UpdateSigZagAsync(Models.SigZag SigZag)
        {
            using var db = _factory.CreateDbContext();
            db.Entry(SigZag).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return SigZag;
        }

        public async Task DeleteSigZagAsync(int SigZagId)
        {
            using var db = _factory.CreateDbContext();
            Models.SigZag SigZag = db.SigZag.Find(SigZagId);
            db.SigZag.Remove(SigZag);
            await db.SaveChangesAsync();
        }
    }
}
