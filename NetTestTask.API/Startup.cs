using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NetTestTask.API.Services;
using NetTestTask.API.Services.TaskService;
using NetTestTask.DAL.DataBase;
using NetTestTask.DAL.Repositories;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using System.Reflection;
using System.IO;

namespace NetTestTask.API
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
            services.AddDbContext<NetTestTaskDatabase>(options=>options.UseNpgsql(Configuration.GetConnectionString("connect")));
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ITaskRepository, TaskRepository>();
            services.AddScoped<ITaskService, TaskService>();
            services.AddScoped<IUserService, UserService>();
            ConfiguratesSwagger(services);
           

        }

        private void ConfiguratesSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(c=> {
                c.SwaggerDoc("test_version", new OpenApiInfo { Title = "NetTestTaskAPI", Version = "v1" });
                //c.ResolveConflictingActions(apiDescriptions=>apiDescriptions.First());
                //var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                //var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                //c.IncludeXmlComments(xmlPath, includeControllerXmlComments: true);
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            
            app.UseSwagger(c =>
            {
                c.SerializeAsV2 = true;
            });
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "NetTestTaskAPI");
                //c.RoutePrefix = "";
            });
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                //app.UseSwagger(c=> {
                //    c.SerializeAsV2 = true;
                //});
                //app.UseSwaggerUI(c =>
                //{
                //    c.SwaggerEndpoint("swagger/v1/swagger.json", "NetTestTaskAPI");
                //    c.RoutePrefix = "";
                //});
            }
            //app.UseCors(x => x
            //.AllowAnyOrigin()
            //.AllowAnyMethod()
            //.AllowAnyHeader());


            app.UseHttpsRedirection();
            //app.UseAuthentication();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseStatusCodePages();
           // app.UseMvc();

        }
    }
}
