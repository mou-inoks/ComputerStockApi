namespace ComputerStockApi.Dtos
{
    public class BorrowComputerDto
    {
        public int Id { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public ComputerDto Computers { get; set; }
        public UserDto Users { get; set; }
    }
}
