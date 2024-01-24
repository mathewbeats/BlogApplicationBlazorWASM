using System.Security.Claims;
using System.Text.Json;

namespace ClienteBlogBlazorWASM.Helpers
{
    public class JwtParser
    {
        //piezas de informacion sobre un usuario que se almacenan en un token de seguridad despues de que un usuario se autentica en una aplicacion
        //estos claims representan afirmaciones sonbre la identidad del usuario y otros datos relaccionados con el
        //los claims son esenciales para implementar la autenticacion basada en roles
        //este token contendra una serie de claims que contendran la identidad y atributos del usuario
        public static IEnumerable<Claim> ParseClaimsFromJwt(string jwt)
        {
            var claims = new List<Claim>();
            var payload = jwt.Split('.')[1];
            var jsonBytes = ParsearEnBase64SinMargen(payload);

            //aqui usamos el jsonserializer para realizar la deserializacion de un arreglo de bytes que va a recibir un string y un objeto
            //va a pasar de un formato json a un objeto de .net, el json representa un objeto json que se puede mapear en un diccionario
            //donde las llaves los keys seria un string y los valores podrian ser objetos
            var keyValuePairs = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonBytes);

            claims.AddRange(keyValuePairs.Select(kvp => new Claim(kvp.Key,kvp.Value.ToString())));

            return claims;
        }

        //la codificacion en base64 se utiliza comunmente para representar datos binarios como imagenes, archivos..esta codificacion
        //se utiiza en conjunto de caracteres seguros que incluye letras mayusculas minusculas, caracteres... 
        //hay que tener en cuenta que esta codificacion usa ademas el signo = como rellleno para asegurar que la longitud de la cadena en base64 sea multiplo de 4
        //exsiten dos opciones, en el primer caso se añaden dos == de relleno, esto es necesario para que la cadena tenga una longitud multiplo de 4



        //private static byte[] ParsearEnBase64SinMargen(string base64)
        //{
        //    switch (base64.Length)
        //    {
        //        case 2: base64 += "=="; break;

        //        case 3: base64 += "="; break; 

        //    }

        //    //esto se ejecuta al final para decodificar la cadena base64 y pasarlo a una cadena de bytes
        //    return Convert.FromBase64String(base64);
        //}


        private static byte[] ParsearEnBase64SinMargen(string base64)
        {
            base64 = base64.Replace('-', '+').Replace('_', '/'); // Reemplaza caracteres no válidos en Base-64 URL.
            switch (base64.Length % 4) // Añade relleno solo si es necesario.
            {
                case 2: base64 += "=="; break;
                case 3: base64 += "="; break;
            }
            return Convert.FromBase64String(base64);
        }

    }
}
