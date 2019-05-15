using MediatR;

namespace AspnetRun.Api.Requests
{
    public class DeleteProductByIdRequest : IRequest
    {
        public int Id { get; set; }
    }
}
