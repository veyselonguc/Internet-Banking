namespace VEHABANK.WebUI.Models
{
    public class AccountViewModel
    {
        public string IBAN { get; set; }
        public int BranchId { get; set; }
        public string AccountNumber { get; set; }
        public decimal Balance { get; set; }
        public string Currency { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
