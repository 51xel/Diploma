using Diploma.Domain.Actions;
using Diploma.Domain.Algorithms;
using Diploma.Domain.Models;
using Diploma.Domain.TradeActions;
using Diploma.Domain.Users;
using Diploma.Domain.Users.AuthenticationTypes;
using Diploma.Domain.Wallets;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Diploma.Dal.EntityFramework.Common
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Model> Models { get; set; }
        public DbSet<Algorithm> Algorithms { get; set; }
        public DbSet<TradeAction> TradeActions { get; set; }
        public DbSet<TradePair> TradePairs { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<EmailAndPasswordAuthType> EmailAndPasswordAuthTypes { get; set; }
        public DbSet<Wallet> Wallets { get; set; }

        public ApplicationDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
