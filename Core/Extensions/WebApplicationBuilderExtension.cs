using Amazon;
using Amazon.Extensions.NETCore.Setup;
using Amazon.Runtime;
using FluentValidation;
using JDPodrozeAPI.Controllers.Account.Contracts.Requests;
using JDPodrozeAPI.Controllers.Account.Contracts.Requests.Validators;
using JDPodrozeAPI.Controllers.Contact.Contracts.Requests;
using JDPodrozeAPI.Controllers.Contact.Validators;
using JDPodrozeAPI.Controllers.Excursions.Contracts.Requests;
using JDPodrozeAPI.Controllers.Excursions.Validators;
using JDPodrozeAPI.Controllers.Excursions.Validators.Enroll;
using JDPodrozeAPI.Controllers.Newsletter.Contracts.Requests;
using JDPodrozeAPI.Controllers.Newsletter.Validators;
using JDPodrozeAPI.Core.Contexts;
using JDPodrozeAPI.Core.Contexts.Excursions;
using JDPodrozeAPI.Core.Contexts.Users;
using JDPodrozeAPI.Core.Models.Configuration;
using JDPodrozeAPI.Core.Models.Configuration.ParameterStore.Credentials;
using JDPodrozeAPI.Core.Repositories;
using JDPodrozeAPI.Core.Repositories.Visits;
using JDPodrozeAPI.Core.Services.Cryptography;
using JDPodrozeAPI.Core.Services.JWT;
using JDPodrozeAPI.Core.Validation.Extensions;
using JDPodrozeAPI.Services;
using JDPodrozeAPI.Services.Account;
using JDPodrozeAPI.Services.Excursions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using SixLabors.ImageSharp;
using System.Text;

namespace JDPodrozeAPI.Core.Extensions
{
    public static class WebApplicationBuilderExtension
    {
        public static void AddConfiguration(this WebApplicationBuilder builder, string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Environment.CurrentDirectory)
                .AddJsonFile("appsettings.json", optional: true)
                .AddCommandLine(args)
                .Build();

            if (!bool.TryParse(configuration.GetSection("ParameterStore:Enabled").Value, out bool obtainConfigurationFromParameterStore) || obtainConfigurationFromParameterStore == true)
                _InitParameterStoreConfiguration(builder, configuration);
        }

        public static void ValidateConfiguration(this WebApplicationBuilder builder)
        {
            builder.Services.AddValidatorsFromAssemblyContaining<Program>(ServiceLifetime.Singleton);
            builder.Services.AddOptions<ApplicationConfiguration>()
                .Bind(builder.Configuration)
                .ValidateFluently()
                .ValidateOnStart();
        }

        public static void AddDatabaseContexts(this WebApplicationBuilder builder)
        {
            builder.Services.AddDatabaseContext<UsersDbContext>();
            builder.Services.AddDatabaseContext<ExcursionsDbContext>();
            builder.Services.AddDatabaseContext<NewsletterDbContext>();
            builder.Services.AddDatabaseContext<ContactDbContext>();
            builder.Services.AddDatabaseContext<VisitsDbContext>();
        }

        public static void InitServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddCors(options => {
                options.AddDefaultPolicy(policy =>
                {
                    if (builder.Environment.IsDevelopment())
                    {
                        policy.AllowAnyHeader();
                        policy.AllowAnyOrigin();
                        policy.AllowAnyMethod();
                    }
                    else
                    {
                        policy.WithOrigins("https://jdpodroze.pl")
                            .AllowAnyHeader()
                            .AllowAnyMethod();
                    }
                    policy.Build();
                });
            });

            builder.Services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x => x.TokenValidationParameters = new TokenValidationParameters
            {
                ValidIssuer = builder.Configuration["Authentication:Issuer"],
                ValidAudience = builder.Configuration["Authentication:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Authentication:SigningKey"])),
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true
            });

            builder.Services.AddAuthorization();
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            builder.Services.AddHttpContextAccessor();
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options =>
            {
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please enter JWT Token",
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    Scheme = "Bearer"
                });
                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        Array.Empty<string>()
                    }
                });
            });
        }

        public static void AddServicesToDI(this WebApplicationBuilder builder)
        {
            builder.Services.AddSingleton<IJWTService, JWTService>();
            builder.Services.AddSingleton<ICryptographyService, CryptographyService>();
            builder.Services.AddScoped<IUsersRepository, UsersRepository>();
            builder.Services.AddScoped<INewsletterRepository, NewsletterRepository>();
            builder.Services.AddScoped<IVisitsRepository, VisitsRepository>();
            builder.Services.AddScoped<IContactRepository, ContactRepository>();
            builder.Services.AddScoped<IOrdersRepository, OrdersRepository>();
            builder.Services.AddScoped<IAccountService, AccountService>();
            builder.Services.AddScoped<IExcursionsService, ExcursionsService>();
            builder.Services.AddScoped<IOrdersService, OrdersService>();
            builder.Services.AddScoped<IEmailsService, EmailsService>();
            builder.Services.AddScoped<INewsletterService, NewsletterService>();
            builder.Services.AddScoped<IContactService, ContactService>();
            builder.Services.AddScoped<IImagesService, ImagesService>();
            builder.Services.AddScoped<IVisitsService, VisitsService>();
            builder.Services.AddScoped<IUsersService, UsersService>();
        }

        public static void AddValidators(this WebApplicationBuilder builder)
        {
            builder.Services.AddTransient<IValidator<AccountLoginReq>, AccountLoginReqValidator>();
            builder.Services.AddTransient<IValidator<AccountRegisterReq>, AccountRegisterReqValidator>();
            builder.Services.AddTransient<IValidator<ExcursionsEnrollReq>, ExcursionsEnrollReqValidator>();
            builder.Services.AddTransient<IValidator<NewsletterEnrollReq>, NewsletterEnrollReqValidator>();
            builder.Services.AddTransient<IValidator<ContactReq>, ContactReqValidator>();
            builder.Services.AddTransient<IValidator<ExcursionsGetListReq>, ExcursionsGetListReqValidator>();
        }

        private static void _InitParameterStoreConfiguration(WebApplicationBuilder builder, IConfigurationRoot configuration)
        {
            ApplicationConfigurationParameterStoreCredentials credentials = new();
            configuration.GetSection("ParameterStore:Credentials").Bind(credentials);

            if (credentials.AccessKey != null && credentials.SecretKey != null)
            {
                string environment = builder.Environment.EnvironmentName.ToLower();
                BasicAWSCredentials credentialsAWS = new BasicAWSCredentials(credentials.AccessKey, credentials.SecretKey);

                builder.Configuration.AddSystemsManager($"/JDPodrozeAPI/{environment}",
                    new AWSOptions
                    {
                        Region = RegionEndpoint.EUCentral1,
                        Credentials = credentialsAWS
                    },
                    false,
                    TimeSpan.FromMinutes(1)
                );
            }
        }
    }
}