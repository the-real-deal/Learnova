using System;
using System.Collections.Generic;

namespace Learnova.Entities;

public partial class Account
{
    public string Username { get; set; } = null!;

    public int CodiceRuolo { get; set; }

    public bool? Attivo { get; set; }

    public string Mail { get; set; } = null!;

    public string Password { get; set; } = null!;

    public virtual TipiAccount CodiceRuoloNavigation { get; set; } = null!;

    public virtual ICollection<Genitori> Genitoris { get; set; } = new List<Genitori>();

    public virtual ICollection<Professori> Professoris { get; set; } = new List<Professori>();

    public virtual ICollection<Studenti> Studentis { get; set; } = new List<Studenti>();
}
