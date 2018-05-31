namespace API.Context
{
    using API.Models;
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;
    using System.Linq;

    public class CRUDContext : DbContext
    {
        public CRUDContext()
            : base("name=CRUDContext")
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        public virtual DbSet<Candidato> Candidatos { get; set; }
        public virtual DbSet<Conhecimento> Conhecimentos { get; set; }
        public virtual DbSet<Horario> Horarios { get; set; }
        public virtual DbSet<Periodo> Periodos { get; set; }
        public virtual DbSet<CandidatoConhecimento> CandidatoConhecimentos { get; set; }
        public virtual DbSet<CandidatoHorario> CandidatoHorarios { get; set; }
        public virtual DbSet<CandidatoPeriodo> CandidatoPeriodos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //primary key
            modelBuilder.Entity<Candidato>().HasKey(a => a.IdCandidato);
            modelBuilder.Entity<Conhecimento>().HasKey(a => a.IdConhecimento);
            modelBuilder.Entity<Horario>().HasKey(a => a.IdHorario);
            modelBuilder.Entity<Periodo>().HasKey(a => a.IdPeriodo);

            //propriedades
            modelBuilder.Entity<Candidato>().Property(a => a.Nome).HasMaxLength(100);
            modelBuilder.Entity<Candidato>().Property(a => a.Email).HasMaxLength(100);
            modelBuilder.Entity<Candidato>().Property(a => a.Skype).HasMaxLength(20);
            modelBuilder.Entity<Candidato>().Property(a => a.Telefone).HasMaxLength(20);
            modelBuilder.Entity<Candidato>().Property(a => a.Linkedin).HasMaxLength(200);
            modelBuilder.Entity<Candidato>().Property(a => a.Cidade).HasMaxLength(100);
            modelBuilder.Entity<Candidato>().Property(a => a.Estado).HasMaxLength(2);
            modelBuilder.Entity<Candidato>().Property(a => a.Portfolio).HasMaxLength(100);
            modelBuilder.Entity<Candidato>().Property(a => a.NomeBanco).HasMaxLength(30);
            modelBuilder.Entity<Candidato>().Property(a => a.TipoConta).HasMaxLength(10);
            modelBuilder.Entity<Candidato>().Property(a => a.NomeBeneficiarioBanco).HasMaxLength(100);
            modelBuilder.Entity<Candidato>().Property(a => a.CpfBeneficiarioBanco).HasMaxLength(20);
            modelBuilder.Entity<Candidato>().Property(a => a.AgenciaBanco).HasMaxLength(20);
            modelBuilder.Entity<Candidato>().Property(a => a.ContaBanco).HasMaxLength(20);
            modelBuilder.Entity<Candidato>().Property(a => a.LinkCrud).HasMaxLength(200);
            modelBuilder.Entity<CandidatoConhecimento>().Property(a => a.Nivel).IsOptional();

            //entidades relacionadas (many to many)
            modelBuilder.Entity<CandidatoConhecimento>().HasKey(a => new { a.IdCandidato, a.IdConhecimento });
            modelBuilder.Entity<CandidatoHorario>().HasKey(a => new { a.IdCandidato, a.IdHorario });
            modelBuilder.Entity<CandidatoPeriodo>().HasKey(a => new { a.IdCandidato, a.IdPeriodo });

            //convenções
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Properties<string>().Configure(c => c.HasColumnType("varchar"));
        }
    }
}