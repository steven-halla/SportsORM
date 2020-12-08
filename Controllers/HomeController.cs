using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SportsORM.Models;


namespace SportsORM.Controllers
{
    public class HomeController : Controller
    {

        private static Context _context;

        public HomeController(Context DBContext)
        {
            _context = DBContext;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            ViewBag.BaseballLeagues = _context.Leagues
                .Where(l => l.Sport.Contains("Baseball"))
                .ToList();
            return View();
        }

        [HttpGet("level_1")]
        public IActionResult Level1()
        {   ViewBag.WomensLeagues = _context.Leagues
                .Where(l => l.Name.Contains("Women"))
                .ToList();

            ViewBag.HockeyLeagues = _context.Leagues
                .Where(l => l.Sport.Contains("Hockey"))
                .ToList();

            ViewBag.FootballLeagues = _context.Leagues
                .Where(l => l.Sport.Contains("Football"))
                .ToList();
                
            ViewBag.ConferenceLeagues = _context.Leagues
                .Where(l => l.Name.Contains("Conferences"))
                .ToList();

            ViewBag.AtlanticLeagues = _context.Leagues
                .Where(l => l.Name.Contains("Atlantic"))
                .ToList();


            ViewBag.DallasTeams = _context.Teams
                .Where(l => l.Location.Contains("Dallas"))
                .ToList();

            ViewBag.RaptorsTeams = _context.Teams
                .Where(l => l.TeamName.Contains("Raptors"))
                .ToList();

            ViewBag.CityTeams = _context.Teams
                .Where(l => l.Location.Contains("City"))
                .ToList();

            ViewBag.StartWithTTeams = _context.Teams
                .Where(tTeams => tTeams.TeamName.StartsWith("T"))
                .ToList();

            //ordered alphabetically by location 
            ViewBag.TeamsSortedByLocation = _context.Teams
                .OrderBy(teamByLocation => teamByLocation.Location)
                .ToList();

            ViewBag.TeamsReverseOrder = _context.Teams
                .OrderByDescending(TReverseOrder => TReverseOrder.TeamName)
                .ToList();


            ViewBag.LastNameCooperPlayers = _context.Players
                .Where(p => p.LastName.Contains("Cooper"))
                .ToList();

            // ViewBag.FirstName = _context.Players
            //     .Where(Player => Player.FirstName.Contains("Joshua"))
            //     .ToList();

            // PlayersNameJoshua is of type List<Player>
            ViewBag.PlayersNamesJoshua = _context.Players
                .Where(Player => Player.FirstName.Contains("Joshua"))
                .ToList();

                //exclude first names that cointain "Joshua"
            ViewBag.LastNameCooperNoJoshuaPlayers = _context.Players
                .Where(coopPlayerNoJoshua => coopPlayerNoJoshua.LastName.Contains("Cooper"))
                .Where(f => !f.FirstName.Contains("Joshua"))
                .ToList();
            
            ViewBag.AlexAndWyattPlayers = _context.Players
                .Where(duonames => duonames.FirstName.Contains("Alexander")|| duonames.FirstName.Contains("Wyatt")) 
                .ToList();

            
            return View();
        }
        
        [HttpGet("level_2")]
        public IActionResult Level2()
        {
            return View();
        }

        [HttpGet("level_3")]
        public IActionResult Level3()
        {
            return View();
        }

    }
}