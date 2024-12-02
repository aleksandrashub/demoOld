using System;
using System.Collections.Generic;

namespace demo2811.Models;

public partial class Podrazd
{
    public int IdPodrazd { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Zayavka> Zayavkas { get; set; } = new List<Zayavka>();

    public virtual ICollection<Sotrudnik> IdSotruds { get; set; } = new List<Sotrudnik>();
}
