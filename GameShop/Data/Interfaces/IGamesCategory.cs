using GameShop.Data.Models;
using System.Collections.Generic;

namespace GameShop.Data.Interfaces
{
    public interface IGamesCategory // интерфейс репозитория сущности "Категория"
    {
        IEnumerable<Category> Categories { get; }
    }
}
