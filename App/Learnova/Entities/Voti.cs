using System;
using System.Collections.Generic;

namespace Learnova.Entities;

public partial class Voti
{
    public int Progressivo { get; set; }

    public string CodiceStudente { get; set; } = null!;

    public int CodiceMateria { get; set; }

    public DateTime Data { get; set; }

    public double Cifra { get; set; }

    public string? Descrizione { get; set; }

    public virtual Materie CodiceMateriaNavigation { get; set; } = null!;

    public virtual Studenti CodiceStudenteNavigation { get; set; } = null!;
}
