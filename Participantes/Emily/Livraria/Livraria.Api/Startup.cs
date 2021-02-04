using ElmahCore.Mvc;
using ElmahCore.Sql;
using Livraria.Domain.Handlers;
using Livraria.Domain.Interfaces.Handlers;
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
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            #region [+] AppSettings 

            services.Configure<SettingsInfra>(options => Configuration.GetSection("SettingsInfra").Bind(options));

            #endregion

            #region Controller [+]
            services.AddControllers();
            #endregion

            #region [+] DataContexts 

            services.AddScoped<DataContext>();

            #endregion

            #region [+] Repositories 

            services.AddTransient<ILivroRepository, LivroRepository>();

            #endregion

            #region [+] Handlers 

            services.AddTransient<ILivroHandler, LivroHandler>();

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
                        Name = "Emily Lira",
                        Email = "emily_saraiva@hotmail.com.br",
                        Url = new Uri("https://github.com/emily-saraiva")
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Licença MIT",
                        Url = new Uri("https://github.com/emily-saraiva")
                    }
                });
            });

            #endregion

            #region Elmah [+]
            services.AddElmah<SqlErrorLog>(options =>
            {
                options.ConnectionString = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=Livraria;Data Source=DEALNOTE0104\\SQLEXPRESS;";
            });
            #endregion

            


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

            app.UseElmah();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseAuthorization();
            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
