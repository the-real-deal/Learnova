using System;
using System.Collections.Generic;

namespace Learnova.Entities;

public partial class PianiDiStudio
{
    public int Id { get; set; }

    public int Anno { get; set; }

    public int CodiceIndirizzo { get; set; }

    public virtual ICollection<Classi> Classis { get; set; } = new List<Classi>();
}
