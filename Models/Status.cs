using System;
using System.Collections.Generic;

namespace demo2811.Models;

public partial class Status
{
    public int IdStat { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Zayavka> Zayavkas { get; set; } = new List<Zayavka>();
}
