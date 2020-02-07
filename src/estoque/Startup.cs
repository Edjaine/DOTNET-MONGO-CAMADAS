using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using estoque.INFRA.CONTEXTO;
using estoque.INFRA.REPOSITORIO;
using estoque.INFRA.UoW;
using estoque.INTERFACES;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Swagger;
namespace estoque {
    public class Startup {
        public Startup (IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices (IServiceCollection services) {
            services.AddScoped<IProdutoRepositorio, ProdutoRepositorio> ();
            services.AddScoped<IUnitOfWork, UnitOfWork> ();
            services.AddScoped<IMongoContext, MongoContext> ();
            services.AddControllers ();

            services.AddSwaggerGen (s => {
                s.SwaggerDoc ("v1", new OpenApiInfo {
                    Version = "v1",
                        Title = "MongoDB Repository Pattern and Unit of Work - Example",
                        Description = "Swagger surface"
                });
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure (IApplicationBuilder app, IWebHostEnvironment env) {
            if (env.IsDevelopment ()) {
                app.UseDeveloperExceptionPage ();
            }

            app.UseHttpsRedirection ();

            app.UseRouting ();

            app.UseAuthorization ();

            app.UseSwagger (c => {
                c.RouteTemplate = "swagger/{documentName}/swagger.json";
            });
            app.UseSwaggerUI (s => {
                s.SwaggerEndpoint ("/swagger/v1/swagger.json", "Repository Pattern and Unit of Work API v1.0");
            });

            app.UseEndpoints (endpoints => {
                endpoints.MapControllers ();
            });
        }
    }
}
