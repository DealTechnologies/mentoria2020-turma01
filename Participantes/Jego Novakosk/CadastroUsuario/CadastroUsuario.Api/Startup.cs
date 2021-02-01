using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using Usuario.Domain.Handlers;
using Usuario.Domain.Interface.Handlers;
using Usuario.Domain.Interface.Repositories;
using Usuario.Infra;
using Usuario.Infra.DataContexts;
using Usuario.Infra.Repositories;

namespace CadastroUsuario.Api
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
            #region {+} AppSettings

                services.Configure<SettingsInfra>(o => Configuration.GetSection("SettingsInfra").Bind(o));

            #endregion

            #region {+} DataContexts

                 services.AddScoped<DataContext>();

            #endregion

            #region {+} Handlers

            services.AddTransient<IUsuarioHandler, UsuarioHandler>();

            #endregion

            #region {+} Repositories

            services.AddTransient<IUsuarioRepository, UsuarioRepository>();
               
            #endregion

            #region {+} SWAGGWER

            services.AddSwaggerGen(x =>
            {
                x.DescribeAllParametersInCamelCase();
                x.IncludeXmlComments($@"{AppDomain.CurrentDomain.BaseDirectory}\Swagger.xml");
                x.SwaggerDoc("V1", new OpenApiInfo 
                { 
                
                    Version= "v1",
                    Title = "Cadastro de Usuario",
                    Description ="Projeto para casdastro de usuario",
                    Contact = new OpenApiContact
                    {
                        Name = "Jego Novakosk",
                        Email = "jnovakosk@gmail.com",
                        Url = new Uri("https://github.com/JegoANovakosk/CSharp")
                    },
                    License = new OpenApiLicense
                    {
                        Name ="4564564",
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
            app.UseSwaggerUI(x =>
            {
                x.SwaggerEndpoint("/swagger/V1/swagger.json", "Usuario Api");
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
