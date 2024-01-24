using ClienteBlogBlazorWASM.Modelos;
using System.Net.Http.Json;

namespace ClienteBlogBlazorWASM.Services
{
    public class TMDBClient
    {
        private readonly HttpClient _httpClient;

        public TMDBClient(HttpClient httpClient, IConfiguration config)
        {
            _httpClient = httpClient;

            _httpClient.BaseAddress = new Uri("https://api.themovieorg.org/3");
            _httpClient.DefaultRequestHeaders.Accept.Add(new("application/json"));

            string apiKey = config["tmdbKey:APIKey"] ?? throw new Exception("APIKey not found");
            _httpClient.DefaultRequestHeaders.Authorization = new("Bearer", apiKey);

        }


        public Task<PopularMovieResponse> GetPopularMoviesAsync()
        {
            return _httpClient.GetFromJsonAsync<PopularMovieResponse>($"movie/popular");
        }
    }

    //var tmdbKey = builder.Configuration["tmdbKey:TMDBKey"];
}
