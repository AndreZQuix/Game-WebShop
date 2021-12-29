using GameShop.Data.Models;
using System.Collections.Generic;

namespace GameShop.Data.Interfaces
{
    public interface IAllGames // интерфейс репозитория сущности "Игра"
    {
        IEnumerable<Game> Games { get; }
        Game getGame(int id); // получение экземпляра сущности "Игра" по уникальному ID
    }
}
