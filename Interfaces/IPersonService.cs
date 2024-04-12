using Project.ViewModels;

namespace Project.Interfaces;

public interface IPersonService : IHandleRequestStatus, ICrud<PersonDto>
{
    
}