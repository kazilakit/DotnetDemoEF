#region Links
/*
 * https://code-maze.com/aspnetcore-webapi-best-practices/
 * https://www.codeproject.com/Articles/814768/CRUD-Operations-Using-the-Generic-Repository-Patte
 * https://ngohungphuc.wordpress.com/2018/05/02/unit-of-work-pattern-in-asp-net-core/
 * https://ngohungphuc.wordpress.com/2018/05/01/generic-repository-pattern-in-asp-net-core/
 * http://csharpdocs.com/generic-repository-pattern-and-unit-of-work/
 * https://codingblast.com/entity-framework-core-generic-repository/
 * https://garywoodfine.com/generic-repository-pattern-net-core/
 * https://www.c-sharpcorner.com/article/understanding-entity-framework-core-and-code-first-migrations-in-ef-core/
 * https://code-maze.com/net-core-web-api-ef-core-code-first/
 * https://www.codingame.com/playgrounds/35462/creating-web-api-in-asp-net-core-2-0/part-1---web-api
*/
#endregion


using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoCrud.Repository;
using DemoCrud.Service.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DemoCrud.API
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<StudentContext>(options =>
        options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddMvc();
            services.AddTransient<IStudentService, StudentService>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddTransient<IUnitOfWork, UnitOfWork>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseMvc();
            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello World!");
            //});
        }
    }
}
