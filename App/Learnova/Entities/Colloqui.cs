using System;
using System.Collections.Generic;

namespace Learnova.Entities;

public partial class Colloqui
{
    public DateTime Data { get; set; }

    public int Ora { get; set; }

    public string CodiceProfessore { get; set; } = null!;

    public string CodiceGenitore { get; set; } = null!;

    public virtual Genitori CodiceGenitoreNavigation { get; set; } = null!;

    public virtual Professori CodiceProfessoreNavigation { get; set; } = null!;
}
