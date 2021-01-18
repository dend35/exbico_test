using System;
using API.Core.Config;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace API.Core.DAL
{
    public sealed class AppContext : DbContext
    {
        private readonly string _connectionString;
        public DbSet<VerdictModel> Users { get; set; }
        
        public AppContext(IOptions<DbOptions> options)
        {
            var config = options.Value;
            _connectionString = $"server={config.Server};user={config.User};password={config.Password};database={config.Schema};";
            Database.EnsureCreated();
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(
                _connectionString, 
                new MySqlServerVersion(new Version(8, 0, 11))
            );
        }
    }
}