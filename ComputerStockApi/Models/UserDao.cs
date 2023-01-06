using System.ComponentModel.DataAnnotations;

namespace ComputerStockApi.Models
{
    public class UserDao
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
