void InitServices(WebApplicationBuilder builder)
{
    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    InitCors(builder);
}

void InitCors(WebApplicationBuilder builder)
{
    builder.Services.AddCors(options => {
        options.AddDefaultPolicy(policy =>
        {
            if (builder.Environment.IsDevelopment())
            {
                policy.AllowAnyHeader();
                policy.AllowAnyOrigin();
                policy.AllowAnyMethod();
            } else
            {
                policy.WithOrigins("https://jdpodroze.pl")
                    .AllowAnyHeader()
                    .AllowAnyMethod();
            }
            policy.Build();
        });
    });
}

void InitMiddlewares(WebApplication application)
{   
    application.UseSwagger();
    application.UseSwaggerUI(options =>
    {
        options.DocumentTitle = "JDPodroze API";
    });
    application.UseHttpsRedirection();
    application.UseCors();
    application.UseAuthorization();
    application.MapControllers();
}

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
InitServices(builder);

WebApplication application = builder.Build();
InitMiddlewares(application);

application.Run();