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
                .Where(l => l.Sport !=("Football"))
                .ToList();
            ViewBag.Conference = _context.Leagues
                .Where(l => l.Name.Contains("Conference"))
                .ToList();
            ViewBag.Atlantic = _context.Leagues
                .Where(l => l.Name.Contains("Atlantic"))
                .ToList();
            ViewBag.Dallas = _context.Teams
                .Where(l => l.Location.Contains("Dallas"))
                .ToList();
            ViewBag.Raptors = _context.Teams
                .Where(l => l.TeamName.Contains("Raptors"))
                .ToList();
            ViewBag.City = _context.Teams
                .Where(l => l.Location.Contains("City"))
                .ToList();
            ViewBag.T = _context.Teams
                .Where(l => l.TeamName.StartsWith("T"))
                .ToList();
            //ordered alphabetically by location 
            ViewBag.Location = _context.Teams
                .OrderBy(l => l.Location)
                .ToList();
            ViewBag.TeamName = _context.Teams
                .OrderByDescending(l => l.TeamName)
                .ToList();
            ViewBag.LastName = _context.Players
                .Where(l => l.LastName.Contains("Cooper"))
                .ToList();
            ViewBag.FirstName = _context.Players
                .Where(l => l.FirstName.Contains("Joshua"))
                .ToList();
                //exclude first names that cointain "Joshua"
            ViewBag.LastName = _context.Players
                .Where(l => l.LastName.Contains("Cooper"))
                .Where(f => !f.FirstName.Contains("Joshua"))
                .ToList();
              ViewBag.FirstName = _context.Players
                .Where(l => l.FirstName.Contains("Alexander")) 
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