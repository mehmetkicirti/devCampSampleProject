using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace WebAPI
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
            services.AddControllers();
            // Autofac, Ninject, CastleWindsor => a�a��daki i�lemleri 3party paket ile bu IoC container yap�s�n� yapar.
            // AOP => bir metod �n�nde hata alan�nda veya sonunda �al��an bir mimari 
            // AOP => yapaca��m�z i�in �rnegin t�m metodlar� loglayaca��z veya auth control� veya cacheden veri getirece�imiz i�in 
            // IProduct Service isterse bu tipte bana bunun kar��l���n� ProductManager referans�n� olu�tur uygulama boyunca ayn� instance veriliyor => singleton => data tutmuyorsak yap
            services.AddSingleton<IProductService, ProductManager>(); // bizim yerimize ProductControllerda referans�n� olu�turucak
            // Some services are not able to be constructed => tam newlerken onunda ba�ka bir �eye newlendi�ini g�rd�k burada IProductDal => da EfProductDal referans�n� olu�tur dememiz laz�m
            services.AddSingleton<IProductDal, EFProductDal>();
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

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
