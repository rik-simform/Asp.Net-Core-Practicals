using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Practical_17.Configration;
using Practical_17.Contracts;
using Practical_17.Model;
using Practical_17.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practical_17
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

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Practical_17", Version = "v1" });
            });
            
            services.AddDbContext<AppContext>(context=>
            context.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            // services.AddDatabaseDeveloperPageExceptionFilter();
            //services.AddHealthChecks();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepositories<>));
            services.AddScoped(typeof(IStudentRepositories), typeof(StudentRepositories));
            services.AddMvc();

            services.AddAutoMapper(typeof(MapperConfig));
            // services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
               // app.UseMigrationsEndPoint();
                //app.UseDeveloperExceptionPage();
                 app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Practical_17 v1"));
            }
            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                //endpoints.MapControllerRoute(
                //    name: "default",
                //    pattern: "{controller=Home}/{action=Index}/{id?}");
               // endpoints.MapRazorPages();
            });
        }
    }
}
