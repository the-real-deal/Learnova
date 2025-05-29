using System;
using System.Collections.Generic;

namespace Learnova.Entities;

public partial class Note
{
    public int Progressivo { get; set; }

    public DateTime Data { get; set; }

    public string CodiceStudente { get; set; } = null!;

    public string? Descrizione { get; set; }

    public virtual Studenti CodiceStudenteNavigation { get; set; } = null!;
}
