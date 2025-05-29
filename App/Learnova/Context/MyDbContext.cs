using System;
using System.Collections.Generic;
using Learnova.Entities;
using Microsoft.EntityFrameworkCore;

namespace Learnova.Context;

public partial class MyDbContext : DbContext
{
    public MyDbContext()
    {
    }

    public MyDbContext(DbContextOptions<MyDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<Assenze> Assenzes { get; set; }

    public virtual DbSet<AssenzeParziali> AssenzeParzialis { get; set; }

    public virtual DbSet<AttivitaDidattiche> AttivitaDidattiches { get; set; }

    public virtual DbSet<Cattedra> Cattedras { get; set; }

    public virtual DbSet<Classi> Classis { get; set; }

    public virtual DbSet<Colloqui> Colloquis { get; set; }

    public virtual DbSet<Corso> Corsos { get; set; }

    public virtual DbSet<Delegati> Delegatis { get; set; }

    public virtual DbSet<DiTurno> DiTurnos { get; set; }

    public virtual DbSet<Eventi> Eventis { get; set; }

    public virtual DbSet<Genitori> Genitoris { get; set; }

    public virtual DbSet<Indirizzi> Indirizzis { get; set; }

    public virtual DbSet<LezioniEffettive> LezioniEffettives { get; set; }

    public virtual DbSet<LezioniProgrammate> LezioniProgrammates { get; set; }

    public virtual DbSet<Materie> Materies { get; set; }

    public virtual DbSet<Note> Notes { get; set; }

    public virtual DbSet<PianiDiStudio> PianiDiStudios { get; set; }

    public virtual DbSet<Professori> Professoris { get; set; }

    public virtual DbSet<Studenti> Studentis { get; set; }

    public virtual DbSet<TipiAccount> TipiAccounts { get; set; }

    public virtual DbSet<TipiAssenzeParziali> TipiAssenzeParzialis { get; set; }

    public virtual DbSet<TipiEvento> TipiEventos { get; set; }

    public virtual DbSet<Voti> Votis { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySQL("server=localhost;uid=root;password=Penelope1;database=learnova");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.Username).HasName("PRIMARY");

            entity.ToTable("account");

            entity.HasIndex(e => e.Mail, "Mail").IsUnique();

            entity.HasIndex(e => e.CodiceRuolo, "codiceRuolo");

            entity.Property(e => e.Username).HasMaxLength(20);
            entity.Property(e => e.Attivo)
                .IsRequired()
                .HasDefaultValueSql("'1'");
            entity.Property(e => e.CodiceRuolo).HasColumnName("codiceRuolo");
            entity.Property(e => e.Mail).HasMaxLength(70);
            entity.Property(e => e.Password).HasMaxLength(40);

            entity.HasOne(d => d.CodiceRuoloNavigation).WithMany(p => p.Accounts)
                .HasForeignKey(d => d.CodiceRuolo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("account_ibfk_1");
        });

