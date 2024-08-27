using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Menu
{
    public int Id { get; set; }

    public string? Namee { get; set; }

    public string? Descrp { get; set; }

    public int? Price { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
