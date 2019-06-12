using System;
using System.Net;
using System.Text;
using Commerce.Business.Api.Extensions;
using Commerce.Contracts.Factories;
using Commerce.Contracts.Handlers;
using Commerce.Contracts.Repository;
using Commerce.Contracts.Validators;
using Commerce.Data.Contexts;
using Commerce.Domain.Configurations.Auth;
using Commerce.Domain.Entities.Catalog;
using Commerce.Domain.Identity;
using Commerce.Extensions.Constants;
using Commerce.Logics.Factories;
using Commerce.Logics.Handlers;
using Commerce.Logics.Managers;
using Commerce.Logics.Validators;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;

namespace Commerce.Business.Api
{
    public class Startup
    {
        private const string SecretKey = "SecretKey123123456456";
        private readonly SymmetricSecurityKey _sigKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(SecretKey));

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddNewtonsoftJson();

            services.AddMvc();

            services.AddDbContext<CommerceDbContext>();
            services.AddIdentity<Person, Role>(p =>
            {
                p.Password.RequireDigit = false;
                p.Password.RequireLowercase = false;
                p.Password.RequireUppercase = false;
                p.Password.RequireNonAlphanumeric = false;
                p.Password.RequiredLength = 4;
            }).AddEntityFrameworkStores<CommerceDbContext>().AddDefaultTokenProviders();
            services.AddSingleton<ITokenFactory, TokenFactory>();
            services.TryAddTransient<IHttpContextAccessor, HttpContextAccessor>();
            var jwtIssuerOptions = new JwtIssuerOptions
            {
                Issuer = "WebApi",
                Audience = "localhost:5000/",
                SigningCredentials = new SigningCredentials(_sigKey, SecurityAlgorithms.HmacSha256)
            };
            var tokenValidationParameter = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidIssuer = jwtIssuerOptions.Issuer,
                ValidateAudience = true,
                ValidAudience = jwtIssuerOptions.Audience,

                ValidateIssuerSigningKey = true,
                IssuerSigningKey = _sigKey,

                RequireExpirationTime = false,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero
            };
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(configOption =>
            {
                configOption.ClaimsIssuer = jwtIssuerOptions.Issuer;
                configOption.TokenValidationParameters = tokenValidationParameter;
                configOption.SaveToken = true;
            });
            services.AddAuthorization(options =>
            {
                options.AddPolicy("ApiUser",
                    policy => policy.RequireClaim(ClaimIdentifiers.Role, JwtClaims.ApiAccess));
            });
            services.AddTransient<ILogger, Logger>();
            services.AddTransient<IValidator<Product>, ProductValidator>();
            services.AddTransient<IExceptionHandler, ExceptionHandler>();
            services.AddTransient<IEntityFactory<Product>, ProductFactory>();
            services.AddTransient<IProductRepository, ProductManager>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();
            else
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();

            app.UseExceptionHandler(builder =>
            {
                builder.Run(async context =>
                {
                    context.Response.StatusCode = (int) HttpStatusCode.InternalServerError;
                    context.Response.Headers.Add("access-control-Allow-Origin", "*");
                    var error = context.Features.Get<IExceptionHandlerFeature>();
                    if (error != null)
                    {
                        context.Response.AddApplicationError(error.Error.Message);
                        await context.Response.WriteAsync(error.Error.Message).ConfigureAwait(false);
                    }
                });
            });

            app.UseAuthentication();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseStaticFiles();

            app.UseCors("AllowOrigin");

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}