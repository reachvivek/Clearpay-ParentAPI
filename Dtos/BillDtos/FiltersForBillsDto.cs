namespace PaymentAdvisoryPortalParentAPI.Dtos.BillDtos
{
    public partial class FiltersForBillsDto
    {
        public string Banks { get; set; } = "";
        public string InvoiceMonths { get; set; } = "";
        public string InvoiceYears { get; set; } = "";
        public string States { get; set; } = "";
        public string LhoNames { get; set; } = "";
        public string ServiceTypes { get; set; } = "";
        public string GLCodes { get; set; } = "";
    }
}