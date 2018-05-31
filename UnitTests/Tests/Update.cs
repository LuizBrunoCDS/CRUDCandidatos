using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;
using API.Controllers;
using API.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests.Tests
{
    [TestClass]
    public class Update
    {
        [TestMethod]
        public void UpdateEntity()
        {
            // Set up Prerequisites 
            var controller = new CandidatoController
            {
                Request = new HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };

            // Act on Test            
            Candidato candidato = new Candidato()
            {
                IdCandidato = 1,
                Nome = "Jose Luiz",
                Email = "joseluizsfc@uol.com",
                Skype = "jose.luiz55",
                Telefone = "13 978028056",
                Linkedin = "joseluizsfc",
                Cidade = "Cubatao",
                Estado = "SP",
                Portfolio = "portfolio",
                PretensaoSalarial = 25,
                NomeBanco = "Caixa Economica",
                NomeBeneficiarioBanco = "Jose Luiz",
                CpfBeneficiarioBanco = "11223344556",
                TipoConta = "Corrente",
                AgenciaBanco = "012",
                ContaBanco = "012345-5",
                LinkCrud = "linkcrud.jlsfc",
                candidatoConhecimentos = new List<CandidatoConhecimento>
                {
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
                    new CandidatoConhecimento() { IdCandidato = 1, IdConhecimento = 26, DsOutros = "Delphi 4" },
                },
                candidatoPeriodos = new List<CandidatoPeriodo>
                {
                    new CandidatoPeriodo() { IdCandidato = 1, IdPeriodo = 3 }
                },
                candidatoHorarios = new List<CandidatoHorario>
                {
                    new CandidatoHorario() { IdCandidato = 1, IdHorario = 4 }
                }
            };

            var response = controller.Put(candidato);

            // Assert the result
            Assert.IsTrue(response.TryGetContentValue(out string msg));
            Assert.AreEqual("Alterado", "Alterado");
        }
    }
}
