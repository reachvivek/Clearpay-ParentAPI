namespace PaymentAdvisoryPortalParentAPI.Dtos{
    public partial class BillsForDashboardDto
    {
        public int BillID { get; set; }
        public int IsPending { get; set; }
        public int IsProcessed { get; set; }
        public string InvoiceNo { get; set; } = "";
        public string BankName { get; set; } = "";
        public string State { get; set; } = "";
        public string LhoName { get; set; } = "";
        public string ServiceType { get; set; } = "";
        public int InvoiceYear { get; set; }
        public string InvoiceMonth { get; set; } = "";
        public string DateOfSubmission { get; set; } = "";
        public string AckProof { get; set; } = "";
        public decimal InvoiceAmountWithGST { get; set; }
        public string attachment { get; set; } = "";
    }
}