using System.ComponentModel.DataAnnotations;
using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

[Table("Users")]
public class SignUpModel : BaseModel
{
    [Required, StringLength(50)]
    [PrimaryKey("UserName", false)]
    public string? UserName { get; set; }

    [Required, EmailAddress]
    [PrimaryKey("Email", false)]
    public string? Email { get; set; }

    [Required, MinLength(6)]
    [PrimaryKey("Password", false)]
    public string? Password { get; set; }

    [Compare("Password", ErrorMessage = "Passwords do not match")]
    [PrimaryKey("Password", false)]
    public string? ConfirmPassword { get; set; }
}