namespace ComputerStockApi.Dtos
{
    public class BorrowComputerDto
    {
        public int Id { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public ComputerDto Computer { get; set; }
        public UserDto User { get; set; }
        
        public string Comment { get; set; }
        
        public PurposeDto Purpose { get; set; }
    }
}
