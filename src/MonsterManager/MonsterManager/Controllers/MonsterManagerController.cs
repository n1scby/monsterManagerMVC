using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MonsterManager.Controllers
{
    [Authorize]
    public class MonsterManagerController : Controller
    {
        private readonly IMonsterRepository _monsterRepo;

        // Constructor
        public MonsterManagerController(IMonsterRepository monsterRepo)
        {
            _monsterRepo = monsterRepo;
        }

        // GET: MonsterManager
        public ActionResult Index()
        {
            return View(_monsterRepo.GetMonsterList());
        }

        // GET: MonsterManager/Details/5
        public ActionResult Details(int id)
        {
            return View(_monsterRepo.GetMonsterByID(id));
        }

        // GET: MonsterManager/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MonsterManager/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Monster newMonster, IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    _monsterRepo.Add(newMonster);
                    return RedirectToAction(nameof(Index));
                }

               
            }
            catch(Exception)
            {
                //log error here

            }
            return View(newMonster);
        }

        // GET: MonsterManager/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_monsterRepo.GetMonsterByID(id));
        }

        // POST: MonsterManager/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Monster updatedMonster, int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                _monsterRepo.Edit(updatedMonster);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(updatedMonster);
            }
        }

        // GET: MonsterManager/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_monsterRepo.GetMonsterByID(id));
        }

        // POST: MonsterManager/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Monster deleteMonster, int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                _monsterRepo.Delete(deleteMonster);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(deleteMonster);
            }
        }
    }   
}