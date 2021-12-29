using GameShop.Data.Interfaces;
using GameShop.Data.Models;
using GameShop.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GameShop.Controllers
{
    public class GamesController : Controller
    {
        private readonly IAllGames _allGames;
        private readonly IGamesCategory _categories;
        GamesListViewModel viewModel;
        public GamesController(IAllGames allGames, IGamesCategory gamesCategory)
        {
            _allGames = allGames;
            _categories = gamesCategory;
        }

        private IEnumerable<Game> GetData(string category, int page = 1)
        {
            int pageSize = 9;   // max number of elements on page

            IEnumerable<Game> games = null;
            string currCategory = category; 
            if (string.IsNullOrEmpty(category)) // if category does not exist,
            {
                games = _allGames.Games.OrderBy(i => i.Id).Skip((page - 1) * pageSize).Take(pageSize).ToList(); // show all items with pagination
                viewModel = new GamesListViewModel(games, currCategory, _allGames.Games.Count(), page, pageSize);
            }
            else    // if category exists,
            {
                foreach (Category cat in _categories.Categories)    // show items by category with pagination
                {
                    if (string.Equals(cat.CategoryName, category, StringComparison.OrdinalIgnoreCase))
                    {
                        games = _allGames.Games.Where(c => c.Category.CategoryName.Equals(cat.CategoryName)).OrderBy(i => i.Id).Skip((page - 1) * pageSize).Take(pageSize).ToList(); ;
                        currCategory = cat.CategoryName;
                        viewModel = new GamesListViewModel(games, currCategory, games.Count(), page, pageSize);
                    }
                }
            }
            return games;
        }

        [Route("Games/List")]   // attribute routing
        [Route("Games/List/{category}")]
        [HttpGet]
        public ViewResult List(string category, int page = 1)
        {
            GetData(category, page);
            return View(viewModel);
        }
    }
}
