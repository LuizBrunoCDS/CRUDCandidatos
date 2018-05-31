namespace API.Migrations
{
    using API.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Context.CRUDContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Context.CRUDContext context)
        {
            #region Horarios(usado para montar front)
            context.Horarios.AddOrUpdate(x => x.IdHorario,
                new Horario() { IdHorario = 1, DsHorario = "Up to 4 hours per day / Até 4 horas por dia" },
                new Horario() { IdHorario = 2, DsHorario = "4 to 6 hours per day / De 4 à 6 horas por dia" },
                new Horario() { IdHorario = 3, DsHorario = "6 to 8 hours per day / De 6 à 8 horas por dia" },
                new Horario() { IdHorario = 4, DsHorario = "Up to 8 hours a day (are you sure?) / Acima de 8 horas por dia (tem certeza?)" },
                new Horario() { IdHorario = 5, DsHorario = "Only weekends / Apenas finais de semana" }
           );
            #endregion
            #region Periodos (usado para montar front)
            context.Periodos.AddOrUpdate(x => x.IdPeriodo,
                new Periodo() { IdPeriodo = 1, DsPeriodo = "Morning (from 08:00 to 12:00) / Manhã (de 08:00 ás 12:00)" },
                new Periodo() { IdPeriodo = 2, DsPeriodo = "Afternoon (from 1:00 p.m. to 6:00 p.m.) / Tarde (de 13:00 ás 18:00)" },
                new Periodo() { IdPeriodo = 3, DsPeriodo = "Night (7:00 p.m. to 10:00 p.m.) / Noite (de 19:00 as 22:00)" },
                new Periodo() { IdPeriodo = 4, DsPeriodo = "Dawn (from 10 p.m. onwards) / Madrugada (de 22:00 em diante)" },
                new Periodo() { IdPeriodo = 5, DsPeriodo = "Business (from 08:00 a.m. to 06:00 p.m.) / Comercial (de 08:00 as 18:00)" }
           );
            #endregion
            #region Conhecimentos (usado para montar front)
            context.Conhecimentos.AddOrUpdate(x => x.IdConhecimento,
                new Conhecimento() { IdConhecimento = 1, DsConhecimento = "Ionic" },
                new Conhecimento() { IdConhecimento = 2, DsConhecimento = "Android" },
                new Conhecimento() { IdConhecimento = 3, DsConhecimento = "IOS" },
                new Conhecimento() { IdConhecimento = 4, DsConhecimento = "HTML" },
                new Conhecimento() { IdConhecimento = 5, DsConhecimento = "CSS" },
                new Conhecimento() { IdConhecimento = 6, DsConhecimento = "Bootstrap" },
                new Conhecimento() { IdConhecimento = 7, DsConhecimento = "JQuery" },
                new Conhecimento() { IdConhecimento = 8, DsConhecimento = "AngularJS" },
                new Conhecimento() { IdConhecimento = 9, DsConhecimento = "Java" },
                new Conhecimento() { IdConhecimento = 10, DsConhecimento = "Asp.Net MVC" },
                new Conhecimento() { IdConhecimento = 11, DsConhecimento = "C" },
                new Conhecimento() { IdConhecimento = 12, DsConhecimento = "C++" },
                new Conhecimento() { IdConhecimento = 13, DsConhecimento = "Cake" },
                new Conhecimento() { IdConhecimento = 14, DsConhecimento = "Django" },
                new Conhecimento() { IdConhecimento = 15, DsConhecimento = "Magento" },
                new Conhecimento() { IdConhecimento = 16, DsConhecimento = "PHP" },
                new Conhecimento() { IdConhecimento = 17, DsConhecimento = "Wordpress" },
                new Conhecimento() { IdConhecimento = 18, DsConhecimento = "Python" },
                new Conhecimento() { IdConhecimento = 19, DsConhecimento = "Ruby" },
                new Conhecimento() { IdConhecimento = 20, DsConhecimento = "SQL Server" },
                new Conhecimento() { IdConhecimento = 21, DsConhecimento = "MySQL" },
                new Conhecimento() { IdConhecimento = 22, DsConhecimento = "Salesforce" },
                new Conhecimento() { IdConhecimento = 23, DsConhecimento = "Photoshop" },
                new Conhecimento() { IdConhecimento = 24, DsConhecimento = "Illustrator" },
                new Conhecimento() { IdConhecimento = 25, DsConhecimento = "SEO" },
                new Conhecimento() { IdConhecimento = 26, DsConhecimento = "Outros" }
           );
            #endregion
            #region Candidato
            context.Candidatos.AddOrUpdate(x => x.IdCandidato,
                new Candidato()
                {
                    IdCandidato = 1,
                    Nome = "Luiz Bruno",
                    Email = "luizbruno.cds@outlook.com",
                    Skype = "luiz.bruno20",
                    Telefone = "13 981554881",
                    Linkedin = "luizbruno",
                    Cidade = "Cubatao",
                    Estado = "SP",
                    Portfolio = "portfolio",
                    PretensaoSalarial = 25,
                    NomeBanco = "Bradesco",
                    NomeBeneficiarioBanco = "Luiz Bruno",
                    CpfBeneficiarioBanco = "12345678900",
                    TipoConta = "Corrente",
                    AgenciaBanco = "0123",
                    ContaBanco = "01234-5",
                    LinkCrud = "linkcrud.lb"
                },
                new Candidato()
                {
                    IdCandidato = 2,
                    Nome = "Luiz Felipe",
                    Email = "luizfelipe.cds@outlook.com",
                    Skype = "luiz.felipe15",
                    Telefone = "13 981615434",
                    Linkedin = "luizfelipe",
                    Cidade = "Cubatao",
                    Estado = "SP",
                    Portfolio = "portfolio",
                    PretensaoSalarial = 20,
                    NomeBanco = "Bradesco",
                    NomeBeneficiarioBanco = "Luiz Felipe",
                    CpfBeneficiarioBanco = "12345678999",
                    TipoConta = "Corrente",
                    AgenciaBanco = "1234",
                    ContaBanco = "12345-6",
                    LinkCrud = "linkcrud.lf"
                }
            );
            #endregion
            #region CandidatoConhecimentos
            context.CandidatoConhecimentos.AddOrUpdate(
                new CandidatoConhecimento() { IdCandidato = 1, IdConhecimento = 1, Nivel = 3 },
                new CandidatoConhecimento() { IdCandidato = 1, IdConhecimento = 2, Nivel = 3 },
                new CandidatoConhecimento() { IdCandidato = 1, IdConhecimento = 3, Nivel = 2 },
                new CandidatoConhecimento() { IdCandidato = 1, IdConhecimento = 4, Nivel = 3 },
                new CandidatoConhecimento() { IdCandidato = 1, IdConhecimento = 5, Nivel = 4 },
                new CandidatoConhecimento() { IdCandidato = 1, IdConhecimento = 6, Nivel = 3 },
                new CandidatoConhecimento() { IdCandidato = 1, IdConhecimento = 7, Nivel = 4 },
                new CandidatoConhecimento() { IdCandidato = 1, IdConhecimento = 8, Nivel = 3 },
                new CandidatoConhecimento() { IdCandidato = 1, IdConhecimento = 9, Nivel = 2 },
                new CandidatoConhecimento() { IdCandidato = 1, IdConhecimento = 10, Nivel = 1 },
                new CandidatoConhecimento() { IdCandidato = 1, IdConhecimento = 11, Nivel = 3 },
                new CandidatoConhecimento() { IdCandidato = 1, IdConhecimento = 12, Nivel = 3 },
                new CandidatoConhecimento() { IdCandidato = 1, IdConhecimento = 13, Nivel = 3 },
                new CandidatoConhecimento() { IdCandidato = 1, IdConhecimento = 14, Nivel = 4 },
                new CandidatoConhecimento() { IdCandidato = 1, IdConhecimento = 15, Nivel = 3 },
                new CandidatoConhecimento() { IdCandidato = 1, IdConhecimento = 16, Nivel = 3 },
                new CandidatoConhecimento() { IdCandidato = 1, IdConhecimento = 17, Nivel = 2 },
                new CandidatoConhecimento() { IdCandidato = 1, IdConhecimento = 18, Nivel = 3 },
                new CandidatoConhecimento() { IdCandidato = 1, IdConhecimento = 19, Nivel = 3 },
                new CandidatoConhecimento() { IdCandidato = 1, IdConhecimento = 20, Nivel = 3 },
                new CandidatoConhecimento() { IdCandidato = 1, IdConhecimento = 21, Nivel = 5 },
                new CandidatoConhecimento() { IdCandidato = 1, IdConhecimento = 22, Nivel = 3 },
                new CandidatoConhecimento() { IdCandidato = 1, IdConhecimento = 23, Nivel = 3 },
                new CandidatoConhecimento() { IdCandidato = 1, IdConhecimento = 24, Nivel = 3 },
                new CandidatoConhecimento() { IdCandidato = 1, IdConhecimento = 25, Nivel = 3 },
                new CandidatoConhecimento() { IdCandidato = 1, IdConhecimento = 26, DsOutros = "Cobol 3" },

                new CandidatoConhecimento() { IdCandidato = 2, IdConhecimento = 1, Nivel = 1 },
                new CandidatoConhecimento() { IdCandidato = 2, IdConhecimento = 2, Nivel = 3 },
                new CandidatoConhecimento() { IdCandidato = 2, IdConhecimento = 3, Nivel = 3 },
                new CandidatoConhecimento() { IdCandidato = 2, IdConhecimento = 4, Nivel = 2 },
                new CandidatoConhecimento() { IdCandidato = 2, IdConhecimento = 5, Nivel = 3 },
                new CandidatoConhecimento() { IdCandidato = 2, IdConhecimento = 6, Nivel = 3 },
                new CandidatoConhecimento() { IdCandidato = 2, IdConhecimento = 7, Nivel = 3 },
                new CandidatoConhecimento() { IdCandidato = 2, IdConhecimento = 8, Nivel = 4 },
                new CandidatoConhecimento() { IdCandidato = 2, IdConhecimento = 9, Nivel = 3 },
                new CandidatoConhecimento() { IdCandidato = 2, IdConhecimento = 10, Nivel = 3 },
                new CandidatoConhecimento() { IdCandidato = 2, IdConhecimento = 11, Nivel = 3 },
                new CandidatoConhecimento() { IdCandidato = 2, IdConhecimento = 12, Nivel = 3 },
                new CandidatoConhecimento() { IdCandidato = 2, IdConhecimento = 13, Nivel = 2 },
                new CandidatoConhecimento() { IdCandidato = 2, IdConhecimento = 14, Nivel = 3 },
                new CandidatoConhecimento() { IdCandidato = 2, IdConhecimento = 15, Nivel = 3 },
                new CandidatoConhecimento() { IdCandidato = 2, IdConhecimento = 16, Nivel = 3 },
                new CandidatoConhecimento() { IdCandidato = 2, IdConhecimento = 17, Nivel = 3 },
                new CandidatoConhecimento() { IdCandidato = 2, IdConhecimento = 18, Nivel = 3 },
                new CandidatoConhecimento() { IdCandidato = 2, IdConhecimento = 19, Nivel = 3 },
                new CandidatoConhecimento() { IdCandidato = 2, IdConhecimento = 20, Nivel = 1 },
                new CandidatoConhecimento() { IdCandidato = 2, IdConhecimento = 21, Nivel = 3 },
                new CandidatoConhecimento() { IdCandidato = 2, IdConhecimento = 22, Nivel = 3 },
                new CandidatoConhecimento() { IdCandidato = 2, IdConhecimento = 23, Nivel = 3 },
                new CandidatoConhecimento() { IdCandidato = 2, IdConhecimento = 24, Nivel = 3 },
                new CandidatoConhecimento() { IdCandidato = 2, IdConhecimento = 25, Nivel = 3 },
                new CandidatoConhecimento() { IdCandidato = 2, IdConhecimento = 26, DsOutros = null }
                );
            #endregion
            #region CandidatoPeriodo
            context.CandidatoPeriodos.AddOrUpdate(
                new CandidatoPeriodo() { IdCandidato = 1, IdPeriodo = 1 },
                new CandidatoPeriodo() { IdCandidato = 1, IdPeriodo = 5 },
                new CandidatoPeriodo() { IdCandidato = 2, IdPeriodo = 5 }
                );
            #endregion
            #region CandidatoHorario
            context.CandidatoHorarios.AddOrUpdate(
                new CandidatoHorario() { IdCandidato = 1, IdHorario = 2 },
                new CandidatoHorario() { IdCandidato = 1, IdHorario = 3 },
                new CandidatoHorario() { IdCandidato = 2, IdHorario = 3 },
                new CandidatoHorario() { IdCandidato = 2, IdHorario = 4 }
                );
            #endregion
        }
    }
}
