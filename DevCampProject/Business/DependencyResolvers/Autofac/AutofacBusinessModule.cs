using Autofac;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using Autofac.Extras.DynamicProxy;
using DataAccess.Concrete.EntityFramework;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule:Module
    {
        // Uygulama ayaga kalktığında services.addSingleton'a karşılık geliyor
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ProductManager>().As<IProductService>().SingleInstance();
            builder.RegisterType<EFProductDal>().As<IProductDal>().SingleInstance();

            builder.RegisterType<CategoryManager>().As<ICategoryService>().SingleInstance();
            builder.RegisterType<EFCategoryDal>().As<ICategoryDal>().SingleInstance();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();
            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces() // implemente edilmiş interfaceleri bul yazılmış aspect yazılmışmı bak 
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}
