namespace PaymentAdvisoryPortalParentAPI.Models
{
    public partial class User
    {
        public int? UserId { get; set; }
        public string? EmpCode { get; set; } = "";
        public string? EmpName { get; set; } = "";
        public int? EmpRoleID { get; set; }
        public int? Active { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public string? EmpEmail { get; set; } = "";
        public string? EmpMobNo { get; set; } = "";
        public string? EmpPassword { get; set; } = "";
        public string? EmpOldPassword { get; set; } = "";
        public string? EmpOldPassword_1 { get; set; } = "";
        public string? EmpOldPassword_2 { get; set; } = "";
        public int? LoginAttempt { get; set; }
        public DateTime? LockoutStartDate { get; set; }
        public DateTime? LastLoginDate { get; set; }
        public DateTime? SetInactiveDate { get; set; }
        public DateTime? NewPassCreateDate { get; set; }
        public DateTime? PassExpireDate { get; set; }

    }
}