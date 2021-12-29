namespace GameShop.Data.Models
{
    public class ShopCartItem
    {
        public int Id { get; set; } // уникальный ID
        public Game Game { get; set; }  // игра (элемент корзины)
        public string ShopCartId { get; set; } // ID корзины
    }
}
