using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WilderMindApp.Data;
using WilderMindApp.Services;

namespace WilderMindApp.Controllers
{
    public class HomeController : Controller
    {
        private IMailService _mail;
        private IMessageBoardRepository _boardRepo;
 
        public HomeController(IMailService mailService,IMessageBoardRepository boardRepo)
        {
            _mail = mailService;
            _boardRepo = boardRepo;
        }

        public ActionResult Index()
        {
            var result  = _mail.SendMail("", "", "", "");
            ViewBag.mailSent = result;

            var topics = _boardRepo
                .GetTopics()
                .OrderByDescending(t => t.createdAt)
                .Take(25);

            return View(topics);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}