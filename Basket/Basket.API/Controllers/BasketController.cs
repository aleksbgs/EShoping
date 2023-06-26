using System.Net;
using Basket.Application.Commands;
using Basket.Application.Queries;
using Basket.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Basket.API.Controllers;

public class BasketController:ApiController
{
    private readonly IMediator _mediator;

    public BasketController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("[action]/{userName}", Name = "GetBasketByUserName")]
    [ProducesResponseType(typeof(ShopingCartResponse), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<ShopingCartResponse>> GetBasket(string userName)
    {
        var query = new GetBasketByUserNameQuery(userName);
        var basket = await _mediator.Send(query);
        return Ok(basket);
    }

    [HttpPost("CreateBasket")]
    [ProducesResponseType(typeof(ShopingCartResponse), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<ShopingCartResponse>> UpdateBasket(
        [FromBody] CreateShoppingCartCommand createShoppingCartCommand)
    {
        var basket = await _mediator.Send(createShoppingCartCommand);
        return Ok(basket);
    }

    [HttpGet]
    [Route("[action]/{userName}", Name = "DeleteBasketByUserName")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task<ActionResult<ShopingCartResponse>> DeleteBasket(string userName)
    {
        var query = new DeleteBasketByUserNameQuery(userName);
        return Ok(await _mediator.Send(query));
    }

}