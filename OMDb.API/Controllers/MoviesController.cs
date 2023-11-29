using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OMDb.API.Authentication;
using OMDb.API.Services.MovieService;

namespace OMDb.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    //[ServiceFilter(typeof(ApiKeyAuthFilter))]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }




        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> SearchMovieByTitle([FromQuery] string search)
        {
            try
            {
                var response = await _movieService.SearchMovieByTitle(search);
                if(response == null)
                    return NotFound();
                return Ok(response);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

     



       
    }
}
