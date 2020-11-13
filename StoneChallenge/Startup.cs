using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using StoneChallenge.Models.Repository;
using StoneChallenge.Models.Repository.IRepository;
using StoneChallenge.Services;
using StoneChallenge.Services.Interfaces;
using System.Collections.Generic;
using System.Globalization;

namespace StoneChallenge
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
            services.AddControllersWithViews();

            services.AddDbContext<StoneChallengeContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("StoneChallengeContext")));

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddSingleton<ICalculadoraDePesoService, CalculadoraDePesoPorAreaDeAtuacaoService>();
            services.AddSingleton<ICalculadoraDePesoService, CalculadoraDePesoPorTempoDeAdmissaoService>();
            services.AddSingleton<ICalculadoraDePesoService, CalculadoraDePesoPorFaixaSalarial>();
            services.AddSingleton<ICalculadoraDeBonusService, CalculadoraDeBonusService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();

            var defaultCulture = new CultureInfo("en-US");
            var localizationOptions = new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture(defaultCulture),
                SupportedCultures = new List<CultureInfo> { defaultCulture },
                SupportedUICultures = new List<CultureInfo> { defaultCulture }
            };
            app.UseRequestLocalization(localizationOptions);

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Funcionarios}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "api",
                    pattern: "api/{bonusDisponivel=0.0}/{controller=Funcionarios}/{action=GetBonus}"
                    );
            });
        }
    }
}
