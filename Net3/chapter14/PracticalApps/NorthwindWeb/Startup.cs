using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;

namespace Packt.Shared
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            string databasePath = Path.Combine("C:\\coderepos\\learnCSharp\\chapter14\\PracticalApps", "Northwind.db");

            services.AddRouting();
            services.AddRazorPages();
            services.AddDbContext<Northwind>(options => options.UseSqlite($"Data Source={databasePath}"));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else { 
                app.UseHsts();
            }

            app.UseRouting();

            app.UseHttpsRedirection();

            app.UseDefaultFiles();
            app.UseStaticFiles();



            app.UseEndpoints(endpoints =>
            {
               /* endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello world");
                });*/
               endpoints.MapRazorPages();
            });
        }
    }
}
