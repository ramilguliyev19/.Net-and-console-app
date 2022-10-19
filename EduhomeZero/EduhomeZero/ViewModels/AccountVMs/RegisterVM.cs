using System.ComponentModel.DataAnnotations;

namespace EduhomeZero.ViewModels.AccountVMs
{
    public class RegisterVM
    {
        [Required, MaxLength(128)]
        public string Firstname { get; set; }
        [Required, MaxLength(128)]
        public string Lastname { get; set; }
        [Required, MaxLength(128), DataType(DataType.EmailAddress)]
        public string Username { get; set; }
        [Required, MaxLength(128), DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required, MaxLength(128), DataType(DataType.EmailAddress), Compare(nameof(Email))]
        public string ConfirmEmail { get; set; }
        [Required, MaxLength(128), DataType(DataType.Password)]
        public string Password { get; set; }
        [Required, MaxLength(128), DataType(DataType.Password), Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }
    }
}
