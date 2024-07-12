namespace PaymentAdvisoryPortalParentAPI.Dtos.ForgotPasswordDtos
{
    public partial class ForgotPasswordVerificationDto
    {
        public string EmpMobNo { get; set; } = "";
        public int LoginAttempt { get; set; }
        public string Lockoutstartdate { get; set; } = "";
        public int Active { get; set; }
    }
}