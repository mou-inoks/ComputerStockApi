using Autofac;
using ComputerStockApi.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;

namespace MediatRApi
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
            
            // Register the MediatR request handlers
           services.AddMediatR(Assembly.GetExecutingAssembly());

           services.AddAutoMapper(Assembly.GetExecutingAssembly());

           services.AddDbContext<ComputerStockContext>();

           services.AddControllers();
           services.AddSwaggerGen(c =>
           {
               c.SwaggerDoc("v1", new OpenApiInfo { Title = "Computer Stock Api", Version = "1.0" });
           });
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
           builder
               .RegisterTypes()
               .Where(t => t.IsClosedTypeOf(typeof(IRequestHandler<>)))
               .AsImplementedInterfaces();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ComputerStockAPI v1"));
                app.UseCors(options =>
                {
                    options
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowAnyOrigin();
                });
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}