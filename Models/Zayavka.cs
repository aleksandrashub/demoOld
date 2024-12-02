using System;
using System.Collections.Generic;

namespace demo2811.Models;

public partial class Zayavka
{
    public int IdZayavka { get; set; }

    public int IdUser { get; set; }

    public int? IdPodrazd { get; set; }

    public DateOnly? SrokNach { get; set; }

    public DateOnly? SrokKonets { get; set; }

    public int IdStat { get; set; }

    public string? Nomer { get; set; }

    public int? IdAim { get; set; }

    public virtual Aim? IdAimNavigation { get; set; }

    public virtual Podrazd? IdPodrazdNavigation { get; set; }

    public virtual Status IdStatNavigation { get; set; } = null!;

    public virtual User IdUserNavigation { get; set; } = null!;

    public virtual ICollection<User> IdUsers { get; set; } = new List<User>();
    public string type => IdUsers.Count > 0
        ? "Групповая" : "Личная";

    public string date => SrokNach.ToString();
}
