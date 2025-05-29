using System;
using System.Collections.Generic;

namespace Learnova.Entities;

public partial class Studenti
{
    public string Cf { get; set; } = null!;

    public string Nome { get; set; } = null!;

    public string Cognome { get; set; } = null!;

    public DateTime DataDiNascita { get; set; }

    public int CodiceClasse { get; set; }

    public string CodiceAccount { get; set; } = null!;

    public virtual ICollection<AssenzeParziali> AssenzeParzialis { get; set; } = new List<AssenzeParziali>();

    public virtual ICollection<Assenze> Assenzes { get; set; } = new List<Assenze>();

    public virtual Account CodiceAccountNavigation { get; set; } = null!;

    public virtual Classi CodiceClasseNavigation { get; set; } = null!;

    public virtual ICollection<Note> Notes { get; set; } = new List<Note>();

    public virtual ICollection<Voti> Votis { get; set; } = new List<Voti>();

    public virtual ICollection<Delegati> CodiceDelegatos { get; set; } = new List<Delegati>();

    public virtual ICollection<Genitori> CodiceGenitores { get; set; } = new List<Genitori>();
}
