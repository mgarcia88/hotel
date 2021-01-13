using System.Collections.Generic;
using System.Text;
using HotelApi.Data;
using HotelApi.Data.Repositorios;
using HotelApi.Data.UnitOfWork;
using HotelApi.Dominio.Repositorio;
using HotelApi.Dominio.Servicos;
using HotelApi.Infraestrutura.Identidade;
using HotelApi.Infraestrutura.Interfaces;
using HotelApi.Infraestrutura.Servicos;
using HotelApi.Servicos;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace HotelApi
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
            services.AddHttpClient();
            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                //c.SwaggerDoc("v1", new Info { Title = "You api title", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = @"Autorização JWT header utilizando o esquema Bearer. \r\n\r\n 
                      \r\n\r\nExample: 'Bearer 12345abcdef'",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header,

                        },
                        new List<string>()
                    }
                });
            });

            services.AddControllers();
            services.AddDbContext<ApplicationContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IClienteRepositorio, ClienteRepositorio>();
            services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
            services.AddScoped<IClienteServico, ClienteServico>();
            services.AddScoped<IUsuarioServico, UsuarioServico>();
            services.AddScoped<ITokenServico, TokenServico>();
            services.AddScoped<IPessoaRepositorio, PessoaRepositorio>();
            services.AddScoped<IEnderecoRepositorio, EnderecoRepositorio>();
            services.AddScoped<IEnderecoServico, EnderecoServico>();
            services.AddScoped<IPessoaServico, PessoaServico>();
            services.AddScoped<IConsultaCep, ConsultaEnderecoViaCep>();
            services.AddScoped<IEstadoRepositorio, EstadoRepositorio>();
            services.AddScoped<ICidadeRepositorio, CidadeRepostorio>();
            services.AddScoped<ICidadeServico,CidadeServico>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IUsuarioLogado, UsuarioLogado>();

            var key = Encoding.ASCII.GetBytes("fedaf7d8863b48e197b9287d492b708e");
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
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
            
        }
    }
}
