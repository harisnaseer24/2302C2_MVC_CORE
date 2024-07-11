using System;
using System.Collections.Generic;

namespace db1.Models;

public partial class Product
{
    public int Id { get; set; }

    public string? Proname { get; set; }

    public int? Qty { get; set; }

    public string? Imagepath { get; set; }

    public int? Catid { get; set; }

    public virtual Menu? Cat { get; set; }
}
