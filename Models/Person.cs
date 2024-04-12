using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Project.Enums;

namespace Project.Models;

[Table("Persons")]
public class Person
{
    [Key]
    public         int                Id                         { get; set; }
    [Required, MaxLength(320), RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$")]
    public         string             Email                      { get; set; }
    [Required, MaxLength(100)]
    public         string             Name                       { get; set; }
    [Required, MaxLength(100)]
    public         string             LastName                   { get; set; }
    [Required]
    public         int                IdentificationTypeId       { get; set; }
    [Required, MaxLength(200)]
    public         string             IdentificationNumber       { get; set; }

    public         string             ConcatenatedIdentification
    {
        get
        {
            return $"{IdentificationNumber} {Enum.GetName(typeof(eIdentificationType), IdentificationTypeId)}";
        }
        set
        {
        }
    }

    public         string            FullName
    {
        get
        {
            return $"{Name} {LastName}";
        }
        set
        {
        }
    }
    public         DateTime           CreatedAt                  { get; set; } = DateTime.Now;
    public         DateTime           UpdatedAt                  { get; set; } = DateTime.Now;
    public         DateTime?          DeletedAt                  { get; set; }
    
    public virtual IdentificationType IdentificationType         { get; set; }
}