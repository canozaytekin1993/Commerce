using Commerce.Contracts.Factories;
using Commerce.Contracts.Handlers;
using Commerce.Contracts.Repository;
using Commerce.Contracts.Validators;
using Commerce.Data.Contexts;
using Commerce.Domain.Entities.Catalog;
using Commerce.Domain.Identity;
using Commerce.Logics.Factories;
using Commerce.Logics.Handlers;
using Commerce.Logics.Managers;
using Commerce.Logics.Validators;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Commerce.Web.Client
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
            });

            services.AddControllersWithViews()
                .AddNewtonsoftJson();
            services.AddRazorPages();
            services.AddDbContext<CommerceDbContext>();
            services.AddIdentity<Person, Role>().AddEntityFrameworkStores<CommerceDbContext>();
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
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseCookiePolicy();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    "default",
                    "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}