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

            string API_KEY = "b5eb089";

            string OMDB_API_URL = "http://www.omdbapi.com/";

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
                //Add Exception Log here:
                throw;
            }
        }

       


    }
}
