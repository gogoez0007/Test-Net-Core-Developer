namespace MyMvcApp.Models
{
    public class RegistrationModel
    {
        public string CompanyName { get; set; }
        public string NPWP { get; set; }
        public string DirectorName { get; set; }
        public string PICName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public IFormFile NPWPFile { get; set; }
        public IFormFile PowerOfAttorneyFile { get; set; }
        public bool AllowAccessAfterClosing { get; set; }
    }
}
