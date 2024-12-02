using System;
using System.Collections.Generic;

namespace demo2811.Models;

public partial class Sotrudnik
{
    public int IdSotrudnik { get; set; }

    public string? Surname { get; set; }

    public string? Name { get; set; }

    public string? Otchestvo { get; set; }

    public string? Code { get; set; }

    public virtual ICollection<Podrazd> IdPodrazds { get; set; } = new List<Podrazd>();
}
