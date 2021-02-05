using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Votacao.Api.Services;
using Votacao.Domain.Handlers;
using Votacao.Domain.Interfaces.Handlers;
using Votacao.Domain.Interfaces.Repositories;
using Votacao.Infra;
using Votacao.Infra.DataContexts;
using Votacao.Infra.Repositories;

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

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "Para autenticar use a palavra 'Bearer' + (um espaço entre a palavra Bearer e o Token) + 'Token'",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey
                });

                var scheme = new OpenApiSecurityScheme { Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "bearer" } };
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    [scheme] = new List<string>()
                });
            });

            #endregion

            #region [+] Autenticação JWT

            var keyString = Configuration.GetSection("SettingsAPI:ChaveJWT").Get<string>();
            var key = Encoding.ASCII.GetBytes(keyString);

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = true;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
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

            #region [+] Services

            services.AddTransient<TokenJWTService, TokenJWTService>();

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

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}