using GameShop.Data.Models;
using System.Collections.Generic;

namespace GameShop.Data.Interfaces
{
    public interface IAllOrders // интерфейс репозитория сущности "Заказ"
    {
        IEnumerable<Order> Orders { get; } // перечислитель, поддерживающий перебор элементов в коллекции
        void createOrder(Order order);  // создание заказа

    }
}
