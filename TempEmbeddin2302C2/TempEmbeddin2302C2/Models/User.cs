using System;
using System.Collections.Generic;

namespace TempEmbeddin2302C2.Models;

public partial class User
{
    public int Id { get; set; }

    public string Username { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public int RoleId { get; set; }

    public int Status { get; set; }

    public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();
}
