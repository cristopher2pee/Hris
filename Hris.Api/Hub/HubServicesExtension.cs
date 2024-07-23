using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace Hris.Api.Hub
{
    public static class HubServicesExtension
    {
        public static IServiceCollection HubJwtConfigure(this IServiceCollection services)
        {
            services.Configure<JwtBearerOptions>(JwtBearerDefaults.AuthenticationScheme, options =>
            {
                Func<MessageReceivedContext, Task> existingOnMessageReceivedHandler = options.Events.OnMessageReceived;
                options.Events.OnMessageReceived = async context =>
                {
                    await existingOnMessageReceivedHandler(context);

                    string accessToken = context.Request.Query["access_token"];
                    PathString path = context.HttpContext.Request.Path;

                    if (!string.IsNullOrEmpty(accessToken) && path.StartsWithSegments("/hubs/notifications"))
                    {
                        context.Token = accessToken;
                    }
                };
            });

            return services;
        }
    }
}
