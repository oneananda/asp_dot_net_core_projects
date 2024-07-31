using MediatR;
using _023_MediatR_Mediator_Pattern.Models;

namespace _023_MediatR_Mediator_Pattern.Requests
{
    public class GetProductsQuery : IRequest<List<Product>>
    {

    }
}
