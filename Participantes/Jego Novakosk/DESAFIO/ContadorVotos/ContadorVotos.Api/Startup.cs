using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using Voto.Domain.Interfaces.Repositories;
using Voto.Infra;
using Voto.Infra.DataContexts;
using Voto.Infra.Repositories;

namespace ContadorVotos.Api
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
            #region [+] ConexãoBancoDados

            services.Configure<SettingsInfra>(resp => Configuration.GetSection("SettingsInfra").Bind(resp));

            #endregion

            #region [+] Repositories

            services.AddTransient<IFilmeRepository, FilmeRepository>();

            #endregion
            #region [+] DataContext

            services.AddScoped<DataContext>();

            #endregion

            #region [+] Swagger

            services.AddSwaggerGen(c =>
            {
                //c.DescribeAllEnumsAsStrings();
                c.DescribeAllParametersInCamelCase();
                c.IncludeXmlComments($@"{AppDomain.CurrentDomain.BaseDirectory}\Swagger.xml");
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Votação API",
                    Description = "Projeto responsável por gerenciar sistema de Votação",
                    Contact = new OpenApiContact
                    {
                        Name = "Jego Novakosk",
                        Email = "jnovakosk@gmail.com",
                        Url = new Uri("https://github.com/JegoANovakosk/CSharp")
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Licença MIT",
                        Url = new Uri("https://github.com/JegoANovakosk/CSharp")
                    }
                });
            });
            #endregion

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Votação API");
            });

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
