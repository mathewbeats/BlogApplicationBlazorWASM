using Microsoft.AspNetCore.Components.Web;

namespace ClienteBlogBlazorWASM.Modelos
{
    public class RespuestaAutenticacion
    {
        public bool IsSuccess { get; set; }

        public string Token { get; set; }

        public Usuario Usuario { get; set; }
    }
}
