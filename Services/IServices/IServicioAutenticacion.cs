using ClienteBlogBlazorWASM.Modelos;

namespace ClienteBlogBlazorWASM.Services.IServices
{
    public interface IServicioAutenticacion
    {
        Task<UusuarioRespuestaRegistro> RegistrarUsuario(UsuarioRegistro usuarioRegistro);

        Task<RespuestaAutenticacion> Acceder(UsuarioAutenticacion usuarioDesdeAutenticacion);

        Task Salir();




    }
}
