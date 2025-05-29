using System;
using System.Collections.Generic;

namespace Learnova.Entities;

public partial class Delegati
{
    public string Cf { get; set; } = null!;

    public string Nome { get; set; } = null!;

    public string Cognome { get; set; } = null!;

    public DateTime DataDiNascita { get; set; }

    public virtual ICollection<Studenti> CodiceStudentes { get; set; } = new List<Studenti>();
}
