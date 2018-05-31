namespace API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CandidatoConhecimento",
                c => new
                    {
                        IdCandidato = c.Int(nullable: false),
                        IdConhecimento = c.Int(nullable: false),
                        DsOutros = c.String(maxLength: 8000, unicode: false),
                        Nivel = c.Int(),
                    })
                .PrimaryKey(t => new { t.IdCandidato, t.IdConhecimento })
                .ForeignKey("dbo.Candidato", t => t.IdCandidato)
                .ForeignKey("dbo.Conhecimento", t => t.IdConhecimento)
                .Index(t => t.IdCandidato)
                .Index(t => t.IdConhecimento);
            
            CreateTable(
                "dbo.Candidato",
                c => new
                    {
                        IdCandidato = c.Int(nullable: false, identity: true),
                        Nome = c.String(maxLength: 100, unicode: false),
                        Email = c.String(maxLength: 100, unicode: false),
                        Skype = c.String(maxLength: 20, unicode: false),
                        Telefone = c.String(maxLength: 20, unicode: false),
                        Linkedin = c.String(maxLength: 200, unicode: false),
                        Cidade = c.String(maxLength: 100, unicode: false),
                        Estado = c.String(maxLength: 2, unicode: false),
                        Portfolio = c.String(maxLength: 100, unicode: false),
                        PretensaoSalarial = c.Single(nullable: false),
                        NomeBanco = c.String(maxLength: 30, unicode: false),
                        NomeBeneficiarioBanco = c.String(maxLength: 100, unicode: false),
                        CpfBeneficiarioBanco = c.String(maxLength: 20, unicode: false),
                        TipoConta = c.String(maxLength: 10, unicode: false),
                        AgenciaBanco = c.String(maxLength: 20, unicode: false),
                        ContaBanco = c.String(maxLength: 20, unicode: false),
                        LinkCrud = c.String(maxLength: 200, unicode: false),
                    })
                .PrimaryKey(t => t.IdCandidato);
            
            CreateTable(
                "dbo.CandidatoHorario",
                c => new
                    {
                        IdCandidato = c.Int(nullable: false),
                        IdHorario = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.IdCandidato, t.IdHorario })
                .ForeignKey("dbo.Candidato", t => t.IdCandidato)
                .ForeignKey("dbo.Horario", t => t.IdHorario)
                .Index(t => t.IdCandidato)
                .Index(t => t.IdHorario);
            
            CreateTable(
                "dbo.Horario",
                c => new
                    {
                        IdHorario = c.Int(nullable: false, identity: true),
                        DsHorario = c.String(maxLength: 8000, unicode: false),
                    })
                .PrimaryKey(t => t.IdHorario);
            
            CreateTable(
                "dbo.CandidatoPeriodo",
                c => new
                    {
                        IdCandidato = c.Int(nullable: false),
                        IdPeriodo = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.IdCandidato, t.IdPeriodo })
                .ForeignKey("dbo.Candidato", t => t.IdCandidato)
                .ForeignKey("dbo.Periodo", t => t.IdPeriodo)
                .Index(t => t.IdCandidato)
                .Index(t => t.IdPeriodo);
            
            CreateTable(
                "dbo.Periodo",
                c => new
                    {
                        IdPeriodo = c.Int(nullable: false, identity: true),
                        DsPeriodo = c.String(maxLength: 8000, unicode: false),
                    })
                .PrimaryKey(t => t.IdPeriodo);
            
            CreateTable(
                "dbo.Conhecimento",
                c => new
                    {
                        IdConhecimento = c.Int(nullable: false, identity: true),
                        DsConhecimento = c.String(maxLength: 8000, unicode: false),
                    })
                .PrimaryKey(t => t.IdConhecimento);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CandidatoConhecimento", "IdConhecimento", "dbo.Conhecimento");
            DropForeignKey("dbo.CandidatoPeriodo", "IdPeriodo", "dbo.Periodo");
            DropForeignKey("dbo.CandidatoPeriodo", "IdCandidato", "dbo.Candidato");
            DropForeignKey("dbo.CandidatoHorario", "IdHorario", "dbo.Horario");
            DropForeignKey("dbo.CandidatoHorario", "IdCandidato", "dbo.Candidato");
            DropForeignKey("dbo.CandidatoConhecimento", "IdCandidato", "dbo.Candidato");
            DropIndex("dbo.CandidatoPeriodo", new[] { "IdPeriodo" });
            DropIndex("dbo.CandidatoPeriodo", new[] { "IdCandidato" });
            DropIndex("dbo.CandidatoHorario", new[] { "IdHorario" });
            DropIndex("dbo.CandidatoHorario", new[] { "IdCandidato" });
            DropIndex("dbo.CandidatoConhecimento", new[] { "IdConhecimento" });
            DropIndex("dbo.CandidatoConhecimento", new[] { "IdCandidato" });
            DropTable("dbo.Conhecimento");
            DropTable("dbo.Periodo");
            DropTable("dbo.CandidatoPeriodo");
            DropTable("dbo.Horario");
            DropTable("dbo.CandidatoHorario");
            DropTable("dbo.Candidato");
            DropTable("dbo.CandidatoConhecimento");
        }
    }
}
