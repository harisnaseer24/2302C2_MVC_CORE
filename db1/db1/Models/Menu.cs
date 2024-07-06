using System;
using System.Collections.Generic;

namespace db1.Models;

public partial class Menu
{
    public int Id { get; set; }

    public string? Namee { get; set; }

    public string? Descrp { get; set; }

    public int? Price { get; set; }
}
