using AspnetRun.Api.Requests;
using FluentValidation;

namespace AspnetRun.Api.Application.Validations
{
    public class DeleteProductRequestValidator : AbstractValidator<DeleteProductByIdRequest>
    {
        public DeleteProductRequestValidator()
        {
            RuleFor(request => request.Id).GreaterThan(0);
        }
    }
}
