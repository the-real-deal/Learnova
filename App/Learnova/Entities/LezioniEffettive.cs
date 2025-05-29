using System;
using System.Collections.Generic;

namespace Learnova.Entities;

public partial class LezioniEffettive
{
    public DateTime Data { get; set; }

    public int Ora { get; set; }

    public int CodiceClasse { get; set; }

    public string? Descrizione { get; set; }

    public virtual Classi CodiceClasseNavigation { get; set; } = null!;

    public virtual ICollection<DiTurno> DiTurnos { get; set; } = new List<DiTurno>();
}
