using ComputerStockApi.Models;

namespace ComputerStockApi.Dtos
{
    public class ComputersDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ComputerTypeDao Type { get; set; }
        public string Brand { get; set; }
        public ProcessorDao Processor { get; set; }
        public int Ram { get; set; }
        public StateDao State { get; set; }
        public string Comment { get; set; }
    }
}
