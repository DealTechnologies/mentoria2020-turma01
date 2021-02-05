using Locadora.Domain;
using Locadora.Domain.Autenticacao;
using Locadora.Domain.Interfaces;
using Locadora.Infra;
using Locadora.Infra.DataContexts;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Text;

namespace Locadora.Api
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
            services.Configure<SettingsDomain>(options => Configuration.GetSection("SettingsDomain").Bind(options));
            #endregion

            #region [+] DataContexts
            services.AddScoped<DataContext>();
            #endregion

            #region [+] Handlers

            #endregion

            #region [+] Repositories

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
                    Description = "Projeto de Locação de Equipamentos",
                    Contact = new OpenApiContact
                    {
                        Name = "Equipe ",
                        Email = "",
                        Url = new Uri("https://github.com/")
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Licença MIT",
                        Url = new Uri("https://github.com/")
                    }
                });
            });
            #endregion

            #region [+] AutenticacaoJWT
            var key = Encoding.ASCII.GetBytes(Configuration.GetValue<string>("SettingsDomain:SecretKey"));
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            services.AddTransient<TokenService>();
            #endregion

            #region [+] UnitOfWork
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            #endregion

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

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
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Locadora API");
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
