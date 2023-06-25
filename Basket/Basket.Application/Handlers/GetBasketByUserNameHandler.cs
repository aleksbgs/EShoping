using Basket.Application.Mappers;
using Basket.Application.Queries;
using Basket.Application.Responses;
using Basket.Core.Repositories;
using MediatR;

namespace Basket.Application.Handlers;

public class GetBasketByUserNameHandler: IRequestHandler<GetBasketByUserNameQuery,ShopingCartResponse>
{
    private readonly IBasketRepository _basketRepository;


    public GetBasketByUserNameHandler(IBasketRepository basketRepository)
    {
        _basketRepository = basketRepository;
    }
    
    
    public async Task<ShopingCartResponse> Handle(GetBasketByUserNameQuery request, CancellationToken cancellationToken)
    {
        var shoppingCart = await _basketRepository.GetBasket(request.UserName);

        var shoppingCartResponse = BasketMapper.Mapper.Map<ShopingCartResponse>(shoppingCart);

        return shoppingCartResponse;
    }
}