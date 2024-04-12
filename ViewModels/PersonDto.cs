namespace Project.ViewModels;

public class PersonDto
{
    public int?           Id                         { get; set; }
    public string         Email                      { get; set; }
    public string         Name                       { get; set; }
    public string         LastName                   { get; set; }
    public ListSimpleItem IdentificationType         { get; set; }
    public string         IdentificationNumber       { get; set; }
    public string?        ConcatenatedIdentification { get; set; }
    public string?        FullName                   { get; set; }
}