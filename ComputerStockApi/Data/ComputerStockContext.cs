using ComputerStockApi.Daos;
using ComputerStockApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ComputerStockApi.Data
{
    public class ComputerStockContext : DbContext
    {
        public ComputerStockContext(DbContextOptions<ComputerStockContext> options):base(options) { }
        public DbSet<ComputerDao> Computers { get; set; }
        public DbSet<BorrowComputerDao> BorrowComputer { get; set; }
        public DbSet<UserDao> Users { get; set; }
        public DbSet<ComputerTypeDao> ComputerType { get; set; }
        public DbSet<ProcessorDao> Processor { get; set; }
        public DbSet<StateDao> State{ get; set; }

    }
}
