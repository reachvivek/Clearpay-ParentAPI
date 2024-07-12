namespace PaymentAdvisoryPortalParentAPI.Dtos.AdminDtos
{
    public partial class AdminToAddDto
    {
        public string EmpCode { get; set; } = "";
        public string EmpName { get; set; } = "";
        public int EmpRoleID { get; set; }
        public int Active { get; set; }
        public string EmpEmail { get; set; } = "";
        public string EmpMobNo { get; set; } = "";

    }
}