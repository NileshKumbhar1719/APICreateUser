using System;
using System.Collections.Generic;

namespace APICreateUser.Models;

public partial class TblUserIp
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public string? Ipaddress { get; set; }

   

    public TblUser User { get; set; }
}
