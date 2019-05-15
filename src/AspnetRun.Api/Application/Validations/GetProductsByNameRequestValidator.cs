using AspnetRun.Api.Requests;
using FluentValidation;

namespace AspnetRun.Api.Application.Validations
{
    public class GetProductsByNameRequestValidator : AbstractValidator<GetProductsByNameRequest>
    {
        public GetProductsByNameRequestValidator()
        {
            RuleFor(request => request.Name).NotNull();
        }
    }
}
