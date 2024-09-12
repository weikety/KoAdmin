using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Ko.Common.Components.ApiUi
{
    public static class ApiUIExtension
    {
        public static IApplicationBuilder UseApiUI(this IApplicationBuilder app,Action<ApiUIOptions> setupAction = null)
        {
            var options = new ApiUIOptions();
            if (setupAction != null)
            {
                setupAction(options);
            }
            else
            {
                options = app.ApplicationServices.GetRequiredService<IOptions<ApiUIOptions>>().Value;
            }
            app.UseMiddleware<ApiUIMiddleware>(options);
            return app;
        }
    }
}
