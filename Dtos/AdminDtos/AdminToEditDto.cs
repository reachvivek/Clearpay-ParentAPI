namespace PaymentAdvisoryPortalParentAPI.Dtos.AdminDtos
{
    public partial class AdminToEditDto
    {
        public int? UserId { get; set; }
        public string? EmpCode { get; set; } = "";
        public string? EmpName { get; set; } = "";
        public int? EmpRoleID { get; set; }
        public int? Active { get; set; }
        public int? ModifiedBy { get; set; }
        public string? EmpEmail { get; set; } = "";
        public string? EmpMobNo { get; set; } = "";
    }
}