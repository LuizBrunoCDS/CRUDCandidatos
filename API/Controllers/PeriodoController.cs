using API.Repository;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
    public class PeriodoController : ApiController
    {
        private readonly UnitOfWork unitOfWork = new UnitOfWork();

        // GET: Periodo    
        [Route("Periodos/Get")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            var periodos = unitOfWork.PeriodoRepositorio.SelectAll();
            if (periodos == null)
                return Request.CreateResponse(HttpStatusCode.NotFound);
            return Request.CreateResponse(HttpStatusCode.OK, periodos);
        }
    }
}
