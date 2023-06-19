namespace JDPodrozeAPI.Core.Extensions
{
    public static class WebApplicationExtension
    {
        public static void AddMiddlewares(this WebApplication application)
        {
            application.UseSwagger();
            application.UseSwaggerUI(options =>
            {
                options.DocumentTitle = "JDPodroze API";
            });
            application.UseHttpsRedirection();
            application.UseCors();
            application.UseAuthentication();
            application.UseAuthorization();
            application.MapControllers();
        }
    }
}