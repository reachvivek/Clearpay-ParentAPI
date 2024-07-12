namespace PaymentAdvisoryPortalParentAPI.Dtos.LoginDtos
{
    public partial class LoginVerificationDto
    {
        public string EmpMobNo { get; set; } = "";
        public byte[] EmpPassword { get; set; } = new byte[0];
        public byte[] PasswordSalt { get; set; } = new byte[0];
        public int LoginAttempt { get; set; }
        public string Lockoutstartdate { get; set; } = "";
        public int Active { get; set; }
    }
}