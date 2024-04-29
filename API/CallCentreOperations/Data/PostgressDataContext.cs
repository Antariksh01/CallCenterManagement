using CallCentreOperations.Data.Interface;
using CallCentreOperations.Models;
using Microsoft.EntityFrameworkCore;

namespace CallCentreOperations.Data
{
    public class PostgressDataContext : DbContext , IDataContext
    {
        public PostgressDataContext(DbContextOptions<PostgressDataContext> options):base(options) { }

        public DbSet<Agent> Agents { get; set; }

        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Agent>().HasData(SeedAgents);
        }

        private static readonly Agent[] SeedAgents =
        {
            new Agent { Id = 101, AgentName = "James", Skills = new string[] { "Communication", "Problem Solving" }, AgentState = "NA" },
            new Agent { Id = 102, AgentName = "Roger", Skills = new string[] { "Communication", "Sales" }, AgentState = "NA" },
            new Agent { Id = 103, AgentName = "Sam", Skills = new string[] { "Communication", "HR" }, AgentState = "NA" },
            new Agent { Id = 104, AgentName = "Rafa", Skills = new string[] { "Management", "Team Work" }, AgentState = "NA" },
            new Agent { Id = 105, AgentName = "Ben", Skills = new string[] { "Sales", "Problem Solving" }, AgentState = "NA" }
        };


    }
}
