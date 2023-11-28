using Microsoft.Extensions.Options;
using OMDb.API.Options;

namespace OMDb.API.Services.MovieService
{
    public class MovieService : IMovieService
    {
        private readonly IMovieService _movieService;
        private readonly AppSettingsConfig _appSettings;
        public MovieService(IMovieService movieService, IOptions<AppSettingsConfig> appSettings)
        {
            _movieService = movieService;
            _appSettings = appSettings.Value;
        }


    }
}
