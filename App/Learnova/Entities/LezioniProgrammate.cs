using System;
using System.Collections.Generic;

namespace Learnova.Entities;

public partial class LezioniProgrammate
{
    public int Giorno { get; set; }

    public int Ora { get; set; }

    public int CodiceClasse { get; set; }

    public virtual ICollection<Cattedra> Cattedras { get; set; } = new List<Cattedra>();

    public virtual Classi CodiceClasseNavigation { get; set; } = null!;
}
