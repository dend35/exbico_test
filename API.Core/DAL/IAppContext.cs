using Microsoft.EntityFrameworkCore;

namespace API.Core.DAL
{
    public interface IAppContext
    {
        public DbSet<VerdictModel> Verdict { get; set; }
        public int SaveChanges();
    }
}