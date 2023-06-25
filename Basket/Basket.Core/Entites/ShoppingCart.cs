namespace Basket.Core.Entites;

public class ShoppingCart
{

    public string UserName { get; set; }

    public ShoppingCart()
    {

    }

    public ShoppingCart(string userName)
    {
        UserName = userName;
    }


}