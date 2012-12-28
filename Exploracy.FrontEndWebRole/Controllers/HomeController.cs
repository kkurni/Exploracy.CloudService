using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Exploracy.FrontEndWebRole.Models;

namespace Exploracy.FrontEndWebRole.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return RedirectToAction("SubmitReview");
        }

        public ActionResult SubmitReview()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SubmitReview(ItemReviewModel model)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("SubmitReview");
            }
            else
            {
                return View(model);
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
