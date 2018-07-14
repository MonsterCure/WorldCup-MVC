using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WorldCup.Entities;
using WorldCup.Service;

namespace WorldCup.Web.Controllers
{
    public class PlayersController : Controller
    {
        private PlayerService _playerService;

        public PlayersController()
        {
            _playerService = new PlayerService(this.ModelState);
        }

        // GET: Players
        //[HandleError(ExceptionType = typeof(SqlException), View = "SqlExceptionView")]
        public ActionResult Index()
        {
            return View(_playerService.GetAllPlayers().OrderBy(playerItem => playerItem.PlayerName));
        }

        public ActionResult Search(string searchCriteria)
        {
            return PartialView("Index",
                _playerService.GetAllPlayers(searchCriteria).OrderBy(playerItem => playerItem.PlayerName));
        }

        public ActionResult SearchByPosition(string searchCriteria)
        {
            return PartialView("Index",
                _playerService.GetPlayersByPosition(searchCriteria).OrderBy(playerItem => playerItem.PlayerName));
        }

        public ActionResult SearchByTeam(string searchCriteria)
        {
            return PartialView("Index",
                _playerService.GetPlayersByTeam(searchCriteria).OrderBy(playerItem => playerItem.PlayerName));
        }

        // GET: Players/Details/
        public ActionResult Details(Int16? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Player player = _playerService.GetPlayerById(id.Value);
            if (player == null)
            {
                return HttpNotFound();
            }
            return View(player);
        }

        // GET: Players/Create
        [Authorize(Roles = "Administrator")]
        public ActionResult Create()
        {
            IEnumerable<Team> teams = _playerService.GetAllTeams().OrderBy(teamItem => teamItem.Name);

            List<SelectListItem> items = new List<SelectListItem>();

            foreach (var team in teams)
            {
                items.Add(new SelectListItem { Text = team.Name, Value = team.TeamId.ToString() });
            }
            
            ViewBag.Teams = items;

            return View();
        }

        // POST: Players/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public ActionResult Create([Bind(Include = "PlayerId,PlayerName,Age,DateOfBirth,Biography,PictureUrl,Position,PlayerTeamId,GoalsScored")]Player player)
        {
            if (!_playerService.CreatePlayer(player))
                return View(player);
            return RedirectToAction("Index");
        }

        // GET: Players/Edit/5
        [Authorize(Roles = "Administrator")]
        public ActionResult Edit(Int16? id)
        {
            IEnumerable<Team> teams = _playerService.GetAllTeams().OrderBy(teamItem => teamItem.Name);

            List<SelectListItem> items = new List<SelectListItem>();

            foreach (var team in teams)
            {
                items.Add(new SelectListItem { Text = team.Name, Value = team.TeamId.ToString() });
            }

            ViewBag.Teams = items;

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Player player = _playerService.GetPlayerById(id.Value);

            if (player == null)
            {
                return HttpNotFound();
            }

            return View(player);
        }

        // POST: Players/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public ActionResult Edit([Bind(Include = "PlayerId,PlayerName,Age,DateOfBirth,Biography,PictureUrl,Position,PlayerTeamId,GoalsScored")] Player player)
        {
            if (!_playerService.UpdatePlayer(player))
                return View(player);
            return RedirectToAction("Index");
        }

        // GET: Players/Delete/5
        [Authorize(Roles = "Administrator")]
        public ActionResult Delete(Int16? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Player player = _playerService.GetPlayerById(id.Value);
            if (player == null)
            {
                return HttpNotFound();
            }
            return View(player);
        }

        // POST: Players/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public ActionResult Delete(Int16? id, Player player)
        {
            try
            {
                _playerService.DeletePlayer(id.Value);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(player);
            }
        }
    }
}
