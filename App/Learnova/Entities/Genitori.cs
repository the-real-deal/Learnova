using System;
using System.Collections.Generic;

namespace Learnova.Entities;

public partial class Genitori
{
    public string Cf { get; set; } = null!;

    public string Nome { get; set; } = null!;

    public string Cognome { get; set; } = null!;

    public DateTime DataDiNascita { get; set; }

    public string CodiceAccount { get; set; } = null!;

    public virtual Account CodiceAccountNavigation { get; set; } = null!;

    public virtual ICollection<Colloqui> Colloquis { get; set; } = new List<Colloqui>();

    public virtual ICollection<Studenti> CodiceStudentes { get; set; } = new List<Studenti>();
}
