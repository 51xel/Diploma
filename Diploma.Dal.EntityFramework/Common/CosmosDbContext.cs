using Diploma.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Diploma.Dal.EntityFramework.Common
{
    public class CosmosDbContext : DbContext
    {
        public CosmosDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Model> Models { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.HasAutoscaleThroughput(1000);
        }
    }
}
