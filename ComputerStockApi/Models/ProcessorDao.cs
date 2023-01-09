using System.ComponentModel.DataAnnotations;

namespace ComputerStockApi.Models
{
    public class ProcessorDao
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Niveau { get; set; }
        public string Vitesse { get; set; }
    }
}
