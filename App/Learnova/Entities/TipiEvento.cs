using System;
using System.Collections.Generic;

namespace Learnova.Entities;

public partial class TipiEvento
{
    public int Id { get; set; }

    public string Nome { get; set; } = null!;

    public virtual ICollection<Eventi> Eventis { get; set; } = new List<Eventi>();
}
