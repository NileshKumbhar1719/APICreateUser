using APICreateUser.DTO;
using APICreateUser.Models;

namespace APICreateUser.Repository
{
    public interface IUserRepository
    {
        Task RegisterUser(RegisterUserDto registerUserDto,string ip);
        Task UpdateUser(TblUser tblUser );
        Task<TblUser> GetUserById(int id);

        Task<List<TblUser>> GetAllUsers();
        Task DeleteUser(int id);
    }
}
