using CallCentreOperations.Data.Interface;
using CallCentreOperations.Models;
using Microsoft.EntityFrameworkCore;
using MongoDB.EntityFrameworkCore.Extensions;

namespace CallCentreOperations.Data
{
    public class MongoDbDataContext : DbContext, IDataContext
    {
        public MongoDbDataContext(DbContextOptions<MongoDbDataContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Agent>().ToCollection("agents");
        }

        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }

        public DbSet<Agent> Agents { get; set; }
    }
}
