namespace PaymentAdvisoryPortalParentAPI.Dtos.BillDtos{
    public partial class InvoiceBase64Dto
    {
        public string Base64 { get; set; } = "";
        public string Message { get; set; } = "";
        public string StatusCode { get; set; } = "";
        public string Success { get; set; } = "";
    }
}