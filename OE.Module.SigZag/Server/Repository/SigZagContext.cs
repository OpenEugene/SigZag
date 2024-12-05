using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Oqtane.Modules;
using Oqtane.Repository;
using Oqtane.Infrastructure;
using Oqtane.Repository.Databases.Interfaces;

namespace OE.Module.SigZag.Repository
{
    public class SigZagContext : DBContextBase, ITransientService, IMultiDatabase
    {
        public virtual DbSet<Models.SigZag> SigZag { get; set; }

        public SigZagContext(IDBContextDependencies DBContextDependencies) : base(DBContextDependencies)
        {
            // ContextBase handles multi-tenant database connections
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Models.SigZag>().ToTable(ActiveDatabase.RewriteName("OESigZag"));
        }
    }
}
