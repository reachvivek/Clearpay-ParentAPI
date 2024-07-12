namespace PaymentAdvisoryPortalParentAPI.Dtos.LoginDtos
{
    public partial class LoginDto
    {
        public string otp { get; set; } = "";
        public string employeecode { get; set; } = "";
        public string password { get; set; } = "";
    }
}