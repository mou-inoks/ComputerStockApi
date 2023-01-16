namespace ComputerStockApi.Dtos
{
    public class BorrowComputerDto
    {
        public int Id { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public int ComputerId { get; set; }
        public int UserId { get; set; }
    }
}
