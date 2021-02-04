
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
using System.Threading.Tasks;
using Voto.Domain.Handlers;
using Voto.Domain.Interfaces.Handlers;
using Voto.Domain.Interfaces.Repositories;
using Voto.Infra;
using Voto.Infra.DataContexts;
using Voto.Infra.Repositories;



namespace ContadorVotos.Api
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
            #region [+] ConexãoBancoDados

            services.Configure<SettingsInfra>(resp => Configuration.GetSection("SettingsInfra").Bind(resp));

            #endregion

            #region [+] Repositories

            services.AddTransient<IFilmeRepository, FilmeRepository>();
            services.AddTransient<IUsuarioRepository, UsuarioRepository>();
            services.AddTransient<IVotoRepository, VotoRepository>();

            #endregion

            #region [+] DataContext

            services.AddScoped<DataContext>();

            #endregion

            #region [+] Authentication

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = "Novakosk",
                    ValidAudience = "Novakosk",
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["SecurityKey"]))
                };

                options.Events = new JwtBearerEvents
                {
                    OnAuthenticationFailed = context =>
                    {
                        Console.WriteLine("token Invalido..." + context.Exception.Message);
                        return Task.CompletedTask;
                    },
                    OnTokenValidated = context =>
                    {
                        Console.WriteLine("token Invalido..." + context.SecurityToken);
                        return Task.CompletedTask;
                    }
                };
            });

            #endregion

            #region [+] Elmah

            //services.AddElmah<MemoryErrorLog>(x =>
            //{

            //    x.Path = @"elmah";

            //});

            // services.AddElmah<XmlFileErrorLog>(o =>
            //{
            //    o.Path = @"elmah";
            //    o.LogPath = @"C:\Users\jego.novakosk\Documents\Csharp\exercicio\DESAFIO\log";
            //});

            services.AddElmah<SqlErrorLog>(o =>
            {
                o.Path = @"elmah";
                o.ConnectionString = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=Votacao;Data Source=DEALNOTE0101;";

            });

            #endregion

            #region [+] Handles

            services.AddTransient<IFilmeHandler, FilmeHandler>();
            services.AddTransient<IUsuarioHandler, UsuarioHandler>();
            services.AddTransient<IVotosHandler, VotosHandler>();

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
                    Description = "Projeto responsável por gerenciar sistema de Votação",
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
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Votação API");
            });


            app.UseAuthentication();

            app.UseElmah();

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
