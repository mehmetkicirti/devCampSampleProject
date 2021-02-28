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
            // Autofac, Ninject, CastleWindsor => aþaðýdaki iþlemleri 3party paket ile bu IoC container yapýsýný yapar.
            // AOP => bir metod önünde hata alanýnda veya sonunda çalýþan bir mimari 
            // AOP => yapacaðýmýz için örnegin tüm metodlarý loglayacaðýz veya auth controlü veya cacheden veri getireceðimiz için 
            // IProduct Service isterse bu tipte bana bunun karþýlýðýný ProductManager referansýný oluþtur uygulama boyunca ayný instance veriliyor => singleton => data tutmuyorsak yap
            services.AddSingleton<IProductService, ProductManager>(); // bizim yerimize ProductControllerda referansýný oluþturucak
            // Some services are not able to be constructed => tam newlerken onunda baþka bir þeye newlendiðini gördük burada IProductDal => da EfProductDal referansýný oluþtur dememiz lazým
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
