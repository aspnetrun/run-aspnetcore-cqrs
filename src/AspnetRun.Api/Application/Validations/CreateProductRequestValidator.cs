using AspnetRun.Api.Requests;
using FluentValidation;

namespace AspnetRun.Api.Application.Validations
{
    public class CreateProductRequestValidator : AbstractValidator<CreateProductRequest>
    {
        public CreateProductRequestValidator()
        {
            RuleFor(request => request.Product).NotNull();
        }
    }
}
