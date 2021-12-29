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
            order.OrderTime = DateTime.Now; // регистрация даты и времени оформления заказа
            _content.DbOrder.Add(order);    // добавление экземпляра сущности "Заказ" в таблицу DbOrder
            _content.SaveChanges();     // сохранение изменений
            var items = _cart.ListShopItems;    // получение списка экземпляров сущности "Элемент корзины" (т.е. заказанные игры)

            foreach (var item in items)     // создание экземпляров сущности "Детали заказа"
            {
                var orderDetail = new OrderDetail
                {
                    GameId = item.Game.Id,
                    OrderId = order.Id,
                    Price = item.Game.Price
                };
                _content.DbOrderDetails.Add(orderDetail);   // добавление экземпляра сущности "Детали заказа" в таблицу DbOrderDetails
                item.Game.Quantity--;   // уменьшение количества игры (расчет остатков)
                if (item.Game.Quantity == 0) item.Game.IsAvailable = false; // проверка наличия: если количество стало нулю, товар не купить

            }

            _content.DbShopCartItem.RemoveRange(_content.DbShopCartItem);   //очистка корзины
            _content.SaveChanges();
        }
    }
}
