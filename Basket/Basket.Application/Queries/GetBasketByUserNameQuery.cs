using Basket.Application.Responses;
using MediatR;

namespace Basket.Application.Queries;

public class GetBasketByUserNameQuery : IRequest<ShopingCartResponse>
{
    public string UserName { get; set; }

    public GetBasketByUserNameQuery(string userName)
    {
        UserName = userName;
    }
}