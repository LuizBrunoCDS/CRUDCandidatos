using System.Net.Http;
using System.Web.Http;
using API.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests.Tests
{
    [TestClass]
    public class Delete
    {
        [TestMethod]
        public void DeleteEntity()
        {
            // Set up Prerequisites 
            var controller = new CandidatoController
            {
                Request = new HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };

            // Act on Test
            var response = controller.Delete(2);

            // Assert the result
            Assert.IsTrue(response.TryGetContentValue(out string msg));
            Assert.AreEqual("Removido", "Removido");
        }
    }
}
