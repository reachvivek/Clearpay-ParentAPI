namespace PaymentAdvisoryPortalParentAPI.Dtos.BillDtos{
    public partial class InvoiceDetailsToUpdateDto{
        public int BillID { get; set; }
        public string InvoiceNo { get; set; } = "";
        public decimal InvoiceAmountPaid { get; set; } 
        public string InvoiceAmountPaidDate { get; set; } = "";
        
        // All the Invoice Details
        public string CNDetails { get; set; } = "";
        public string IncentiveDNDetails { get; set; } = "";
        public string WithoutDNDetails { get; set; } = "";
        public string WithoutCNDetails { get; set; } = "";
        public string TDSDetails { get; set; } = "";
        public string GSTTDSDetails { get; set; } = "";
        public string RemainingDetails { get; set; } = "";
        
        // All the categorical details
        public string FOSDetails { get; set; } = "";
        public string DowntimeDetails { get; set; } = "";
        public string CashOutPenaltyDetails { get; set; } = "";
        public string HouseKeepingDetails { get; set; } = "";
        public string RejectBinDetails { get; set; } = "";
        public string ConsumableDetails { get; set; } = "";
        public string DOSDetails { get; set; } = "";
        public string ExcessBillingDetails { get; set; } = "";
        public string SlaPenaltyDetails { get; set; } = "";
        // public string IncentiveAmountWithoutDNDetails { get; set; } = "";
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