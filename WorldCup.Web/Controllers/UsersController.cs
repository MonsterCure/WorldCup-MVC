using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WorldCup.Entities;
using WorldCup.Repository;
using WorldCup.Service;

namespace WorldCup.Web.Controllers
{
    [Authorize]
    public class UsersController : Controller
    {
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;
        private UserService _userService;

        public UsersController()
        {
            _userService = new UserService(ModelState);
        }

        public UsersController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        public ActionResult ProfilePage()
        {
            return View();
        }

        public ActionResult GetFavoritePlayers()
        {
            var userId = User.Identity.GetUserId();
            //var user = Membership.GetUser(true);
            return View(_userService.GetFavoritePlayers(userId).ToList());
        }

        public ActionResult GetFavoriteTeams()
        {
            var userId = User.Identity.GetUserId();
            return PartialView(_userService.GetFavoriteTeams(userId).ToList());
        }

        public ActionResult GetFavoriteMatches()
        {
            var userId = User.Identity.GetUserId();
            return PartialView(_userService.GetFavoriteMatches(userId).ToList());
        }

        [HttpPost]
        public ActionResult AddFavoritePlayer(Int16 playerId)
        {
            ApplicationUser user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());

            string userId = user.Id;
            if (userId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            try
            {
                _userService.AddFavoritePlayer(playerId, userId);
            }
            catch (Exception ex)
            {

                throw ex;
            }

            

            return RedirectToAction("ProfilePage");
        }

        [HttpPost]
        public ActionResult AddFavoriteTeam(Int16 teamId)
        {
            var userId = User.Identity.GetUserId();
            if (userId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            _userService.AddFavoriteTeam(teamId, userId);

            return RedirectToAction("ProfilePage");
        }

        [HttpPost]
        public ActionResult AddFavoriteMatch(Int16 matchId)
        {
            var userId = User.Identity.GetUserId();
            if (userId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            _userService.AddFavoriteMatch(matchId, userId);

            return RedirectToAction("ProfilePage");
        }

        [HttpPost]
        public ActionResult RemoveFavoritePlayer(Int16 playerId)
        {
            var userId = User.Identity.GetUserId();
            _userService.RemoveFavoritePlayer(playerId, userId);
            return View("ProfilePage");
        }

        [HttpPost]
        public ActionResult RemoveFavoriteTeam(Int16 teamId)
        {
            var userId = User.Identity.GetUserId();
            _userService.RemoveFavoriteTeam(teamId, userId);
            return View("ProfilePage");
        }

        [HttpPost]
        public ActionResult RemoveFavoriteMatch(Int16 matchId)
        {
            var userId = User.Identity.GetUserId();
            _userService.RemoveFavoriteMatch(matchId, userId);
            return View("ProfilePage");
        }
    }
}
