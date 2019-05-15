using AspnetRun.Infrastructure.Misc;
using Autofac;

namespace AspnetRun.Infrastructure.IoC
{
    public interface IDependencyRegistrar
    {
        void Register(ContainerBuilder builder, ITypeFinder typeFinder);

        int Order { get; }
    }
}
