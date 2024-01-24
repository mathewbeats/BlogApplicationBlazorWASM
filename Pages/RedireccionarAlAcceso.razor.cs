using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components;


namespace ClienteBlazorWASM.Pages
{
    // La clase RedireccionarAlAcceso hereda de ComponentBase, que es la base para los componentes de Blazor.
    public partial class RedireccionarAlAcceso:ComponentBase
    {
        // Inyección de dependencia para NavigationManager.
        // NavigationManager es un servicio de Blazor que te permite interactuar con la URL del navegador.
        [Inject]
        private NavigationManager NavigationManager { get; set; }

        // CascadingParameter permite recibir un parámetro de un componente padre.
        // En este caso, se está accediendo al estado de autenticación actual (AuthenticationState).
        [CascadingParameter]
        private Task<AuthenticationState> EstadoProveedorAutenticacion { get; set; }

        // Una propiedad booleana para controlar si se muestra o no el contenido "no autorizado".
        public bool NoAutorizado { get; set; } = false;

        // OnInitializedAsync se llama después de que el componente se ha inicializado, pero antes de que se haya renderizado.
        protected override async Task OnInitializedAsync()
        {
            // Espera a que se complete la tarea del estado de autenticación.
            var estadoAutorizacion = await EstadoProveedorAutenticacion;

            // Comprueba si el usuario actual está autenticado.
            if (!estadoAutorizacion.User.Identity.IsAuthenticated)
            {
                // Si no está autenticado, obtiene la URL actual y la convierte en una ruta relativa.
                var returnUrl = NavigationManager.ToBaseRelativePath(NavigationManager.Uri);

                // Redirige al usuario a la página de acceso ('Acceder').
                // Si returnUrl no está vacío, lo agrega como parámetro en la URL.
                NavigationManager.NavigateTo($"Acceder?returnUrl={returnUrl}", true);
            }
            else
            {
                // Si el usuario está autenticado, pero accedió a una página para la cual no está autorizado,
                // establece la propiedad noAutorizado en true para mostrar un mensaje en la interfaz de usuario.
                NoAutorizado = true;
            }
        }
    }
}


