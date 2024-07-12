namespace PaymentAdvisoryPortalParentAPI.Dtos.LoginDtos
{
    public partial class LoginConfirmationDto
    {
        public int UserID { get; set; }
        public int LoginAttempt { get; set; }
        public string? Lockoutstartdate { get; set; }
        public string OTP { get; set; } = "";
        public byte[] EmpPassword { get; set; } = new byte[0];
        public byte[] PasswordSalt { get; set; } = new byte[0];
    }
}