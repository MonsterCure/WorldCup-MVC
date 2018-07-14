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
    public class TeamsController : Controller
    {
        private TeamService _teamService;

        public TeamsController()
        {
            _teamService = new TeamService(ModelState);
        }

        // GET: Teams
        public ActionResult Index()
        {
            return View(_teamService.GetAllTeams().OrderBy(teamItem => teamItem.Name));
        }

        public ActionResult Search(string searchCriteria)
        {
            return PartialView("Index",
                _teamService.GetAllTeams(searchCriteria).OrderBy(teamItem => teamItem.Name));
        }

        public ActionResult SearchByGroup(string group)
        {
            return PartialView("Index",
                _teamService.GetTeamsByGroup(group).OrderBy(teamItem => teamItem.Name));
        }

        public ActionResult SearchByContinent(string continent)
        {
            return PartialView("Index",
                _teamService.GetTeamsByContinent(continent).OrderBy(teamItem => teamItem.Name));
        }

        // GET: Teams/Details/5
        public ActionResult Details(Int16? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Team team = _teamService.GetTeamById(id.Value);

            if (team == null)
            {
                return HttpNotFound();
            }

            return View(team);
        }

        // GET: Teams/Create
        [Authorize(Roles = "Administrator")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Teams/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public ActionResult Create([Bind(Include = "TeamId,Name,FlagUrl,Group,Continent")]Team team)
        {
            team.TeamId = (Int16)_teamService.GetAllTeams().Count();
            if (!_teamService.CreateTeam(team))
                return View(team);
            return RedirectToAction("Index");
        }

        // GET: Teams/Edit/5
        [Authorize(Roles = "Administrator")]
        public ActionResult Edit(Int16? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Team team = _teamService.GetTeamById(id.Value);

            if (team == null)
            {
                return HttpNotFound();
            }

            return View(team);
        }

        // POST: Teams/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public ActionResult Edit([Bind(Include = "TeamId,Name,FlagUrl,Group,Continent")]Team team)
        {
            if (!_teamService.UpdateTeam(team))
                return View(team);
            return RedirectToAction("Index");
        }

        // GET: Teams/Delete/5
        [Authorize(Roles = "Administrator")]
        public ActionResult Delete(Int16? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Team team = _teamService.GetTeamById(id.Value);

            if (team == null)
            {
                return HttpNotFound();
            }

            return View(team);
        }

        // POST: Teams/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public ActionResult Delete(Int16? id, Team team)
        {
            try
            {
                _teamService.DeleteTeam(id.Value);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(team);
            }
        }

        public ActionResult GroupsView()
        {
            return View(_teamService.GetAllTeams().OrderBy(teamItem => teamItem.Name));
        }

        public ActionResult GroupsPartialView(string group)
        {
            return PartialView("GroupsView",
                _teamService.GetTeamsByGroup(group).OrderByDescending(teamItem => teamItem.Points));
        }
    }
}