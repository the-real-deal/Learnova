using System;
using System.Collections.Generic;

namespace Learnova.Entities;

public partial class Assenze
{
    public DateTime Data { get; set; }

    public string CodiceStudente { get; set; } = null!;

    public bool Giustificata { get; set; }

    public string? Descrizione { get; set; }

    public virtual Studenti CodiceStudenteNavigation { get; set; } = null!;
}
