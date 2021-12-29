using GameShop.Data.Models;
using System.Collections.Generic;

namespace GameShop.Data.Interfaces
{
    public interface IAllGames // repository interface of entity "Game" instances
    {
        IEnumerable<Game> Games { get; }
        Game getGame(int id); // get entity "Game" instance by unique ID
    }
}
