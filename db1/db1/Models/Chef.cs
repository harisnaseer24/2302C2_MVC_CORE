using System;
using System.Collections.Generic;

namespace db1.Models;

public partial class Chef
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Speciality { get; set; } = null!;

    public string Experience { get; set; } = null!;
}
