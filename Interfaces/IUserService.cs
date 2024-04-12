using Project.ViewModels;

namespace Project.Interfaces;

public interface IUserService : IHandleRequestStatus, ICreate<UserDto>
{
    Task<UserDto> Login(UserDto userDto);
}