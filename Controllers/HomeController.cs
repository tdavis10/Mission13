using Bowler.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Bowler.Controllers
{
    public class HomeController : Controller
    {
        private IBowlersRepository _repo { get; set; }
        public HomeController(IBowlersRepository temp)
        {
            _repo = temp;
        }

        public IActionResult Index(string teamType)
        {
            if (teamType == null)
            {
                ViewBag.TeamName = "Home";
            }
            else
            {
                ViewBag.TeamName = teamType;
            }
            
            var blah = _repo.Bowlers
                .Where(b => b.Team.TeamName == teamType || teamType == null)
                .Include(x => x.Team)
                .ToList();

            return View(blah);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Bowler.Models.Bowler b)
        {
            _repo.CreateBowler(b);
            return RedirectToAction("Index");
        }





        [HttpGet]
        public IActionResult Edit(int id)
        {
            var application = _repo.Bowlers.Single(x => x.BowlerID == id);

            return View(application);
        }


        //Post method for the edit

       [HttpPost]
        public IActionResult Edit(Bowler.Models.Bowler b)
        {

            _repo.EditBowler(b);

            return RedirectToAction("Index");

        }

        // Get method for the delete
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var bowler = _repo.Bowlers.Single(x => x.BowlerID == id);

            return View(bowler);
        }

        [HttpPost]
        public IActionResult Delete(Bowler.Models.Bowler b)
        {
            _repo.DeleteBowler(b);
            return RedirectToAction("Index");
        }
    }

}