        modelBuilder.Entity<Assenze>(entity =>
        {
            entity.HasKey(e => new { e.Data, e.CodiceStudente }).HasName("PRIMARY");

            entity.ToTable("assenze");

            entity.HasIndex(e => e.CodiceStudente, "CodiceStudente");

            entity.Property(e => e.Data).HasColumnType("date");
            entity.Property(e => e.CodiceStudente).HasMaxLength(16);
            entity.Property(e => e.Descrizione).HasMaxLength(200);

            entity.HasOne(d => d.CodiceStudenteNavigation).WithMany(p => p.Assenzes)
                .HasForeignKey(d => d.CodiceStudente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("assenze_ibfk_1");
        });

        modelBuilder.Entity<AssenzeParziali>(entity =>
        {
            entity.HasKey(e => new { e.Data, e.Ora, e.CodiceStudente }).HasName("PRIMARY");

            entity.ToTable("assenze_parziali");

            entity.HasIndex(e => e.CodiceStudente, "CodiceStudente");

            entity.HasIndex(e => e.TipoAssenzaParziale, "assenze_parziali2");

            entity.Property(e => e.Data).HasColumnType("date");
            entity.Property(e => e.CodiceStudente).HasMaxLength(16);
            entity.Property(e => e.Descrizione).HasMaxLength(200);

            entity.HasOne(d => d.CodiceStudenteNavigation).WithMany(p => p.AssenzeParzialis)
                .HasForeignKey(d => d.CodiceStudente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("assenze_parziali_ibfk_1");

            entity.HasOne(d => d.TipoAssenzaParzialeNavigation).WithMany(p => p.AssenzeParzialis)
                .HasForeignKey(d => d.TipoAssenzaParziale)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("assenze_parziali2");
        });

        modelBuilder.Entity<AttivitaDidattiche>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("attivita_didattiche");

            entity.HasIndex(e => new { e.DataInizio, e.DataFine, e.Luogo, e.Descrizione }, "Data_Inizio").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.DataFine)
                .HasColumnType("date")
                .HasColumnName("Data_Fine");
            entity.Property(e => e.DataInizio)
                .HasColumnType("date")
                .HasColumnName("Data_Inizio");
            entity.Property(e => e.Descrizione).HasMaxLength(200);
            entity.Property(e => e.Luogo).HasMaxLength(70);
        });

        modelBuilder.Entity<Cattedra>(entity =>
        {
            entity.HasKey(e => new { e.CodiceProfessore, e.Giorno, e.Ora, e.CodiceClasse }).HasName("PRIMARY");

            entity.ToTable("cattedra");

            entity.HasIndex(e => new { e.Giorno, e.Ora, e.CodiceClasse }, "Giorno");

            entity.Property(e => e.CodiceProfessore).HasMaxLength(16);

            entity.HasOne(d => d.LezioniProgrammate).WithMany(p => p.Cattedras)
                .HasForeignKey(d => new { d.Giorno, d.Ora, d.CodiceClasse })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("cattedra_ibfk_1");
        });

        modelBuilder.Entity<Classi>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("classi");

            entity.HasIndex(e => new { e.Sezione, e.AnnoScolastico, e.CodicePianoStudio }, "Sezione").IsUnique();

            entity.HasIndex(e => e.CodicePianoStudio, "codicePianoStudio");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AnnoScolastico)
                .HasColumnType("year")
                .HasColumnName("Anno_Scolastico");
            entity.Property(e => e.CodicePianoStudio).HasColumnName("codicePianoStudio");
            entity.Property(e => e.Sezione)
                .HasMaxLength(1)
                .IsFixedLength();

            entity.HasOne(d => d.CodicePianoStudioNavigation).WithMany(p => p.Classis)
                .HasForeignKey(d => d.CodicePianoStudio)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("classi_ibfk_1");

            entity.HasMany(d => d.CodiceAttivitaDidatticas).WithMany(p => p.CodiceClasses)
                .UsingEntity<Dictionary<string, object>>(
                    "Partecipazione",
                    r => r.HasOne<AttivitaDidattiche>().WithMany()
                        .HasForeignKey("CodiceAttivitaDidattica")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("partecipazione_ibfk_2"),
                    l => l.HasOne<Classi>().WithMany()
                        .HasForeignKey("CodiceClasse")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("partecipazione_ibfk_1"),
                    j =>
                    {
                        j.HasKey("CodiceClasse", "CodiceAttivitaDidattica").HasName("PRIMARY");
                        j.ToTable("partecipazione");
                        j.HasIndex(new[] { "CodiceAttivitaDidattica" }, "CodiceAttivitaDidattica");
                    });
        });

        modelBuilder.Entity<Colloqui>(entity =>
        {
            entity.HasKey(e => new { e.Data, e.Ora, e.CodiceProfessore, e.CodiceGenitore }).HasName("PRIMARY");

            entity.ToTable("colloqui");

            entity.HasIndex(e => e.CodiceGenitore, "CodiceGenitore");

            entity.HasIndex(e => e.CodiceProfessore, "CodiceProfessore");

            entity.Property(e => e.Data).HasColumnType("date");
            entity.Property(e => e.CodiceProfessore).HasMaxLength(16);
            entity.Property(e => e.CodiceGenitore).HasMaxLength(16);

            entity.HasOne(d => d.CodiceGenitoreNavigation).WithMany(p => p.Colloquis)
                .HasForeignKey(d => d.CodiceGenitore)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("colloqui_ibfk_2");

            entity.HasOne(d => d.CodiceProfessoreNavigation).WithMany(p => p.Colloquis)
                .HasForeignKey(d => d.CodiceProfessore)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("colloqui_ibfk_1");
        });

        modelBuilder.Entity<Corso>(entity =>
        {
            entity.HasKey(e => new { e.CodiceMateria, e.CodicePianoStudio }).HasName("PRIMARY");

            entity.ToTable("corso");
        });

        modelBuilder.Entity<Delegati>(entity =>
        {
            entity.HasKey(e => e.Cf).HasName("PRIMARY");

            entity.ToTable("delegati");

            entity.Property(e => e.Cf)
                .HasMaxLength(16)
                .HasColumnName("CF");
            entity.Property(e => e.Cognome).HasMaxLength(50);
            entity.Property(e => e.DataDiNascita)
                .HasColumnType("date")
                .HasColumnName("Data_Di_Nascita");
            entity.Property(e => e.Nome).HasMaxLength(50);
        });

        modelBuilder.Entity<DiTurno>(entity =>
        {
            entity.HasKey(e => new { e.CodiceProfessore, e.Data, e.Ora, e.CodiceClasse }).HasName("PRIMARY");

            entity.ToTable("di_turno");

            entity.HasIndex(e => new { e.Data, e.Ora, e.CodiceClasse }, "Data");

            entity.Property(e => e.CodiceProfessore).HasMaxLength(16);
            entity.Property(e => e.Data).HasColumnType("date");

            entity.HasOne(d => d.LezioniEffettive).WithMany(p => p.DiTurnos)
                .HasForeignKey(d => new { d.Data, d.Ora, d.CodiceClasse })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("di_turno_ibfk_1");
        });

        modelBuilder.Entity<Eventi>(entity =>
        {
            entity.HasKey(e => new { e.Data, e.Ora, e.CodiceClasse, e.CodiceMateria }).HasName("PRIMARY");

            entity.ToTable("eventi");

            entity.HasIndex(e => e.CodiceClasse, "CodiceClasse");

            entity.HasIndex(e => e.CodiceMateria, "CodiceMateria");

            entity.HasIndex(e => e.CodiceTipoEvento, "CodiceTipoEvento");

            entity.Property(e => e.Data).HasColumnType("date");
            entity.Property(e => e.Descrizione).HasMaxLength(200);

            entity.HasOne(d => d.CodiceClasseNavigation).WithMany(p => p.Eventis)
                .HasForeignKey(d => d.CodiceClasse)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("eventi_ibfk_1");

            entity.HasOne(d => d.CodiceMateriaNavigation).WithMany(p => p.Eventis)
                .HasForeignKey(d => d.CodiceMateria)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("eventi_ibfk_2");

            entity.HasOne(d => d.CodiceTipoEventoNavigation).WithMany(p => p.Eventis)
                .HasForeignKey(d => d.CodiceTipoEvento)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("eventi_ibfk_3");
        });

        modelBuilder.Entity<Genitori>(entity =>
        {
            entity.HasKey(e => e.Cf).HasName("PRIMARY");

            entity.ToTable("genitori");

            entity.HasIndex(e => e.CodiceAccount, "genitori_ibfk_1");

            entity.Property(e => e.Cf)
                .HasMaxLength(16)
                .HasColumnName("CF");
            entity.Property(e => e.CodiceAccount).HasMaxLength(20);
            entity.Property(e => e.Cognome).HasMaxLength(50);
            entity.Property(e => e.DataDiNascita)
                .HasColumnType("date")
                .HasColumnName("Data_Di_Nascita");
            entity.Property(e => e.Nome).HasMaxLength(50);

            entity.HasOne(d => d.CodiceAccountNavigation).WithMany(p => p.Genitoris)
                .HasForeignKey(d => d.CodiceAccount)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("genitori_ibfk_1");
        });

        modelBuilder.Entity<Indirizzi>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("indirizzi");

            entity.HasIndex(e => e.Nome, "Nome").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Nome).HasMaxLength(50);
        });

        modelBuilder.Entity<LezioniEffettive>(entity =>
        {
            entity.HasKey(e => new { e.Data, e.Ora, e.CodiceClasse }).HasName("PRIMARY");

            entity.ToTable("lezioni_effettive");

            entity.HasIndex(e => e.CodiceClasse, "CodiceClasse");

            entity.Property(e => e.Data).HasColumnType("date");
            entity.Property(e => e.Descrizione).HasMaxLength(200);

            entity.HasOne(d => d.CodiceClasseNavigation).WithMany(p => p.LezioniEffettives)
                .HasForeignKey(d => d.CodiceClasse)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("lezioni_effettive_ibfk_1");
        });

        modelBuilder.Entity<LezioniProgrammate>(entity =>
        {
            entity.HasKey(e => new { e.Giorno, e.Ora, e.CodiceClasse }).HasName("PRIMARY");

            entity.ToTable("lezioni_programmate");

            entity.HasIndex(e => e.CodiceClasse, "CodiceClasse");

            entity.HasOne(d => d.CodiceClasseNavigation).WithMany(p => p.LezioniProgrammates)
                .HasForeignKey(d => d.CodiceClasse)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("lezioni_programmate_ibfk_1");
        });

        modelBuilder.Entity<Materie>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("materie");

            entity.HasIndex(e => e.Nome, "Nome").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Nome).HasMaxLength(30);

            entity.HasMany(d => d.CodiceProfessores).WithMany(p => p.CodiceMateria)
                .UsingEntity<Dictionary<string, object>>(
                    "Abilitazione",
                    r => r.HasOne<Professori>().WithMany()
                        .HasForeignKey("CodiceProfessore")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("abilitazione_ibfk_2"),
                    l => l.HasOne<Materie>().WithMany()
                        .HasForeignKey("CodiceMateria")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("abilitazione_ibfk_1"),
                    j =>
                    {
                        j.HasKey("CodiceMateria", "CodiceProfessore").HasName("PRIMARY");
                        j.ToTable("abilitazione");
                        j.HasIndex(new[] { "CodiceProfessore" }, "CodiceProfessore");
                        j.IndexerProperty<string>("CodiceProfessore").HasMaxLength(16);
                    });
        });

        modelBuilder.Entity<Note>(entity =>
        {
            entity.HasKey(e => new { e.Progressivo, e.Data, e.CodiceStudente }).HasName("PRIMARY");

            entity.ToTable("note");

            entity.HasIndex(e => e.CodiceStudente, "CodiceStudente");

            entity.Property(e => e.Progressivo).ValueGeneratedOnAdd();
            entity.Property(e => e.Data).HasColumnType("date");
            entity.Property(e => e.CodiceStudente).HasMaxLength(16);
            entity.Property(e => e.Descrizione).HasMaxLength(200);

            entity.HasOne(d => d.CodiceStudenteNavigation).WithMany(p => p.Notes)
                .HasForeignKey(d => d.CodiceStudente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("note_ibfk_1");
        });

        modelBuilder.Entity<PianiDiStudio>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("piani_di_studio");

            entity.HasIndex(e => new { e.Anno, e.CodiceIndirizzo }, "Anno").IsUnique();

            entity.HasIndex(e => e.CodiceIndirizzo, "codiceIndirizzo");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CodiceIndirizzo).HasColumnName("codiceIndirizzo");
        });

        modelBuilder.Entity<Professori>(entity =>
        {
            entity.HasKey(e => e.Cf).HasName("PRIMARY");

            entity.ToTable("professori");

            entity.HasIndex(e => e.CodiceAccount, "professori2");

            entity.Property(e => e.Cf)
                .HasMaxLength(16)
                .HasColumnName("CF");
            entity.Property(e => e.CodiceAccount).HasMaxLength(20);
            entity.Property(e => e.Cognome).HasMaxLength(50);
            entity.Property(e => e.DataAssunzione)
                .HasColumnType("date")
                .HasColumnName("Data_Assunzione");
            entity.Property(e => e.DataDiNascita)
                .HasColumnType("date")
                .HasColumnName("Data_Di_Nascita");
            entity.Property(e => e.DiRuolo).HasColumnName("Di_Ruolo");
            entity.Property(e => e.Nome).HasMaxLength(50);

            entity.HasOne(d => d.CodiceAccountNavigation).WithMany(p => p.Professoris)
                .HasForeignKey(d => d.CodiceAccount)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("professori2");

            entity.HasMany(d => d.CodiceClasses).WithMany(p => p.CodiceProfessores)
                .UsingEntity<Dictionary<string, object>>(
                    "Insegnamento",
                    r => r.HasOne<Classi>().WithMany()
                        .HasForeignKey("CodiceClasse")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("insegnamento_ibfk_2"),
                    l => l.HasOne<Professori>().WithMany()
                        .HasForeignKey("CodiceProfessore")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("insegnamento_ibfk_1"),
                    j =>
                    {
                        j.HasKey("CodiceProfessore", "CodiceClasse").HasName("PRIMARY");
                        j.ToTable("insegnamento");
                        j.HasIndex(new[] { "CodiceClasse" }, "CodiceClasse");
                        j.IndexerProperty<string>("CodiceProfessore").HasMaxLength(16);
                    });
        });

        modelBuilder.Entity<Studenti>(entity =>
        {
            entity.HasKey(e => e.Cf).HasName("PRIMARY");

            entity.ToTable("studenti");

            entity.HasIndex(e => e.CodiceAccount, "studenti2");

            entity.HasIndex(e => e.CodiceClasse, "studenti_ibfk_1");

            entity.Property(e => e.Cf)
                .HasMaxLength(16)
                .HasColumnName("CF");
            entity.Property(e => e.CodiceAccount).HasMaxLength(20);
            entity.Property(e => e.Cognome).HasMaxLength(50);
            entity.Property(e => e.DataDiNascita)
                .HasColumnType("date")
                .HasColumnName("Data_Di_Nascita");
            entity.Property(e => e.Nome).HasMaxLength(50);

            entity.HasOne(d => d.CodiceAccountNavigation).WithMany(p => p.Studentis)
                .HasForeignKey(d => d.CodiceAccount)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("studenti2");

            entity.HasOne(d => d.CodiceClasseNavigation).WithMany(p => p.Studentis)
                .HasForeignKey(d => d.CodiceClasse)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("studenti_ibfk_1");

            entity.HasMany(d => d.CodiceDelegatos).WithMany(p => p.CodiceStudentes)
                .UsingEntity<Dictionary<string, object>>(
                    "Delega",
                    r => r.HasOne<Delegati>().WithMany()
                        .HasForeignKey("CodiceDelegato")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("delega_ibfk_2"),
                    l => l.HasOne<Studenti>().WithMany()
                        .HasForeignKey("CodiceStudente")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("delega_ibfk_1"),
                    j =>
                    {
                        j.HasKey("CodiceStudente", "CodiceDelegato").HasName("PRIMARY");
                        j.ToTable("delega");
                        j.HasIndex(new[] { "CodiceDelegato" }, "CodiceDelegato");
                        j.IndexerProperty<string>("CodiceStudente").HasMaxLength(16);
                        j.IndexerProperty<string>("CodiceDelegato").HasMaxLength(16);
                    });

            entity.HasMany(d => d.CodiceGenitores).WithMany(p => p.CodiceStudentes)
                .UsingEntity<Dictionary<string, object>>(
                    "Responsabilitum",
                    r => r.HasOne<Genitori>().WithMany()
                        .HasForeignKey("CodiceGenitore")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("responsabilita_ibfk_2"),
                    l => l.HasOne<Studenti>().WithMany()
                        .HasForeignKey("CodiceStudente")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("responsabilita_ibfk_1"),
                    j =>
                    {
                        j.HasKey("CodiceStudente", "CodiceGenitore").HasName("PRIMARY");
                        j.ToTable("responsabilita");
                        j.HasIndex(new[] { "CodiceGenitore" }, "CodiceGenitore");
                        j.IndexerProperty<string>("CodiceStudente").HasMaxLength(16);
                        j.IndexerProperty<string>("CodiceGenitore").HasMaxLength(16);
                    });
        });

        modelBuilder.Entity<TipiAccount>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("tipi_account");

            entity.HasIndex(e => e.Tipo, "Tipo").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Tipo).HasMaxLength(50);
        });

        modelBuilder.Entity<TipiAssenzeParziali>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("tipi_assenze_parziali");

            entity.HasIndex(e => e.Tipo, "Tipo").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Tipo).HasMaxLength(30);
        });

        modelBuilder.Entity<TipiEvento>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("tipi_evento");

            entity.HasIndex(e => e.Nome, "Nome").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Nome).HasMaxLength(50);
        });

        modelBuilder.Entity<Voti>(entity =>
        {
            entity.HasKey(e => new { e.Progressivo, e.CodiceStudente, e.CodiceMateria }).HasName("PRIMARY");

            entity.ToTable("voti");

            entity.HasIndex(e => e.CodiceMateria, "CodiceMateria");

            entity.HasIndex(e => e.CodiceStudente, "CodiceStudente");

            entity.Property(e => e.Progressivo).ValueGeneratedOnAdd();
            entity.Property(e => e.CodiceStudente).HasMaxLength(16);
            entity.Property(e => e.Data).HasColumnType("date");
            entity.Property(e => e.Descrizione).HasMaxLength(200);

            entity.HasOne(d => d.CodiceMateriaNavigation).WithMany(p => p.Votis)
                .HasForeignKey(d => d.CodiceMateria)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("voti_ibfk_2");

            entity.HasOne(d => d.CodiceStudenteNavigation).WithMany(p => p.Votis)
                .HasForeignKey(d => d.CodiceStudente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("voti_ibfk_1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
