using System;
using System.Collections.Generic;

namespace Learnova.Entities;

public partial class Materie
{
    public int Id { get; set; }

    public string Nome { get; set; } = null!;

    public virtual ICollection<Eventi> Eventis { get; set; } = new List<Eventi>();

    public virtual ICollection<Voti> Votis { get; set; } = new List<Voti>();

    public virtual ICollection<Professori> CodiceProfessores { get; set; } = new List<Professori>();
}
