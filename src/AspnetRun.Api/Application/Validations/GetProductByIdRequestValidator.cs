using AspnetRun.Api.Requests;
using FluentValidation;

namespace AspnetRun.Api.Application.Validations
{
    public class GetProductByIdRequestValidator : AbstractValidator<GetProductByIdRequest>
    {
        public GetProductByIdRequestValidator()
        {
            RuleFor(request => request.Id).GreaterThan(0);
        }
    }
}
