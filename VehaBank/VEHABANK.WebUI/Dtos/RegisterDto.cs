namespace VEHABANK.WebUI.Dtos
{
    public class RegisterDto
    {
        public string BranchName { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string IdentityNumber { get; set; }
        public string BirthDate { get; set; } // "dd-MM-yyyy" formatında alınacak
        public string Password { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        //public string CustomerNumber { get; set; } // sistemde oluşturulabilir veya kullanıcıdan alınabilir
        public string AuthenticateAnswerForQuestion { get; set; }
        public int AuthenticateQuestion { get; set; }
    }
}
