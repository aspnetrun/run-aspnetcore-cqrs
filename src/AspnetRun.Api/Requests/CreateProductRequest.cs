using AspnetRun.Application.Models;
using MediatR;

namespace AspnetRun.Api.Requests
{
    public class CreateProductRequest : IRequest<ProductModel>
    {
        public ProductModel Product { get; set; }
    }
}
