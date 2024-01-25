using OneLog.MinimalApi.Middlewares;

namespace OneLog.MinimalApi.Extension
{
    public static class BuildExtension
    {
        public static void ExtendBuilder(this IApplicationBuilder app)
        {
            app.UseMiddleware<ErrorHandlerMiddleware>();
        }
    }
}
