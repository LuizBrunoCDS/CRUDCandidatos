using System.Net.Http;
using System.Web.Http;
using API.Controllers;
using API.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests.Tests
{
    [TestClass]
    public class Select
    {
        [TestMethod]
        public void SelectCandidatosByID()
        {
            // Set up Prerequisites 
            var controller = new CandidatoController
            {
                Request = new HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };

            // Act on Test
            var response = controller.Get(1);

            // Assert the result           
            Assert.IsTrue(response.TryGetContentValue(out Candidato candidato));
            Assert.AreEqual("Luiz Bruno", candidato.Nome);
        }
    }
}
