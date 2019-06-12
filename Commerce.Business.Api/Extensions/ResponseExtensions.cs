using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Commerce.Business.Api.Extensions
{
    public static class ResponseExtensions
    {
        public static void AddApplicationError(this HttpResponse response, string message)
        {
            response.Headers.Add("Application-Error", message);
            response.Headers.Add("Access-Control-Expose-Origin-Headers", "Application-Error");
        }

        public static class Errors
        {
            public static ModelStateDictionary AddErrorModelState(IdentityResult identityResult,
                ModelStateDictionary modelState)
            {
                foreach (var e in identityResult.Errors) modelState.TryAddModelError(e.Code, e.Description);

                return modelState;
            }

            public static ModelStateDictionary AddErrorModelState(string code, string description,
                ModelStateDictionary modelState)
            {
                modelState.TryAddModelError(code, description);
                return modelState;
            }
        }
    }
}