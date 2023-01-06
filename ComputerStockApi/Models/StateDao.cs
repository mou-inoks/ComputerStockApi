using System.ComponentModel.DataAnnotations;

namespace ComputerStockApi.Models
{
    public class StateDao
    {
        [Key]
        public int Id { get; set; }
        public string State { get; set; }
    }
}
