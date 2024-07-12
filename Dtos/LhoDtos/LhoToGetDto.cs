namespace PaymentAdvisoryPortalParentAPI.Dtos.LhoDtos
{
    public partial class LhoToGetDto {
        public int LhoID { get; set; }
        public string LhoName { get; set; } = "";
        public string State { get; set; } = "";
        public string UserIds { get; set; } = "";
    }
}