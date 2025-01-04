using System;
using System.Collections.Generic;

namespace BlogWeb.Models;

public partial class Users
{
    public int UserId { get; set; }

    public string UserName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? Phone { get; set; }

    public string Password { get; set; } = null!;

    public string? UserRole { get; set; }

    public DateOnly? DateOfBirth { get; set; }

    public virtual ICollection<Comments> Comments { get; set; } = new List<Comments>();

    public virtual ICollection<Posts> Posts { get; set; } = new List<Posts>();
}
