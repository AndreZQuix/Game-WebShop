using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GameShop.Data.Models
{
    public class ShopCart
    {
        private readonly AppDBContent _content;
        public uint InTotal { get; set; }   // сумма всех товаров в корзине

        public ShopCart(AppDBContent _content)  // получение данных из таблицы БД
        {
            this._content = _content;
        }
        public string ShopCartId { get; set; }  // ID корзины
        public List<ShopCartItem> ListShopItems { get; set; }   // товары в корзине
        public static ShopCart GetCart(IServiceProvider services)   // получение конкретной корзины пользователя
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = services.GetService<AppDBContent>();
            string shopCartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();
            session.SetString("CartId", shopCartId);
            return new ShopCart(context) { ShopCartId = shopCartId };
        }

        public void AddToCart(Game game)    // добавить товар в корзину
        {
            InTotal += game.Price; // добавление цены игры к итоговой суммы
            _content.DbShopCartItem.Add(new ShopCartItem // создание и добавление экземпляра сущности "Элемент корзины" в таблицу DbShopCartItem
            {
                ShopCartId = ShopCartId,
                Game = game
            });

            _content.SaveChanges();
        }

        public void DeleteFromCart(int id)  // удалить товар из корзины
        {
            var itemToDelete = _content.DbShopCartItem.Where(c => c.Id == id).First(); // поиск подлежащего к удалению из корзины товара по ID
            _content.DbShopCartItem.Remove(itemToDelete);   // удаление экземпляра сущности "Элементы корзины" из таблицы
            _content.SaveChanges();
        }

        public List<ShopCartItem> getShopItems()    // получить все товары корзины
        {
            return _content.DbShopCartItem.Where(c => c.ShopCartId == ShopCartId).Include(s => s.Game).ToList();
        }
    }
}
