using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Rio.SMF.CCU.Ouvidoria.Dominio.Models;
using Rio.SMF.CCU.Ouvidoria.Infraestrutura.Context;
using Rio.SMF.CCU.Ouvidoria.Infraestrutura.Interfaces;
using Rio.SMF.CCU.Ouvidoria.Infraestrutura.Repository;

namespace Rio.SMF.CCU.Ouvidoria.Apresentacao
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

           
            services.AddTransient<IDenunciaRepository, DenunciaRepository>();
            services.AddTransient<IBairroRepository, BairroRepository>();
            services.AddTransient<IGeolocalizadoRepository, GeolocalizadoRepository>();
            services.AddTransient<ILogradouroRepository, LogradouroRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();


            services.AddDbContext<SGOContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));

            services.AddDbContext<UserContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("UserConnection")));

            
            var connection = Configuration["ConexaoSqlite:SqliteConnectionString"];

            var t = Directory.GetDirectoryRoot("./bin/Debug/netcoreapp2.1/locais.sqlite3");
            var str = "Data Source=." + t + "bin/Debug/netcoreapp2.1/locais.sqlite3";

            services.AddDbContext<locaisContext>(options =>
                options.UseSqlite(str));


            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options => 

                    
                    options.LoginPath = ("/")
                    
                );

            

            services.AddAuthorization(options =>
            {
                options.AddPolicy("RequireAdministratorRole", policy => policy.RequireRole("admin"));
            
            });

          

            services.AddMvc()
            .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
           
           
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseAuthentication();
            

            app.UseMvc();
        }
    }
}
