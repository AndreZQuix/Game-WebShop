using System.Collections.Generic;

namespace GameShop.Data.Models
{
    public class Category
    {
        public int Id { get; set; } // уникальный ID
        public string CategoryName { get; set; }    // название категории
        public string CategoryDesc { get; set; }    // описание категории
        public List<Game> Games { get; set; }   // игры, принадлежащие категории

    }
}
