using System.Threading;
using System.Threading.Tasks;
using AspnetRun.Api.Requests;
using AspnetRun.Application.Interfaces;
using MediatR;

namespace AspnetRun.Api.Application.Commands
{
    public class DeleteProductByIdCommandHandler : IRequestHandler<DeleteProductByIdRequest>
    {
        private readonly IProductService _productService;

        public DeleteProductByIdCommandHandler(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<Unit> Handle(DeleteProductByIdRequest request, CancellationToken cancellationToken)
        {
            await _productService.DeleteProductById(request.Id);

            return Unit.Value;
        }
    }
}
