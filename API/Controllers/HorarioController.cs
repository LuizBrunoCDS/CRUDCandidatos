using API.Repository;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
    public class HorarioController : ApiController
    {
        private readonly UnitOfWork unitOfWork = new UnitOfWork();

        // GET: Horario    
        [Route("Horarios/Get")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            var horarios = unitOfWork.HorarioRepositorio.SelectAll();
            if (horarios == null)
                return Request.CreateResponse(HttpStatusCode.NotFound);
            return Request.CreateResponse(HttpStatusCode.OK, horarios);
        }
    }
}
