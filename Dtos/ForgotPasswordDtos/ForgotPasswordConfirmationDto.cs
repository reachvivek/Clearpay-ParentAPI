namespace PaymentAdvisoryPortalParentAPI.Dtos.ForgotPasswordDtos
{
    public partial class ForgotPasswordConfirmationDto
    {
        public int UserID { get; set; }
        public string OTP { get; set; } = "";
        public int LoginAttempt { get; set; }
        public string Lockoutstartdate { get; set; } = "";
    }
}