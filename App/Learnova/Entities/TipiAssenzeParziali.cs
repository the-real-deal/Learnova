using System;
using System.Collections.Generic;

namespace Learnova.Entities;

public partial class TipiAssenzeParziali
{
    public int Id { get; set; }

    public string Tipo { get; set; } = null!;

    public virtual ICollection<AssenzeParziali> AssenzeParzialis { get; set; } = new List<AssenzeParziali>();
}
