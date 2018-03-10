using InternetBanking.Core;
using InternetBanking.Core.Order;
using InternetBanking.Core.User;
using InternetBanking.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace InternetBanking.Web.Controllers
{
	[Authorize(Roles = "Admin")]
	public class AdminController : Controller
    {
		private IRepository<User> _userRepo;
		private IRepository<TransactionOrder> _orderRepo;

		public AdminController(IRepository<User> userRepo, IRepository<TransactionOrder> orderRepo)
		{
			this._userRepo = userRepo;
			this._orderRepo = orderRepo;
		}

		public ActionResult Index()
		{
			return View();
		}

        public ActionResult GetListUser()
		{
			var users = _userRepo.GetAll();
			return View(users);
		}

		public ActionResult GetListOrder()
		{
			var orders = _orderRepo.GetAll();
			return View(orders);
		}

		[HttpGet, ActionName("Rate")]
		public ActionResult ViewRate()
		{
			return View();
		}

		[HttpPost, ActionName("Rate")]
		public ActionResult ChangeRate(FormCollection form)
		{
			return View();
		}

		[HttpGet, ActionName("Resource")]
		public ActionResult ViewResource()
		{
			return View();
		}

		[HttpPost, ActionName("Resource")]
		public ActionResult ChangeResource(FormCollection form)
		{

			return View();
		}

	}
}