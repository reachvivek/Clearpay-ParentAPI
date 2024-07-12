namespace PaymentAdvisoryPortalParentAPI.Dtos
{
    public partial class FilesToUpload
    {
        public int BillID { get; set; }
        public int Type { get; set; }  
        public IEnumerable<IFormFile> Files { get; set; } = [];

    }
}