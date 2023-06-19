using Api.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Context
{
    public class ApiContext : DbContext
    {
        protected override void OnConfiguring
       (DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "RhitmoTest");
        }
        public DbSet<UserEntity> User { get; set; }
    }
}

