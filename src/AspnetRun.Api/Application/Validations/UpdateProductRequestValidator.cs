using AspnetRun.Api.Requests;
using FluentValidation;

namespace AspnetRun.Api.Application.Validations
{
    public class UpdateProductRequestValidator : AbstractValidator<UpdateProductRequest>
    {
        public UpdateProductRequestValidator()
        {
            RuleFor(request => request.Product).NotNull();
        }
    }
}
