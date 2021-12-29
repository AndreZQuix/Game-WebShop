namespace GameShop.Data.Models
{
    public class Game
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; } // description
        public string Details { get; set; } // additional information
        public string TechReq { get; set; } // technical requirements
        public string Image { get; set; }
        public bool IsAvailable { get; set; }
        public int Quantity { get; set; }
        public ushort Price { get; set; } 
        public int CategoryId { get; set; } 
        public virtual Category Category { get; set; }  // category the game belongs to
    }
}
