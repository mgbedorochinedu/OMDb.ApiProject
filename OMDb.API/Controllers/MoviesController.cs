using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OMDb.API.Authentication;

namespace OMDb.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[ServiceFilter(typeof(ApiKeyAuthFilter))]
    public class MoviesController : ControllerBase
    {
        public MoviesController()
        {

        }
    }
}
