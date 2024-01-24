using Microsoft.JSInterop;
namespace ClienteBlogBlazorWASM.Helpers
{

    public static class IJsHelper
    {
        public static async ValueTask ToastrSuccess(this IJSRuntime JSRuntime, string message)
        {
            await JSRuntime.InvokeVoidAsync("ShowToastr", "success", message);
        }

        public static async ValueTask ToastrError(this IJSRuntime JSRuntime, string message)
        {
            await JSRuntime.InvokeVoidAsync("ShowToastr", "error", message);
        }


        public static async ValueTask CarrouselBlazor(this IJSRuntime jSRuntime)
        {
            await jSRuntime.CarrouselBlazor();
        }
    }


}
