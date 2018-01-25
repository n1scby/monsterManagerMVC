using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Interfaces;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;
using MonsterManager.Models;

namespace MonsterManager.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMonsterRepository _monsterRepo;

        public HomeController(IMonsterRepository monsterRepo)
        {
            _monsterRepo = monsterRepo; 
        }

        public IActionResult Index()
        {
           
            return View(_monsterRepo.GetMonsterList());
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Profile(int id)
        {
           
            return View(_monsterRepo.GetMonsterByID(id));
        }


        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
