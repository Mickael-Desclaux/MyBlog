using System.ComponentModel.DataAnnotations;

namespace MyBlog.WebApp.Model;

public class User
{

    public User()
    {
        Password = string.Empty;
        Email = string.Empty;
    }
    
    public User(string password, string email)
    {
        Password = password;
        Email = email;
    }

    public int UserId { get; set; }

    [Required] [EmailAddress] public string Email { get; set; }

    [Required]
    [StringLength(100, ErrorMessage = "The password must contain at least 6 characters.", MinimumLength = 6)]
    [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).+$",
        ErrorMessage =
            "The password must contain at least one uppercase letter, one lowercase letter and one number.")]
    public string Password { get; set; }
}