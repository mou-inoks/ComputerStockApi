using System.ComponentModel.DataAnnotations;

namespace ComputerStockApi.Models;

public class PurposeDao
{
    [Key]
    public int Id { get; set; }
    
    public string Purpose { get; set; }
}