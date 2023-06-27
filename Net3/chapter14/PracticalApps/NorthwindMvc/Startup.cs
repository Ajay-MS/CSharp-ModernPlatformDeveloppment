
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NorthwindMvc.Data;
using System.Net.Http.Headers;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace Packt.Shared
{
    public class Startup
    {

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {

            string databasePath = Path.Combine("C:\\coderepos\\learnCSharp\\chapter14\\PracticalApps", "Northwind.db");

            services.AddDbContext<Northwind>(options =>
              options.UseSqlite($"Data Source={databasePath}"));

            services.AddDbContext<ApplicationDbContext>(options =>
              options.UseSqlite(
                Configuration.GetConnectionString("DefaultConnection")));

            services.AddDefaultIdentity<IdentityUser>(
              options => options.SignIn.RequireConfirmedAccount = true)
              .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddControllersWithViews();
            services.AddRazorPages();

            services.AddHttpClient(name: "NorthwindService",
              configureClient: options =>
              {
                  options.BaseAddress = new Uri("https://localhost:5001/");

                  options.DefaultRequestHeaders.Accept.Add(
              new MediaTypeWithQualityHeaderValue("application/json", 1.0));
              });

        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}"
                    );

                endpoints.MapRazorPages(); 
            });
        }

    }
}
