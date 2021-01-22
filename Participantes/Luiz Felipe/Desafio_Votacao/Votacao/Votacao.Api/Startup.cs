using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Votacao.Infra;
using Votacao.Infra.DataContext;

namespace Votacao.Api
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
            services.Configure<SettingsInfra>(options => Configuration.GetSection("SettingsInfra").Bind(options));
            #endregion

            #region [+] DataContexts
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
                    Title = "Vota��o API",
                    Description = "Projeto de vota��o de filmes",
                    Contact = new OpenApiContact
                    {
                        Name = "Luiz Felipe",
                        Email = "luizfelipems12@gmail.com",
                        Url = new Uri("https://github.com/")
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Licen�a MIT",
                        Url = new Uri("https://github.com/")
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
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Vota��o API");
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
