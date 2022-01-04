using DevBuildLab1_4DeckOfCards.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace DevBuildLab1_4DeckOfCards.Controllers
{
    public class HomeController : Controller
    {
        CardDAL cards = new CardDAL();
        public IActionResult Index()
        {
            CardDeck d = cards.GenerateNewDeck();
            return View(d);
        }

        public IActionResult ShowCards(CardDeck d, int numToDraw)
        {
            CardDeck pile = cards.DrawCards(d, numToDraw);
            return View(pile);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
