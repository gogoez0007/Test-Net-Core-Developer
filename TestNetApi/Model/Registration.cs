using System.ComponentModel.DataAnnotations;

public class RegistrationModel
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Company Name is required.")]
    [StringLength(255, ErrorMessage = "Company Name can't be longer than 255 characters.")]
    public string CompanyName { get; set; }

    [Required(ErrorMessage = "NPWP is required.")]
    [StringLength(50, ErrorMessage = "NPWP can't be longer than 50 characters.")]
    public string NPWP { get; set; }

    [Required(ErrorMessage = "Director Name is required.")]
    [StringLength(255, ErrorMessage = "Director Name can't be longer than 255 characters.")]
    public string DirectorName { get; set; }

    [Required(ErrorMessage = "PIC Name is required.")]
    [StringLength(255, ErrorMessage = "PIC Name can't be longer than 255 characters.")]
    public string PICName { get; set; }

    [Required(ErrorMessage = "Email is required.")]
    [EmailAddress(ErrorMessage = "Invalid Email Address.")]
    [StringLength(255, ErrorMessage = "Email can't be longer than 255 characters.")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Phone Number is required.")]
    [StringLength(15, ErrorMessage = "Phone Number can't be longer than 15 characters.")]
    public string PhoneNumber { get; set; }

    public string NPWPFilePath { get; set; }

    public string PowerOfAttorneyFilePath { get; set; }

    [Required(ErrorMessage = "Allow Access After Closing is required.")]
    public bool AllowAccessAfterClosing { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
}
