using Basket.Application.Commands;
using Basket.Application.Mappers;
using Basket.Application.Responses;
using Basket.Core.Entites;
using Basket.Core.Repositories;
using MediatR;

namespace Basket.Application.Handlers;

public class CreateShoppingCartCommandHandler:IRequestHandler<CreateShoppingCartCommand,ShopingCartResponse>
{
    private readonly IBasketRepository _basketRepository;


    public CreateShoppingCartCommandHandler(IBasketRepository basketRepository)
    {
        _basketRepository = basketRepository;
    }

    public async Task<ShopingCartResponse> Handle(CreateShoppingCartCommand request,
        CancellationToken cancellationToken)
    {
        //TODO: Call Discount service and apply coupons

        var shoppingCart = await _basketRepository.UpdateBasket(new ShoppingCart
        {
            UserName = request.UserName,
            Items = request.Items 
        });
        var shoppingCartResponse = BasketMapper.Mapper.Map<ShopingCartResponse>(shoppingCart);
        return shoppingCartResponse;
    }
}