using OMDb.API.ServiceResponse;

namespace OMDb.API.Services.MovieService
{
    public interface IMovieService
    {
        Task<BaseResponse> SearchMovieByTitle(string search);
    }
}
