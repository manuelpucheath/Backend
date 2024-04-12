using Project.Models;

namespace Project;
using Microsoft.EntityFrameworkCore;

public class Context : DbContext
{
    public DbSet<Person>             Persons             { get; set; }
    public DbSet<User>               Users               { get; set; }
    public DbSet<IdentificationType> IdentificationTypes { get; set; }
    
    public Context(DbContextOptions<Context> options): base(options){}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Person>(persons =>
        {
            persons.HasOne<IdentificationType>(x => x.IdentificationType).WithMany(x => x.Persons).HasForeignKey(x => x.IdentificationTypeId);
            persons.Property(x => x.Email);
            persons.Property(x => x.Name);
            persons.Property(x => x.LastName);
            persons.Property(x => x.IdentificationNumber);
            persons.Property(x => x.ConcatenatedIdentification);
            persons.Property(x => x.FullName);
            persons.Property(x => x.CreatedAt);
            persons.Property(x => x.UpdatedAt);
            persons.Property(x => x.DeletedAt);
        });
        
        modelBuilder.Entity<User>(users =>
        {
            users.Property(x => x.UserName);
            users.Property(x => x.Password);
            users.Property(x => x.CreatedAt);
            users.Property(x => x.UpdatedAt);
            users.Property(x => x.DeletedAt);
        });

        List<IdentificationType> identificationTypes = new List<IdentificationType>()
        {
            new IdentificationType()
            {
                Id = 1,
                Name = "Cedula de ciudadania"
            },
            new IdentificationType()
            {
                Id = 2,
                Name = "Tarjeta de identidad"
            },
            new IdentificationType()
            {
                Id = 3,
                Name = "Registro Civil"
            },
            new IdentificationType()
            {
                Id = 4,
                Name = "Cedula de Extranjeria"
            }
        };
        modelBuilder.Entity<IdentificationType>(identificationType =>
        {
            identificationType.Property(x => x.Name);
            identificationType.Property(x => x.CreatedAt);
            identificationType.Property(x => x.UpdatedAt);
            identificationType.Property(x => x.DeletedAt);
            identificationType.HasData(identificationTypes);
        });
    }
}