using System.Threading;
using System.Threading.Tasks;
using AspnetRun.Api.Requests;
using AspnetRun.Application.Interfaces;
using AspnetRun.Application.Models;
using MediatR;

namespace AspnetRun.Api.Application.Commands
{
    public class CreateProductCommandHandler
        : IRequestHandler<CreateProductRequest, ProductModel>
    {
        private readonly IProductService _productService;

        public CreateProductCommandHandler(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<ProductModel> Handle(CreateProductRequest request, CancellationToken cancellationToken)
        {
            var productModel = await _productService.CreateProduct(request.Product);

            return productModel;
        }
    }
}
