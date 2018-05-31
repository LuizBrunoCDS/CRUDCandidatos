using API.Repository;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
    public class ConhecimentoController : ApiController
    {
        private readonly UnitOfWork unitOfWork = new UnitOfWork();

        // GET: Conhecimentos    
        [Route("Conhecimentos/Get")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            var conhecimentos = unitOfWork.ConhecimentoRepositorio.SelectAll();
            if (conhecimentos == null)
                return Request.CreateResponse(HttpStatusCode.NotFound);
            return Request.CreateResponse(HttpStatusCode.OK, conhecimentos);
        }
    }
}
