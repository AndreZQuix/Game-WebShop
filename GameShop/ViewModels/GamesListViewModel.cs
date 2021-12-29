

using GameShop.Data.Models;
using System;
using System.Collections.Generic;

namespace GameShop.ViewModels
{
    public class GamesListViewModel
    {
        public IEnumerable<Game> IEAllGames { get; set; }   // хранилище экземпляров сущности "Игра"

        public string currCategory { get; set; }    // категория
        public int PageNumber { get; private set; } // номер страницы
        public int TotalPages { get; private set; } // всего страниц

        public GamesListViewModel(IEnumerable<Game> games, string cat, int count, int pageNumber, int pageSize)
        {
            IEAllGames = games;
            currCategory = cat;
            PageNumber = pageNumber;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);   // расчет количества страниц
        }

        public bool HasPreviousPage
        {
            get
            {
                return (PageNumber > 1);    // если номер текущей страницы больше единицы, значит, предыдущая страница есть
            }
        }

        public bool HasNextPage
        {
            get
            {
                return (PageNumber < TotalPages);   // если номер текущей страницы меньше количества страниц, значит, следующая страница есть
            }
        }
    }
}
