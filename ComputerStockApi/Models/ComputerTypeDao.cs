using System.ComponentModel.DataAnnotations;

namespace ComputerStockApi.Models
{
    public class ComputerTypeDao
    {
        [Key]
        public int Id { get; set; }
        public string Type { get; set; }
    }
}
