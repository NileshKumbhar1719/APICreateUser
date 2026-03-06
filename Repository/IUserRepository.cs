using APICreateUser.DTO;
using APICreateUser.Models;

namespace APICreateUser.Repository
{
    public interface IUserRepository
    {
        Task<string> RegisterUser(RegisterUserDto registerUserDto);
        Task UpdateUser(UpdateUser update,int id );
        Task<TblUser> GetUserById(int id);

        Task<List<TblUser>> GetAllUsers();
        Task DeleteUser(int id);

        Task<List<TblUserIp>> GetUserIPs();

    }
}
