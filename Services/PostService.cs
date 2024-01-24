using ClienteBlogBlazorWASM.Helpers;
using ClienteBlogBlazorWASM.Modelos;
using ClienteBlogBlazorWASM.Services.IServices;
using Newtonsoft.Json;
using System.Text;

namespace ClienteBlogBlazorWASM.Services
{
    public class PostService : IPostService
    {

        private readonly HttpClient _httpClient;

        public PostService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Post> ActualizarPost(int postId, Post post)
        {
            var content = JsonConvert.SerializeObject(post);

            var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");
            var response = await _httpClient.PatchAsync($"{Inicializar.UrlBaseApi}api/posts/{postId}", bodyContent);

            if (response.IsSuccessStatusCode)
            {
                var contentTemp = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<Post>(contentTemp);

                return result;
            }
            else
            {
                var contentTemp = await response.Content?.ReadAsStringAsync();
                var errorModel = JsonConvert.DeserializeObject<ModeloError>(contentTemp);
                throw new Exception(errorModel.ErrorMessage);
            }
        }

        public async Task<Post> CrearPost(Post post)
        {
            var content = JsonConvert.SerializeObject(post);

            var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync($"{Inicializar.UrlBaseApi}api/posts", bodyContent);

            if (response.IsSuccessStatusCode)
            {
                var contentTemp = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<Post>(contentTemp);
                return result;
            }
            else
            {
                var contentTemp = await response.Content.ReadAsStringAsync();

                var errorModel = JsonConvert.DeserializeObject<ModeloError>(contentTemp);

                throw new Exception(errorModel.ErrorMessage);
            }


        }

        public async Task<bool> EliminarPost(int postId)
        {
            var response = await _httpClient.DeleteAsync($"{Inicializar.UrlBaseApi}api/posts/{postId}");
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                var content = await response.Content.ReadAsStringAsync();
                var errorModel = JsonConvert.DeserializeObject<ModeloError>(content);
                throw new Exception(errorModel.ErrorMessage);
            }
        }

        public async Task<Post> GetPost(int postId)
        {
            var response = await _httpClient.GetAsync($"{Inicializar.UrlBaseApi}api/posts/{postId}");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();

                var post = JsonConvert.DeserializeObject<Post>(content);

                return post;
            }
            else
            {
                var content = await response.Content.ReadAsStringAsync();
                var errorModel = JsonConvert.DeserializeObject<ModeloError>(content);
                throw new Exception(errorModel.ErrorMessage);
            }
        }

        public async Task<IEnumerable<Post>> GetPosts()
        {
            var response = await _httpClient.GetAsync($"{Inicializar.UrlBaseApi}api/posts");

            var content = await response.Content.ReadAsStringAsync();

            var posts = JsonConvert.DeserializeObject<IEnumerable<Post>>(content);

            return posts;
        }

        public async Task<string> SubidaDeImagen(MultipartFormDataContent content)
        {
            var postResult = await _httpClient.PostAsync($"{Inicializar.UrlBaseApi}api/upload", content);

            var postContent = await postResult.Content.ReadAsStringAsync();

            if (!postResult.IsSuccessStatusCode)
            {
                throw new ApplicationException(postContent);

            }
            else
            {
                var imagenPost = Path.Combine($"{Inicializar.UrlBaseApi}", postContent);
                return imagenPost;
            }


        }

        public async Task<ICollection<Post>> GetPostByUserAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync($"{Inicializar.UrlBaseApi}api/posts/PostByUser");

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();

                    // Intenta analizar la lista de posts
                    var contentTemp = JsonConvert.DeserializeObject<ICollection<Post>>(content);

                    // Si la lista está vacía, devuelve una lista vacía en lugar de null
                    return contentTemp ?? new List<Post>();
                }
                else
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var contentTemp = JsonConvert.DeserializeObject<ModeloError>(content);
                    throw new Exception($"Error al procesar su solicitud {contentTemp?.ErrorMessage}");
                }
            }
            catch (Exception ex)
            {
                // Manejar la excepción aquí, por ejemplo, registrándola o devolviendo una lista vacía
                return new List<Post>();
            }
        }
    }

}
