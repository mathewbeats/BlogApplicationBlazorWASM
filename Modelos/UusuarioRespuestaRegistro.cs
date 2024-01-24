namespace ClienteBlogBlazorWASM.Modelos
{
    public class UusuarioRespuestaRegistro
    {
        public bool RegistroCorrecto { get; set; }  

        public IEnumerable<string> Errores { get; set; }
    }
}
