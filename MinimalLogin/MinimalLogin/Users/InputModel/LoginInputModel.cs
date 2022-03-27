using System.ComponentModel.DataAnnotations;

namespace MinimalLogin.Users.InputModel
{
    public class LoginInputModel
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
