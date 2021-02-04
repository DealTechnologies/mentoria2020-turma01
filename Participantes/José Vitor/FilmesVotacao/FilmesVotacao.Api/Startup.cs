using System;
using System.Text;
using System.Threading.Tasks;
using ElmahCore;
using ElmahCore.Mvc;
using ElmahCore.Sql;
using FilmesVotacao.Domain.Handlers;
using FilmesVotacao.Domain.Interfaces.Repositories;
using FilmesVotacao.Infra;
using FilmesVotacao.Infra.DataContexts;
using FilmesVotacao.Infra.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace FilmesVotacao.Api
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        //Esse método serve para adicionar serviços ao projeto
        public void ConfigureServices(IServiceCollection services)
        {
            #region [+] AppSettings
            //scoped ------->  Abre, usa e fecha//
            services.Configure<SettingsInfra>(options => Configuration.GetSection("SettingsInfra").Bind(options));
            #endregion
            #region [+] DataContexts
            //scoped ------->  Abre, usa e fecha
            services.AddScoped<DataContext>();
            #endregion
            #region [+] Swagger
            services.AddSwaggerGen(c => {
                c.DescribeAllParametersInCamelCase();

                c.IncludeXmlComments($@"{AppDomain.CurrentDomain.BaseDirectory}\Swagger.xml");
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Votação de filmes API",
                    Description = "API que será utilizada para que o usuário vote no seu filme favorito",
                    TermsOfService = new Uri("https://example.com/terms"),
                    Contact = new OpenApiContact
                    {
                        Name = "Shayne Boyer",
                        Email = string.Empty,
                        Url = new Uri("https://twitter.com/spboyer"),
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Use under LICX",
                        Url = new Uri("https://example.com/license"),
                    }
                });
            });
            #endregion
            #region [+] Repositories
            // abre, usa, mas só fecha quando a requisição toda for concluída
            services.AddTransient<IUsuarioRepository, UsuarioRepository>();
            services.AddTransient<IFilmeRepository, FilmeRepository>();
            services.AddTransient<IVotoRepository, VotoRepository>();
            #endregion
            #region [+] Handlers
            services.AddTransient<UsuarioHandler, UsuarioHandler>();
            services.AddTransient<FilmeHandler, FilmeHandler>();
            services.AddTransient<VotoHandler, VotoHandler>();
            #endregion
            #region [+] ElmahCore
            //services.AddElmah<XmlFileErrorLog>(options =>
            //{
            //    options.LogPath = $@"{ AppDomain.CurrentDomain.BaseDirectory}\Erros"; 
            //});
            services.AddElmah<SqlErrorLog>(options =>
            {
                options.Path = "elmah";
                options.ConnectionString = "Integrated Security=SSPI;Persist Security Info = False; Initial Catalog=FilmesVotacao; Data Source=DEALNOTE0001\\SQLEXPRESS;";
            });
            #endregion
            #region [+] JWT
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = "José",
                    ValidAudience = "José",
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["SecurityKey"]))
                };

                options.Events = new JwtBearerEvents
                {
                    OnAuthenticationFailed = context =>
                    {
                        Console.WriteLine("Token inválido..." + context.Exception.Message);
                        return Task.CompletedTask;
                    },
                    OnTokenValidated = context =>
                    {
                        Console.WriteLine("Token válido...:" + context.SecurityToken);
                        return Task.CompletedTask;
                    }
                };
            });
            #endregion
            services.AddControllers();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        //esse método serve para configurar o fluxo de trabalho das requisições
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Votação de filmes API");
            });

            app.UseElmah();

            app.UseAuthentication();

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
