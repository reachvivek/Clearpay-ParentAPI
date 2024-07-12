namespace PaymentAdvisoryPortalParentAPI.Dtos.BillDtos
{
    public partial class DashboardBillsResponseDto
    {
        public int TotalBills { get; set; }
        public int ProcessedBills { get; set; }
        public int PendingBills { get; set; }
        public IEnumerable<BillsForDashboardDto> Bills { get; set; } = [];
    }
}