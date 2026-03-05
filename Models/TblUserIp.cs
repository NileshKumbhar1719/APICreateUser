using System;
using System.Collections.Generic;

namespace APICreateUser.Models;

public partial class TblUserIp
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public string? Ipaddress { get; set; }

    public DateTime? CreatedDate { get; set; }

    public virtual TblUser? User { get; set; }
}
