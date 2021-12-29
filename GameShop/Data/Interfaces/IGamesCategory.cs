using GameShop.Data.Models;
using System.Collections.Generic;

namespace GameShop.Data.Interfaces
{
    public interface IGamesCategory // repository interface of entity "Game Category" instances
    {
        IEnumerable<Category> Categories { get; }
    }
}
