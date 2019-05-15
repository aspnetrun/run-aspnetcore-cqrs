using AspnetRun.Api.Requests;
using FluentValidation;

namespace AspnetRun.Api.Application.Validations
{
    public class GetProductsByCategoryIdRequestValidator : AbstractValidator<GetProductsByCategoryIdRequest>
    {
        public GetProductsByCategoryIdRequestValidator()
        {
            RuleFor(request => request.CategoryId).GreaterThan(0);
        }
    }
}
