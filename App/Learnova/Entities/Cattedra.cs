using System;
using System.Collections.Generic;

namespace Learnova.Entities;

public partial class Cattedra
{
    public string CodiceProfessore { get; set; } = null!;

    public int Giorno { get; set; }

    public int Ora { get; set; }

    public int CodiceClasse { get; set; }

    public virtual LezioniProgrammate LezioniProgrammate { get; set; } = null!;
}
