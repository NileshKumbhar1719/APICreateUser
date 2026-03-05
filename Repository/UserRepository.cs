using APICreateUser.DTO;
using APICreateUser.Models;
using Microsoft.EntityFrameworkCore;

namespace APICreateUser.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApicreateContext _context;

        public UserRepository(ApicreateContext context) 
        {
            _context= context;

        }

        public async Task DeleteUser(int id)
        {
            var data = await _context.TblUsers.FindAsync(id);

            var IPs = await _context.TblUserIps.Where(x => x.UserId == id).ToListAsync();
            
            _context.TblUserIps.RemoveRange(IPs);
            _context.TblUsers.Remove(data);

            await _context.SaveChangesAsync();

        }

        public async Task<List<TblUser>> GetAllUsers()
        {
            return await _context.TblUsers.ToListAsync();
        }

        public async Task<TblUser> GetUserById(int id)
        {
            return await _context.TblUsers.FindAsync(id);

        }

        public async Task RegisterUser(RegisterUserDto registerUserDto, string ip)
        {
            var user = new TblUser
            {
                UserName = registerUserDto.UserName,
                EmailId = registerUserDto.EmailId,
                Password = (registerUserDto.Password), // encrypt password
                Birthdate = registerUserDto.Birthdate.HasValue
                   ? DateOnly.FromDateTime(registerUserDto.Birthdate.Value)
                   : null, // make Birthdate nullable in TblUser: DateOnly?
                Address = registerUserDto.Address,
                CreatedDate = DateTime.Now // or let DB handle it via default/Stored Procedure
            };
            _context.TblUsers.Add(user);
            await _context.SaveChangesAsync();

        }

        public  async Task UpdateUser(TblUser tblUser)
        {
            _context.TblUsers.Update(tblUser);

            await _context.SaveChangesAsync();
        }
    }
}
