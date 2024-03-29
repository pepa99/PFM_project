using System.Linq.Expressions;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using PFM_project.Database.Entities;

namespace PFM_project.Database.Repositories
{
    public class TranasactionsDBContext : DbContext
    {
        public TranasactionsDBContext()
        {

        }
        public TranasactionsDBContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<TransactionsEntity> Transactions {get;set;}
        public DbSet<CategoryEntity> Categories{get;set;}
        public DbSet<TransactionCategoryMapping> TransactionCategoryMappings{get;set;}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}