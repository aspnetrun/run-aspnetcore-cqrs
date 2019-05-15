using AspnetRun.Application.Models;
using MediatR;

namespace AspnetRun.Api.Requests
{
    public class UpdateProductRequest : IRequest
    {
        public ProductModel Product { get; set; }
    }
}
