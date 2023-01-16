using ComputerStockApi.Models;

namespace ComputerStockApi.Dtos
{
    public class ComputerDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ComputerTypeDto Type { get; set; }
        public string Brand { get; set; }
        public ProcessorDto Processor { get; set; }
        public int Ram { get; set; }
        public StateDto State { get; set; }
        public string Comment { get; set; }
    }
}
