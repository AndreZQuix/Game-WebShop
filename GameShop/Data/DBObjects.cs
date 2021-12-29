using GameShop.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace GameShop.Data
{
    public class DBObjects
    {
        public static void Initialize(AppDBContent content) 
        {

            if (!content.DbCategory.Any())
                content.DbCategory.AddRange(DictCategories.Select(c => c.Value)); // инициализация экземпляров сущности "Категория" в таблице DbCategory БД при отсутствии элементов в таблице

            if (!content.DbGame.Any()) // инициализация экземпляров сущности "Игра" в таблице DbGame БД при отсутствии элементов в таблице
            {
                content.AddRange(
                    new Game { Image = "/img/css.jpg", Name = "Counter-Strike: Source", Desc = "Неустаревающий командный тактический шутер", Details = "", TechReq = "", IsAvailable = true, Quantity = 15, Price = 300, Category = DictCategories["Action"] },
                    new Game { Image = "/img/cof.jpg", Name = "Cry of Fear", Desc = "Известный представитель жанра survival horror", Details = "", TechReq = "", IsAvailable = true, Quantity = 20, Price = 100, Category = DictCategories["Horror"] },
                    new Game { Image = "/img/ylad.jpg", Name = "Yakuza: Like a Dragon", Desc = "Восьмой выпуск легендарной серии в стиле JRPG", Details = "", TechReq = "", IsAvailable = true, Quantity = 10, Price = 800, Category = DictCategories["JRPG"] },
                    new Game { Image = "/img/va11halla.jpg", Name = "Va-11 Hall-a", Desc = "Симулятор бармена эпохи киберпанка", Details = "", TechReq = "", IsAvailable = false, Quantity = 0, Price = 200, Category = DictCategories["Quest"] },
                    new Game { Image = "/img/os.jpg", Name = "One Shot", Desc = "Сюрреалистическая приключенческая игра", Details = "", TechReq = "", IsAvailable = true, Quantity = 7, Price = 50, Category = DictCategories["Quest"] }) ;
            }

            content.SaveChanges(); // сохранение изменений
        }
        private static Dictionary<string, Category> category;
        public static Dictionary<string, Category> DictCategories
        {
            get
            {
                if (category == null)
                {
                    var list = new Category[]
                    {
                        new Category { CategoryName = "Action", CategoryDesc = "Для желающих проходить один и тот же момент тысячу раз" },
                        new Category { CategoryName = "Horror", CategoryDesc = "Для любителей пощекотать нервишки" },
                        new Category { CategoryName = "JRPG", CategoryDesc = "Японские RPG" },
                        new Category { CategoryName = "RPG", CategoryDesc = "Жанр, основанный на элементах настольных ролевых игр" },
                        new Category { CategoryName = "Quest", CategoryDesc = "Искусство создания интерактивных историй" }
                    };

                    category = new Dictionary<string, Category>();
                    foreach(Category c in list)
                        category.Add(c.CategoryName, c);
                }

                return category;
            }
        }
    }
}
