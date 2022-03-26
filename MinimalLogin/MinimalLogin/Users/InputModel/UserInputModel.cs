using System.ComponentModel.DataAnnotations;

namespace MinimalLogin.Users.InputModel;

public class UserInputModel
{
    [Required]
    public string Name { get; set; }
    [Required]
    public DateTime Birthday { get; set; }
    [Required]
    public string Gender { get; set; }
    [Required]
    public string PreferedProgramingLanguage { get; set; }
    [Required]
    public string UserName { get; set; }
    [Required]
    public string Password { get; set; }
}

