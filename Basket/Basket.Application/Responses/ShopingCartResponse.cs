namespace Basket.Application.Responses;

public class ShopingCartResponse
{
    public string UserName { get; set; }

    public List<ShopingCartItemResponse> Items { get; set; }


    public ShopingCartResponse()
    {

    }

    public ShopingCartResponse(string userName)
    {
        UserName = userName;
    }


    public decimal TotalPrice
    {
        get
        {
            decimal totalPrice = 0;
            foreach (var item in Items)
            {
                totalPrice += item.Price * item.Quantity;
            }

            return totalPrice;

        }
    }
}