using Microsoft.JSInterop;
    // we need this using 
namespace MonusProject.Client.Helper
{
    public static class JsRuntimeExtensions
    {
        public static ValueTask<bool> Confirm(this IJSRuntime jsruntime, string message)
        {
            return jsruntime.InvokeAsync<bool>("confirm", message);
        }

        public static void Test(this IJSRuntime jsRuntime, string message)
        {
            jsRuntime.InvokeVoidAsync("test", message);
        }

        public static ValueTask Alert(this IJSRuntime jsRuntime, string message)
        {

            return jsRuntime.InvokeVoidAsync("alert", message);
        }

        // I have added this 
        public static void HidePopup(this IJSRuntime jsRuntime)
        {
            jsRuntime.InvokeVoidAsync("hidePopup");
        }
    }
}
