using System;
using System.Collections.Generic;

namespace Learnova.Entities;

public partial class AttivitaDidattiche
{
    public int Id { get; set; }

    public DateTime DataInizio { get; set; }

    public DateTime DataFine { get; set; }

    public string Luogo { get; set; } = null!;

    public string Descrizione { get; set; } = null!;

    public virtual ICollection<Classi> CodiceClasses { get; set; } = new List<Classi>();
}
