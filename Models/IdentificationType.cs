using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Models;

[Table("IdentificationTypes")]
public class IdentificationType
{
    [Key]
    public         int          Id        { get; set; }
    [Required, MaxLength(320)]
    public         string       Name      { get; set; }
    public         DateTime     CreatedAt { get; set; } = DateTime.Now;
    public         DateTime     UpdatedAt { get; set; } = DateTime.Now;
    public         DateTime?    DeletedAt { get; set; }
    public virtual List<Person> Persons   { get; set; }
}