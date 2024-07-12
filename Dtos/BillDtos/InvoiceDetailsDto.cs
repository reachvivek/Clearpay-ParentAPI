namespace PaymentAdvisoryPortalParentAPI.Dtos.BillDtos
{
    public partial class InvoiceDetailsDto
    {
        public string InvoiceNo { get; set; } = "";
        public int IsPending { get; set; }
        public int IsProcessed { get; set; }
        public string LhoName { get; set; } = "";
        public string BankName { get; set; } = "";
        public string State { get; set; } = "";
        public string ServiceType { get; set; } = "";
        public string DateOfSubmission { get; set; } = "";
        public int? InvoiceYear { get; set; }
        public string? InvoiceMonth { get; set; } = "";
        public int AtmCount { get; set; }
        public string FinUserRemark { get; set; } = "";
        public int IsAcknowledged { get; set; }
        public string AckDate { get; set; } = "";
        public string AckProof { get; set; } = "";
        public string LhoUserRemark { get; set; } = "";
        public bool IsCreditNoteGiven { get; set; }
        public string CreditNoteNo { get; set; } = "";
        public string DebitNoteNo { get; set; } = "";
        public string DeductionRemarks { get; set; } = "";
        public decimal InvoiceAmount { get; set; }
        public decimal InvoiceAmountWithGST { get; set; }
        public decimal InvoiceAmountPaid { get; set; } 
        public decimal InvoiceAmountPaidNavision { get; set; } 
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
        public string FOSAttachment { get; set; } = "";
        public string DowntimeDetails { get; set; } = "";
        public string DowntimeAttachment { get; set; } = "";
        public string CashOutPenaltyDetails { get; set; } = "";
        public string CashOutPenaltyAttachment { get; set; } = "";
        public string HouseKeepingDetails { get; set; } = "";
        public string HouseKeepingAttachment { get; set; } = "";
        public string RejectBinDetails { get; set; } = "";
        public string RejectBinAttachment { get; set; } = "";
        public string ConsumableDetails { get; set; } = "";
        public string ConsumableAttachment { get; set; } = "";
        public string DOSDetails { get; set; } = "";
        public string DOSAttachment { get; set; } = "";
        public string ExcessBillingDetails { get; set; } = "";
        public string ExcessBillingAttachment { get; set; } = "";
        public string SlaPenaltyDetails { get; set; } = "";
        public string SlaPenaltyAttachment { get; set; } = "";
        // public string IncentiveAmountWithoutDNDetails { get; set; } = "";
        public string ReconPenaltyDetails { get; set; } = "";
        public string ReconPenaltyAttachment { get; set; } = "";
        public string EJDeductionDetails { get; set; } = "";
        public string EJDeductionAttachment { get; set; } = "";
        public string ESSFootagesDetails { get; set; } = "";
        public string ESSFootagesAttachment { get; set; } = "";
        public string ESurDowntimeDetails { get; set; } = "";
        public string ESurDowntimeAttachment { get; set; } = "";
        public string ESurNotInstalledDetails { get; set; } = "";
        public string ESurNotInstalledAttachment { get; set; } = "";
        public string CRAServicesDetails { get; set; } = "";
        public string CRAServicesAttachment { get; set; } = "";
        public string RobberyDetails { get; set; } = "";
        public string RobberyAttachment { get; set; } = "";
        public string CashMisappropriationDetails { get; set; } = "";
        public string CashMisappropriationAttachment { get; set; } = "";
    }
}
