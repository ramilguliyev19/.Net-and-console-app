using System.ComponentModel.DataAnnotations;

namespace EduhomeZero.ViewModels.AccountVMs
{
    public class LoginVM
    {
        [Required, MaxLength(128), DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required, MaxLength(128), DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
