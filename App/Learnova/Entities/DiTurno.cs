using System;
using System.Collections.Generic;

namespace Learnova.Entities;

public partial class DiTurno
{
    public string CodiceProfessore { get; set; } = null!;

    public DateTime Data { get; set; }

    public int Ora { get; set; }

    public int CodiceClasse { get; set; }

    public virtual LezioniEffettive LezioniEffettive { get; set; } = null!;
}
