using GameShop.Data.Interfaces;
using GameShop.Data.Models;
using GameShop.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Text.Json;

namespace GameShop.Controllers
{
    public class ShopCartController : Controller
    {
        private readonly IAllGames _gamesRep; 
        private readonly ShopCart _shopCart;   

        public ShopCartController(IAllGames gamesRep, ShopCart shopCart)
        {
            _gamesRep = gamesRep;
            _shopCart = shopCart;
        }

        [HttpGet]
        public ViewResult Index()   // передача данных экземпляров модели "Элемент корзины" через модель представления в представление
        {
            var items = _shopCart.getShopItems();
            _shopCart.ListShopItems = items;

            var obj = new ShopCartViewModel { shopCart = _shopCart };

            return View(obj);
        }

        public RedirectToActionResult addToCart(int id) // добавление экземпляров модели "Элемент корзины" при условии существования экземпляра и поднятого булевого флага атрибута "В наличии"
        {
            var item = _gamesRep.Games.FirstOrDefault(i => i.Id == id);
            if(item != null && item.IsAvailable)
            {
                _shopCart.AddToCart(item);
            }
            return RedirectToAction("Index");   // переход к методу Index()
        }

        public RedirectToActionResult deleteFromCart(int id)    // удаление экземпляров модели "Элемент корзины", переход к методу Index()
        {
            _shopCart.DeleteFromCart(id);
            return RedirectToAction("Index");
        }

    }
}
