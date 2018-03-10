using InternetBanking.Core;
using InternetBanking.Core.Bank;
using InternetBanking.Core.Currency.ForeignCurrency;
using InternetBanking.Core.Order;
using InternetBanking.Core.TransactionService;
using InternetBanking.Core.User;
using InternetBanking.Data.Context;
using InternetBanking.Data.Repository;
using InternetBanking.Web.Models.TransactionViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InternetBanking.Web.Controllers
{
	[Authorize]
	public class TransactionController : Controller
    {
		private readonly UserManager<User> _userManager;
		private readonly IRepository<TransactionOrder> _repo;
		private readonly ITransactionService service;
		public TransactionController(UserManager<User> userManager, IRepository<TransactionOrder> repo, ITransactionService service)
		{
			this._userManager = userManager;
			this._repo = repo;
			this.service = service;
		}

		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
        public IActionResult Index(IFormCollection form)
        {
			var sender = form["sender"];
			var receiver = form["receiver"];

			if(sender == receiver)
			{
				return View();
			}

			if(sender == "NagaBankHanQuoc" || receiver == "NagaBankHanQuoc")
			{
				if (sender == "NagaBankHanQuoc")
				{
					return RedirectToAction("InformationVietHan", new { sender = sender, receiver = receiver, action = ActionTransfer.Sell });
				}
				return RedirectToAction("InformationVietHan", new { sender = sender, receiver = receiver, action = ActionTransfer.Buy });
			}
			else
			{
				if (sender == "YuChoNhatBan")
				{
					return RedirectToAction("InformationVietNhat", new { sender = sender, receiver = receiver, action = ActionTransfer.Sell });
				}
				return RedirectToAction("InformationVietNhat", new { sender = sender, receiver = receiver, action = ActionTransfer.Buy });
			}

        }

		[HttpGet]
		public ActionResult InformationVietNhat(string sender, string receiver, ActionTransfer action)
		{
			ViewData["sender"] = sender;
			ViewData["receiver"] = receiver;
			ViewData["ActionTransfer"] = action;

			return View();
		}

		[HttpPost]
		public ActionResult InformationVietNhat(VietNhatForm form)
		{
			string userId = _userManager.GetUserId(HttpContext.User);
			string senderAccountId = form.SenderAccoutId;
			string senderName = form.SenderAccountName;
			string receiverAccountId = form.ReceiverAccoutId;
			string receiverAccountName = form.ReceiverAccountName;
			JPY value = new JPY(form.MoneyValue);
			ActionTransfer action = form.action;

			var order = TransactionOrder.Create(userId, senderAccountId, senderName, receiverAccountId, receiverAccountName, value, action);

			service.SenderBank = CreateBank.Create(form.senderbank);
			service.SenderBank = CreateBank.Create(form.receiverbank);

			if (service.IsAvailable())
			{
				return RedirectToAction("Confirm");
			}

			return View();
		}


		[HttpGet]
		public ActionResult InformationVietHan(string sender, string receiver, ActionTransfer action)
		{
			ViewData["sender"] = sender;
			ViewData["receiver"] = receiver;
			ViewData["ActionTransfer"] = action;

			return View();
		}

		[HttpPost]
		public ActionResult InformationVietHan(VietHanForm form)
		{
			string userId = _userManager.GetUserId(HttpContext.User);
			string senderAccountId = form.SenderAccoutId;
			string senderName = form.SenderAccountName;
			string receiverAccountId = form.ReceiverAccoutId;
			string receiverAccountName = form.ReceiverAccountName;
			KRW value = new KRW(form.MoneyValue);
			ActionTransfer action = form.action;

			var order = TransactionOrder.Create(userId, senderAccountId, senderName, receiverAccountId, receiverAccountName, value, action);


			service.SenderBank = CreateBank.Create(form.senderbank);
			service.ReceiverBank = CreateBank.Create(form.receiverbank);

			service.Order = order;

			if (service.IsAvailable())
			{
				return RedirectToAction("Confirm");
			}

			return View();
		}


		//[HttpGet]
		//public ActionResult ConfirmView(TransferService service)
		//{
		//	ViewData["service"] = service;
		//	return View();
		//}
		

		[HttpGet]
		public ActionResult Confirm()
		{
			service.Confirm();
			service.Send();
			return RedirectToAction("GetOrderUser");
			
		}


		[HttpGet]
		public ActionResult GetOrderUser(string userId)
		{
			if(userId == null)
				userId = _userManager.GetUserId(HttpContext.User);
			
			var repo = _repo as TransactionRepository;

			var orders = repo.GetBuyUser(userId);

			return View(orders);
		}
	}
}