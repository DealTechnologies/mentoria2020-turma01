using Livraria.Domain.Handlers;
using Livraria.Domain.Interfaces.Repositories;
using Livraria.Infra;
using Livraria.Infra.DataContexts;
using Livraria.Infra.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;

namespace Livraria.Api
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

            

            #region [+] AppSettings

            services.Configure<SettingsInfra>(options => Configuration.GetSection("SettingsInfra")
            .Bind(options));

            #endregion

            #region [+] DataContexts

             services.AddScoped<DataContext>();

            #endregion

            #region [+] Repositories

            services.AddTransient<ILivroRepository, LivroRepository>();

            #endregion

            #region [+] Handlers

            services.AddTransient<LivroHandler, LivroHandler>();

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
                    Title = "Livraria API",
                    Description = "Projeto responsável por gerenciar uma livraria",
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
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Livraria API");
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
