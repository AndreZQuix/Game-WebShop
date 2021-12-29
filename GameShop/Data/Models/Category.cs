using System.Collections.Generic;

namespace GameShop.Data.Models
{
    public class Category
    {
        public int Id { get; set; } // unique ID
        public string CategoryName { get; set; }    // category name
        public string CategoryDesc { get; set; }    // category description
        public List<Game> Games { get; set; }   // list of games that belong to category

    }
}
