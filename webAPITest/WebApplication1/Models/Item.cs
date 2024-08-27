using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Item
{
    public int PId { get; set; }

    public string Name { get; set; } = null!;

    public string Desc { get; set; } = null!;

    public string Pimage { get; set; } = null!;

    public int? CatId { get; set; }

    public virtual Category? Cat { get; set; }
}
