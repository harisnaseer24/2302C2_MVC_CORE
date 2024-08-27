using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Category
{
    public int CatId { get; set; }

    public string Catname { get; set; } = null!;

    public string Catdesc { get; set; } = null!;

    public virtual ICollection<Item> Items { get; set; } = new List<Item>();
}
