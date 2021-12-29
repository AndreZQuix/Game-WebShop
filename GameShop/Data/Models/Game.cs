namespace GameShop.Data.Models
{
    public class Game
    {
        public int Id { get; set; } // уникальный ID
        public string Name { get; set; } // название
        public string Desc { get; set; } // описание
        public string Details { get; set; } // дополнительное описание
        public string TechReq { get; set; } // технические требования
        public string Image { get; set; } // изображение
        public bool IsAvailable { get; set; } // наличие
        public int Quantity { get; set; } // количество
        public ushort Price { get; set; } // цена одной копии
        public int CategoryId { get; set; } // ID категории, к которой принадлежит товар
        public virtual Category Category { get; set; }  // категория, к которой принадлежит товар
    }
}
