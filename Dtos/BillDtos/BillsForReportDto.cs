namespace PaymentAdvisoryPortalParentAPI.Dtos.BillDtos
{
    public partial class BillsForReportDto
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
        
        // Invoice Details
        public string CNDetails { get; set; } = "";
        public string IncentiveDNDetails { get; set; } = "";
        
        // Categorical Details
        public string FOSDetails { get; set; } = "";
        public string DowntimeDetails { get; set; } = "";
        public string CashOutPenaltyDetails { get; set; } = "";
        public string HouseKeepingDetails { get; set; } = "";
        public string RejectBinDetails { get; set; } = "";
        public string ConsumableDetails { get; set; } = "";
        public string DOSDetails { get; set; } = "";
        public string ExcessBillingDetails { get; set; } = "";
        public string IncentiveAmountWithoutDNDetails { get; set; } = "";
        public string ReconPenaltyDetails { get; set; } = "";
        public string EJDeductionDetails { get; set; } = "";
        public string ESSFootagesDetails { get; set; } = "";
        public string ESurDowntimeDetails { get; set; } = "";
        public string ESurNotInstalledDetails { get; set; } = "";
        public string CRAServicesDetails { get; set; } = "";
        public string RobberyDetails { get; set; } = "";
        public string CashMisappropriationDetails { get; set; } = "";
    }
}