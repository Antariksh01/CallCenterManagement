using CallCentreOperations.Models;
using Microsoft.EntityFrameworkCore;

namespace CallCentreOperations.Data.Interface
{
    public interface IDataContext
    {
        DbSet<Agent> Agents { get; set; }
        Task<int> SaveChangesAsync();
    }
}
