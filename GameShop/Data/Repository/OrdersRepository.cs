using GameShop.Data.Interfaces;
using GameShop.Data.Models;
using System;
using System.Collections.Generic;

namespace GameShop.Data.Repository
{
    public class OrdersRepository : IAllOrders
    {
        private readonly AppDBContent _content;
        private readonly ShopCart _cart;

        public IEnumerable<Order> Orders => _content.DbOrder;

        public OrdersRepository(AppDBContent content, ShopCart cart)
        {
            _content = content;
            _cart = cart;
        }
        public void createOrder(Order order)
        {
            order.OrderTime = DateTime.Now; 
            _content.DbOrder.Add(order);
            _content.SaveChanges();
            var items = _cart.ListShopItems;    // get items from ShopCart

            foreach (var item in items)
            {
                var orderDetail = new OrderDetail   // order content
                {
                    GameId = item.Game.Id,
                    OrderId = order.Id,
                    Price = item.Game.Price
                };
                _content.DbOrderDetails.Add(orderDetail);
                item.Game.Quantity--;   // quantity calculation
                if (item.Game.Quantity == 0) item.Game.IsAvailable = false; // check if item is available

            }

            _content.DbShopCartItem.RemoveRange(_content.DbShopCartItem);   // clear ShopCart
            _content.SaveChanges();
        }
    }
}
