namespace APICreateUser.DTO
{
    public class RegisterUserDto
    {
        public string UserName { get; set; }

        public string EmailId { get; set; }

        public string Password { get; set; }

        public DateTime? Birthdate { get; set; }

        public string Address { get; set; }
    }
}
