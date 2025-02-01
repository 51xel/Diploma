using Diploma.Domain.Algorithms;
using Diploma.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Diploma.Dal.EntityFramework.Common
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Model> Models { get; set; }
        public DbSet<Algorithm> Algorithms { get; set; }

        public ApplicationDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
