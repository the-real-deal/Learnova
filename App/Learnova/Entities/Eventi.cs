using System;
using System.Collections.Generic;

namespace Learnova.Entities;

public partial class Eventi
{
    public DateTime Data { get; set; }

    public int Ora { get; set; }

    public int CodiceClasse { get; set; }

    public int CodiceMateria { get; set; }

    public int CodiceTipoEvento { get; set; }

    public string? Descrizione { get; set; }

    public virtual Classi CodiceClasseNavigation { get; set; } = null!;

    public virtual Materie CodiceMateriaNavigation { get; set; } = null!;

    public virtual TipiEvento CodiceTipoEventoNavigation { get; set; } = null!;
}
