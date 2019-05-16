using AspnetRun.Api.Application.Commands;
using AspnetRun.Api.Application.Validations;
using AspnetRun.Infrastructure.IoC;
using AspnetRun.Infrastructure.Misc;
using Autofac;
using FluentValidation;
using MediatR;
using System.Reflection;

namespace AspnetRun.Api.IoC
{
    public class DependencyRegistrar : IDependencyRegistrar
    {
        public void Register(ContainerBuilder builder, ITypeFinder typeFinder)
        {
            // Register all the Command classes (they implement IRequestHandler) in assembly holding the Commands
            builder.RegisterAssemblyTypes(typeof(CreateProductCommandHandler).GetTypeInfo().Assembly)
                .AsClosedTypesOf(typeof(IRequestHandler<,>));

            // Register the Command's Validators (Validators based on FluentValidation library)
            builder.RegisterAssemblyTypes(typeof(CreateProductRequestValidator).GetTypeInfo().Assembly)
                .Where(t => t.IsClosedTypeOf(typeof(IValidator<>)))
                .AsImplementedInterfaces();
        }

        public int Order => 0;
    }
}
