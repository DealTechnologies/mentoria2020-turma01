using AutoMapper;
using ElmahCore;
using ElmahCore.Mvc;
using ElmahCore.Sql;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Text;
using Votacao.Domain;
using Votacao.Domain.Autenticacao;
using Votacao.Domain.Handlers;
using Votacao.Domain.Interfaces.Repositories;
using Votacao.Infra;
using Votacao.Infra.DataContexts;
using Votacao.Infra.Repositories;

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
            services.Configure<SettingsDomain>(options => Configuration.GetSection("SettingsDomain").Bind(options));
            #endregion

            #region [+] DataContexts
            services.AddScoped<DataContext>();
            #endregion

            #region [+] Handlers
            services.AddTransient<UsuarioHandler>();
            services.AddTransient<FilmeHandler>();
            services.AddTransient<VotoHandler>();
            #endregion

            #region [+] Repositories
            services.AddTransient<IFilmeRepository, FilmeRepository>();
            services.AddTransient<IUsuarioRepository, UsuarioRepository>();
            services.AddTransient<IVotoRepository, VotoRepository>();
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

            #region [+] Elmah
            //services.AddElmah<XmlFileErrorLog>(options =>
            //{
            //    options.LogPath = "~/log";
            //});

            services.AddElmah<SqlErrorLog>(options =>
            {
                options.ConnectionString = Configuration.GetValue<string>("SettingsInfra:ConnectionString");
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
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Vota��o API");
            });

            app.UseHttpsRedirection();

            app.UseElmah();

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
