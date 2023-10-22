using IRDbWebApp.Models;

namespace IRDbWebApp.Api
{
    public class ApiCaller
    {
        private readonly HttpClient _client;
        public ApiCaller() 
        {
            _client = ApiInitilizer.Client;
        }

        public async Task<IEnumerable<MovieModel>?> GetMovies()
        {
            HttpResponseMessage response = await _client.GetAsync("Movies");

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<IEnumerable<MovieModel>>();
            }
            return null;
         }

        public async Task AddMovie(MovieModel movie)
        {
           await _client.PostAsJsonAsync<MovieModel>("Movies", movie);
        }


    }
}
