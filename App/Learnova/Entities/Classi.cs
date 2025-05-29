using System;
using System.Collections.Generic;

namespace Learnova.Entities;

public partial class Classi
{
    public int Id { get; set; }

    public string Sezione { get; set; } = null!;

    public int AnnoScolastico { get; set; }

    public int CodicePianoStudio { get; set; }

    public virtual PianiDiStudio CodicePianoStudioNavigation { get; set; } = null!;

    public virtual ICollection<Eventi> Eventis { get; set; } = new List<Eventi>();

    public virtual ICollection<LezioniEffettive> LezioniEffettives { get; set; } = new List<LezioniEffettive>();

    public virtual ICollection<LezioniProgrammate> LezioniProgrammates { get; set; } = new List<LezioniProgrammate>();

    public virtual ICollection<Studenti> Studentis { get; set; } = new List<Studenti>();

    public virtual ICollection<AttivitaDidattiche> CodiceAttivitaDidatticas { get; set; } = new List<AttivitaDidattiche>();

    public virtual ICollection<Professori> CodiceProfessores { get; set; } = new List<Professori>();
}
