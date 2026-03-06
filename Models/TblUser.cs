using System;
using System.Collections.Generic;

namespace APICreateUser.Models;

public partial class TblUser
{
    public int UserId { get; set; }

    public string UserName { get; set; } = null!;

    public string EmailId { get; set; } = null!;

    public string Password { get; set; } = null!;

    public DateTime Birthdate { get; set; }

    public string? Address { get; set; }



    public DateTime CreatedDate { get; set; }
    

    public List<TblUserIp> UserIps { get; set; } 
}
