using ComputerStockApi.Daos;
using ComputerStockApi.Dtos;
using ComputerStockApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ComputerStockApi.Data
{
    public class ComputerStockContext : DbContext
    {
        public DbSet<ComputerDao> Computers { get; set; }
        public DbSet<BorrowComputerDao> BorrowComputer { get; set; }
        public DbSet<UserDao> Users { get; set; }
        public DbSet<ComputerTypeDao> ComputerType { get; set; }
        public DbSet<ProcessorDao> Processor { get; set; }
        public DbSet<StateDao> State{ get; set; }
        public DbSet<PurposeDao> Purpose{ get; set; }

        public IConfiguration Configuration { get; set; }
        public ComputerStockContext(IConfiguration conf) : base()
        {
            Configuration = conf;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Configuration.GetConnectionString("DefaultConnectionString"),
                    o =>
                    {
                        o.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery).UseRelationalNulls();
                        o.CommandTimeout((int)TimeSpan.FromMinutes(10).TotalSeconds);
                    }
                )
                .EnableSensitiveDataLogging();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ComputerTypeDao>().HasData(
                new ComputerTypeDao() { Id = 1, Type = "Laptop"},
                new ComputerTypeDao() { Id = 2, Type = "Mini-Computer"},
                new ComputerTypeDao() { Id = 3, Type = "PC" }
                );
            modelBuilder.Entity<StateDao>().HasData(
                new StateDao() { Id = 1, State = "New"},
                new StateDao() { Id = 2, State = "Used"},
                new StateDao() { Id = 3, State = "Broken" }
            );
            modelBuilder.Entity<PurposeDao>().HasData(
                new PurposeDao() { Id = 1, Purpose = "Office"},
                new PurposeDao() { Id = 2, Purpose = "Remote"}
            );
        }

    }
}
