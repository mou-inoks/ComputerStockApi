using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ComputerStockApi.Daos;

namespace ComputerStockApi.Models
{
    public class BorrowComputerDao
    {
        [Key]
        public int Id { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime? ToDate { get; set; }

        [ForeignKey("FK_BorrowComputer_Computer_Id")]
        public int ComputerId { get; set; }
        public ComputerDao Computer { get; set; }

        [ForeignKey("FK_BorrowComputer_User_UserId")]

        public int UserId { get; set; }

        public UserDao User { get; set; }

        public string Comment { get; set; }
        
    }
}
