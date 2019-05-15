using AspnetRun.Application.Interfaces;
using AspnetRun.Application.Services;
using AspnetRun.Infrastructure.IoC;
using AspnetRun.Infrastructure.Misc;
using Autofac;

namespace AspnetRun.Application.IoC
{
    public class DependencyRegistrar : IDependencyRegistrar
    {
        public void Register(ContainerBuilder builder, ITypeFinder typeFinder)
        {
            // services
            builder.RegisterType<ProductService>().As<IProductService>().InstancePerLifetimeScope();
            builder.RegisterType<CategoryService>().As<ICategoryService>().InstancePerLifetimeScope();
        }

        public int Order => 2;
    }
}
