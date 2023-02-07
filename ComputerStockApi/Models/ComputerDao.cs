using ComputerStockApi.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComputerStockApi.Daos
{
    public class ComputerDao
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }    

        [ForeignKey("FK_Computer_ComputerType_Id")]
        public int TypeId { get; set; }
        public ComputerTypeDao Type { get; set; }
        public string Brand { get; set; }

        [ForeignKey("Fk_Computer_Processor_Id")]
        public int ProcessorId { get; set; }
        public ProcessorDao Processor { get; set; }
        public int Ram { get; set; }

        [ForeignKey("FK_Computer_State_Id")]
        public int StateId { get; set; }
        public StateDao State { get; set; }

    }
}
