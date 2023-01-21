using ComputerStockApi.Daos;
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

        public IConfiguration Configuration { get; set; }
        public ComputerStockContext(IConfiguration conf) : base()
        {
            Configuration = conf;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Configuration.GetConnectionString("MacOsConnection"),
                    o =>
                    {
                        o.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery).UseRelationalNulls();
                        o.CommandTimeout((int)TimeSpan.FromMinutes(10).TotalSeconds);
                    }
                )
                .EnableSensitiveDataLogging();
        }

    }
}
