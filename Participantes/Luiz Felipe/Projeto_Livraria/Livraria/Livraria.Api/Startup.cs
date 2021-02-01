using AutoMapper;
using Livraria.Domain;
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
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            #region [+] AppSettings
            services.Configure<SettingsInfra>(options =>
            {
                options.ConnectionString
                    = Configuration.GetSection("MongoConnection:ConnectionString").Value;
                options.DataBaseName
                    = Configuration.GetSection("MongoConnection:DataBaseName").Value;
            });
            #endregion

            #region [+] DataContexts

            services.AddScoped<DataContext>();

            #endregion

            #region [+] Handlers

            services.AddTransient<LivroHandler>();

            #endregion

            #region [+] Repositories

            services.AddTransient<ILivroRepository, LivroRepository>();

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
                    Title = "Livraria Api",
                    Description = "Projeto Responsável por gerenciar uma livraria",
                    Contact = new OpenApiContact
                    {
                        Name = "Felipe",
                        Email = "luizfelipems12@gmail.com",
                        Url = new Uri("https://github.com/DealTechnologies/mentoria2020-turma01/tree/master/Participantes/Luiz%20Felipe")
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Licença MIT",
                        Url = new Uri("https://github.com/DealTechnologies/mentoria2020-turma01/tree/master/Participantes/Luiz%20Felipe")
                    }
                });
            });

            #endregion

            #region [+] AutoMapper
            IMapper mapper = AutoMapperConfig.RegisterMappings();
            services.AddSingleton(mapper);
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
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Livraria Api");
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
