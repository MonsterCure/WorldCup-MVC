using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WorldCup.Entities;
using WorldCup.Repository;
using WorldCup.Service;

namespace WorldCup.Web.Controllers
{
    public class MatchesController : Controller
    {
        private MatchService _matchService;
        private MatchRepository _matchRepository = new MatchRepository();

        public MatchesController()
        {
            _matchService = new MatchService(this.ModelState, _matchRepository);
        }

        // GET: Matches
        public ActionResult Index()
        {
            return View(_matchService.GetAllMatches().OrderBy(matchItem => matchItem.MatchTime));
        }

        public ActionResult MatchesByDate(DateTime matchDate)
        {
            return PartialView("Index",
                _matchService.GetMatchesByDate(matchDate).OrderBy(matchItem => matchItem.MatchTime));
        }

        public ActionResult MatchesByGroup(string group)
        {
            return PartialView("Index",
                _matchService.GetMatchesByGroup(group).OrderBy(matchItem => matchItem.MatchTime));
        }

        public ActionResult MatchesByLocation(string location)
        {
            return PartialView("Index",
                _matchService.GetMatchesByLocation(location).OrderBy(matchItem => matchItem.MatchTime));
        }

        public ActionResult MatchesByTeam(string teamName)
        {
            return PartialView("Index",
                _matchService.GetMatchesByTeam(teamName).OrderBy(matchItem => matchItem.MatchTime));
        }

        public ActionResult MatchesByType(string matchType)
        {
            return PartialView("Index",
                _matchService.GetMatchesByType(matchType).OrderBy(matchItem => matchItem.MatchTime));
        }

        // GET: Matches/Create
        [Authorize(Roles = "Administrator")]
        public ActionResult Create()
        {
            //get all the teams
            IEnumerable<Team> teams = _matchService.GetAllTeams().OrderBy(teamItem => teamItem.Name);

            //create a list of SelectListItems
            List<SelectListItem> items = new List<SelectListItem>();

            //add the team's ID and name to the SeletListItem list
            foreach (var team in teams)
            {
                items.Add(new SelectListItem { Text = team.Name, Value = team.TeamId.ToString() });
            }

            //send the SelectListItem list to the view through ViewBag
            ViewBag.Teams = items;

            return View();
        }

        // POST: Matches/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public ActionResult Create([Bind(Include = "MatchId,MatchTime,MatchType,Group,StadiumLocation,Team1Id,Team2Id,ScoreTeam1,ScoreTeam2")]Match match)
        {
            if (!_matchService.CreateMatch(match))
                return View(match);
            return RedirectToAction("Index");
        }

        // GET: Matches/Edit/5
        [Authorize(Roles = "Administrator")]
        [Route("Edit/{id}")]
        public ActionResult Edit(Int16? id)
        {
            //get all the teams
            IEnumerable<Team> teams = _matchService.GetAllTeams().OrderBy(teamItem => teamItem.Name);

            //create a list of SelectListItems
            List<SelectListItem> items = new List<SelectListItem>();

            //add the team's ID and name to the SeletListItem list
            foreach (var team in teams)
            {
                items.Add(new SelectListItem { Text = team.Name, Value = team.TeamId.ToString() });
            }

            //send the SelectListItem list to the view through ViewBag
            ViewBag.Teams = items;

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Match match = _matchService.GetMatchById(id.Value);

            if (match == null)
            {
                return HttpNotFound();
            }

            return View(match);
        }

        // POST: Matches/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public ActionResult Edit([Bind(Include = "MatchId,MatchTime,MatchType,Group,StadiumLocation,Team1Id,Team2Id,ScoreTeam1,ScoreTeam2")]Match match)
        {
            if (!_matchService.UpdateMatch(match))
                return View(match);
            return RedirectToAction("Index");
        }

        // GET: Matches/Delete/5
        [Authorize(Roles = "Administrator")]
        public ActionResult Delete(Int16? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Match match = _matchService.GetMatchById(id.Value);

            if (match == null)
            {
                return HttpNotFound();
            }

            return View(match);
        }

        // POST: Matches/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public ActionResult Delete(Int16? id, Match match)
        {
            try
            {
                _matchService.DeleteMatch(id.Value);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(match);
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _matchService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}