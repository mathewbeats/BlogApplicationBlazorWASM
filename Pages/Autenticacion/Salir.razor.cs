using ClienteBlogBlazorWASM.Services.IServices;
using Microsoft.AspNetCore.Components;

namespace ClienteBlogBlazorWASM.Pages.Autenticacion
{
    public partial class Salir
    {

        [Inject]
        IServicioAutenticacion ServicioAutenticacion { get; set; }

        [Inject]
        NavigationManager NavigationManager { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await ServicioAutenticacion.Salir();
            NavigationManager.NavigateTo("/");
        }


    }
}
