using APICreateUser.DTO;
using APICreateUser.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

namespace APICreateUser.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApicreateContext _context;

        public UserRepository(ApicreateContext context)
        {
            _context = context;

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

        public async Task<List<TblUserIp>> GetUserIPs()
        {
            return await _context.TblUserIps.ToListAsync();
        }

        public async Task<string> RegisterUser(RegisterUserDto registerUserDto)
        {
            string encryptedPassword = EncryptPassword(registerUserDto.Password);
            var user = new TblUser
            {
                UserName = registerUserDto.UserName,
                EmailId = registerUserDto.EmailId,
                Password = encryptedPassword,
                Birthdate = registerUserDto.Birthdate,
                Address = registerUserDto.Address,
                CreatedDate = DateTime.Now

            };
            _context.TblUsers.Add(user);
            await _context.SaveChangesAsync();

            var userIp = new TblUserIp
            {
                UserId = user.UserId,
                Ipaddress = registerUserDto.IpAddress
            };

            _context.TblUserIps.Add(userIp);
            await _context.SaveChangesAsync();
            return "User registered successfully";


        }

        public async Task UpdateUser(UpdateUser update,int id)
        {

            var existingUser = await _context.TblUsers.FindAsync(id);
            if(existingUser == null)
            {
                throw new Exception("User not found");
            }

            existingUser.UserName = update.UserName;
            existingUser.EmailId = update.EmailId;
            existingUser.Birthdate = update.Birthdate;
            existingUser.Address = update.Address;



            _context.TblUsers.Update(existingUser);

            await _context.SaveChangesAsync();
        }





        private string EncryptPassword(string password)
        {


            using var sha = SHA256.Create();
            var hashedBytes = sha.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            var hash = sha.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(hashedBytes);
        }

    }
}
