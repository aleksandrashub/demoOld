using System;
using System.Collections.Generic;

namespace demo2811.Models;

public partial class User
{
    public int IdUser { get; set; }

    public string? Name { get; set; }

    public string? Surname { get; set; }

    public string? Otchestvo { get; set; }

    public string? Phone { get; set; }

    public string? Mail { get; set; }

    public DateOnly? Birth { get; set; }

    public string? Seria { get; set; }

    public string? Nomer { get; set; }

    public string? Login { get; set; }

    public string? Passwd { get; set; }

    public string? Image { get; set; }

    public string? Primechanie { get; set; }

    public string? Organization { get; set; }

    public virtual ICollection<Zayavka> Zayavkas { get; set; } = new List<Zayavka>();

    public virtual ICollection<Zayavka> IdZayavkas { get; set; } = new List<Zayavka>();
}
