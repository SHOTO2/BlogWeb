using BlogWeb.Dtos.Users;
using BlogWeb.Models;

namespace BlogWeb.Interfaces
{
    public interface IUserRepository
    {
        Task<Users?> Createuser(CreateUserDto createUser);
        Task<string?> LoginUser(LoginUserDto loginUser);
        Task<Users?> Updateuser(UpdateUserDto updateUser);

    }
}
