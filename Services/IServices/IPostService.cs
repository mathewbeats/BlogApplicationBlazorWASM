using ClienteBlogBlazorWASM.Modelos;

namespace ClienteBlogBlazorWASM.Services.IServices
{
    public interface IPostService
    {
        public Task<IEnumerable<Post>> GetPosts();

        public Task<Post> GetPost(int postId);

        public Task<Post> CrearPost(Post post);

        public Task<Post>ActualizarPost(int postId, Post post);

        public Task<bool> EliminarPost(int postId);

        public Task<string> SubidaDeImagen(MultipartFormDataContent content);

        public Task<ICollection<Post>> GetPostByUserAsync();
    }
}
