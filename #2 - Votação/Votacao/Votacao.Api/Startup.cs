using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using Votacao.Domain.Handlers;
using Votacao.Domain.Interfaces.Handlers;
using Votacao.Domain.Interfaces.Repositories;
using Votacao.Infra.Data;
using Votacao.Infra.Data.DataContexts;
using Votacao.Infra.Data.Repositories;

namespace Votacao.Api
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
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
                    Description = "Projeto responsável por gerenciar uma votação de melhor filme",
                    Contact = new OpenApiContact
                    {
                        Name = "Lucas Santos",
                        Email = "l_santos@hotmail.com.br",
                        Url = new Uri("https://github.com/lsantoss"),
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Licença MIT",
                        Url = new Uri("https://github.com/lsantoss/Treinamentos/blob/main/LICENSE"),
                    }
                });
            });

            #endregion

            #region [+] AppSettings

            services.Configure<SettingsInfra>(options => Configuration.GetSection("SettingsInfra").Bind(options));

            #endregion

            #region [+] DataContexts

            services.AddScoped<DataContext>();

            #endregion

            #region [+] Handlers

            services.AddTransient<IUsuarioHandler, UsuarioHandler>();
            services.AddTransient<IFilmeHandler, FilmeHandler>();
            services.AddTransient<IVotoHandler, VotoHandler>();

            #endregion

            #region [+] Repositories

            services.AddTransient<IUsuarioRepository, UsuarioRepository>();
            services.AddTransient<IFilmeRepository, FilmeRepository>();
            services.AddTransient<IVotoRepository, VotoRepository>();

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
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "VotacaoAPI");
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