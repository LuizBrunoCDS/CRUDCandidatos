using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;
using API.Controllers;
using API.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests.Tests
{
    [TestClass]
    public class Insert
    {
        [TestMethod]
        public void InsertEntity()
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
                Nome = "Jose Luiz",
                Email = "joseluiz.cds@outlook.com",
                Skype = "jose.luiz55",
                Telefone = "13 978028056",
                Linkedin = "joseluiz",
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
                LinkCrud = "linkcrud.jl",
                candidatoConhecimentos = new List<CandidatoConhecimento>
                {
                    new CandidatoConhecimento { IdConhecimento = 1, Nivel = 3 },
                    new CandidatoConhecimento { IdConhecimento = 2, Nivel = 3 },
                    new CandidatoConhecimento { IdConhecimento = 3, Nivel = 2 },
                    new CandidatoConhecimento { IdConhecimento = 4, Nivel = 3 },
                    new CandidatoConhecimento { IdConhecimento = 5, Nivel = 4 },
                    new CandidatoConhecimento { IdConhecimento = 6, Nivel = 3 },
                    new CandidatoConhecimento { IdConhecimento = 7, Nivel = 4 },
                    new CandidatoConhecimento { IdConhecimento = 8, Nivel = 3 },
                    new CandidatoConhecimento { IdConhecimento = 9, Nivel = 2 },
                    new CandidatoConhecimento { IdConhecimento = 10, Nivel = 1 },
                    new CandidatoConhecimento { IdConhecimento = 11, Nivel = 3 },
                    new CandidatoConhecimento { IdConhecimento = 12, Nivel = 3 },
                    new CandidatoConhecimento { IdConhecimento = 13, Nivel = 3 },
                    new CandidatoConhecimento { IdConhecimento = 14, Nivel = 4 },
                    new CandidatoConhecimento { IdConhecimento = 15, Nivel = 3 },
                    new CandidatoConhecimento { IdConhecimento = 16, Nivel = 3 },
                    new CandidatoConhecimento { IdConhecimento = 17, Nivel = 2 },
                    new CandidatoConhecimento { IdConhecimento = 18, Nivel = 3 },
                    new CandidatoConhecimento { IdConhecimento = 19, Nivel = 3 },
                    new CandidatoConhecimento { IdConhecimento = 20, Nivel = 3 },
                    new CandidatoConhecimento { IdConhecimento = 21, Nivel = 5 },
                    new CandidatoConhecimento { IdConhecimento = 22, Nivel = 3 },
                    new CandidatoConhecimento { IdConhecimento = 23, Nivel = 3 },
                    new CandidatoConhecimento { IdConhecimento = 24, Nivel = 3 },
                    new CandidatoConhecimento { IdConhecimento = 25, Nivel = 3 },
                    new CandidatoConhecimento { IdConhecimento = 26, DsOutros = "Delphi 3" }
                },
                candidatoHorarios = new List<CandidatoHorario>
                {
                    new CandidatoHorario { IdHorario = 3},
                    new CandidatoHorario { IdHorario = 4}
                },
                candidatoPeriodos = new List<CandidatoPeriodo>
                {
                    new CandidatoPeriodo { IdPeriodo = 2},
                    new CandidatoPeriodo { IdPeriodo = 4},
                    new CandidatoPeriodo { IdPeriodo = 5}
                }
            };

            var response = controller.Post(candidato);

            // Assert the result
            Assert.IsTrue(response.TryGetContentValue(out string msg));
            Assert.AreEqual("Inserido", "Inserido");
        }
    }
}
