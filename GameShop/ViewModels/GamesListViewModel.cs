

using GameShop.Data.Models;
using System;
using System.Collections.Generic;

namespace GameShop.ViewModels
{
    public class GamesListViewModel
    {
        public IEnumerable<Game> IEAllGames { get; set; }   // // repository of entity "Game" instances

        public string currCategory { get; set; }    // current category
        public int PageNumber { get; private set; }
        public int TotalPages { get; private set; } // number of pages

        public GamesListViewModel(IEnumerable<Game> games, string cat, int count, int pageNumber, int pageSize)
        {
            IEAllGames = games;
            currCategory = cat;
            PageNumber = pageNumber;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);   // calculate number of pages
        }

        public bool HasPreviousPage
        {
            get
            {
                return (PageNumber > 1);    // if current page number > 1, that previous page exists
            }
        }

        public bool HasNextPage
        {
            get
            {
                return (PageNumber < TotalPages);   // if current page number < number of pages, that next page exists
            }
        }
    }
}
