using System;
using System.Collections.Generic;

namespace Learnova.Entities;

public partial class AssenzeParziali
{
    public DateTime Data { get; set; }

    public int Ora { get; set; }

    public string CodiceStudente { get; set; } = null!;

    public int TipoAssenzaParziale { get; set; }

    public bool Giustificata { get; set; }

    public string? Descrizione { get; set; }

    public virtual Studenti CodiceStudenteNavigation { get; set; } = null!;

    public virtual TipiAssenzeParziali TipoAssenzaParzialeNavigation { get; set; } = null!;
}
