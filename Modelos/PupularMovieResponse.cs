using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace ClienteBlogBlazorWASM.Modelos
{
    public class PopularMovieResponse
    {
        [JsonPropertyName("page")]
        public int Page { get; set; }

        [JsonPropertyName("results")]
        public List<PopularMovie> Results { get; set; } = new();
    }
    //public class PupularMoviePagedResponse
    //{
    //    [JsonPropertyName("page")]
    //    public int Page { get; set; }

    //    [JsonPropertyName("results")]
    //    public IEnumerable<PopularMovie> Results { get; set; }

    //    [JsonPropertyName("total_pages")]
    //    public int TotalPages { get; set; }

    //    [JsonPropertyName("total_results")]
    //    public int TotalResults { get; set; }


    //}


    //q: como puedo ordenar codigo en visual studio?

    //a: ctrl + k + d

    //q: y en vscode?

    //a: alt + shift + f verdad?

    //q: si
}
