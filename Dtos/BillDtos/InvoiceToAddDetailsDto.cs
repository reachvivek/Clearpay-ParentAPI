namespace PaymentAdvisoryPortalParentAPI.Dtos.BillDtos{
    public partial class InvoiceToAddDetailsDto
    {
        public string InvoiceNo { get; set; } = "";
        public string BankName { get; set; } = "";
        public string State { get; set; } = "";
        public string LhoName { get; set; } = "";
        public string ServiceType { get; set; } = "";
        public int InvoiceYear { get; set; } 
        public int InvoiceMonth { get; set; }

    }
}