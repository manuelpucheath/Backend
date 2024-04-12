using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Models;

[Table("Users")]
public class User
{
    [Key]
    public int       Id        { get; set; }
    [Required, MaxLength(100)]
    public string    UserName  { get; set; }
    [Required, MaxLength(500)]
    public string    Password  { get; set; }
    public DateTime  CreatedAt { get; set; } = DateTime.Now;
    public DateTime  UpdatedAt { get; set; } = DateTime.Now;
    public DateTime? DeletedAt { get; set; }
}