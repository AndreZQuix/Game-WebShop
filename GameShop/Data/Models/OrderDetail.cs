using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameShop.Data.Models
{
    public class OrderDetail
    {
        public int Id { get; set; } // уникальный ID
        public int OrderId { get; set; } // ID заказа
        public int GameId { get; set; } // ID игры
        public int Price { get; set; }  // цена товара
        public Game game { get; set; }  // элемент заказа
        public virtual Order Order { get; set; }    // заказ (данные клиента)
    }
}