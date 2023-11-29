using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using OMDb.API.Models;
using OMDb.API.Options;
using OMDb.API.ServiceResponse;
using System.Net.Http.Headers;

namespace OMDb.API.Services.MovieService
{
    public class MovieService : IMovieService
    {
        private readonly AppSettingsConfig _appSettings;

        public MovieService(IOptions<AppSettingsConfig> options)
        {
            _appSettings = options.Value;;
        }

        public async Task<BaseResponse> SearchMovieByTitle(string search)
        {
            using var httpClient = new HttpClient();

            string API_KEY = _appSettings.ApiKey;

            string OMDB_API_URL = _appSettings.OmdbURL;

            string baseUrl = $"{OMDB_API_URL}?apiKey={API_KEY}&t={search}";

            try
            {

                var request = new HttpRequestMessage(HttpMethod.Get, baseUrl);

                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await httpClient.SendAsync(request);
                if (!response.IsSuccessStatusCode)
                {
                    return new BaseResponse(false, null, $"API call failed with status code: {response.StatusCode}");
                }

                var movieJson = await response.Content.ReadAsStringAsync();
                var movie = JsonConvert.DeserializeObject<MovieModel>(movieJson);

                return new BaseResponse(true, movie, "Successful");

            }
            catch (Exception ex)
            {
                //TODO: Add Exception Log here:
                throw;
            }
        }




    }
}
