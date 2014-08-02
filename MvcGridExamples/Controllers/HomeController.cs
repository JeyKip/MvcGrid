using MvcGrid.DataFormat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcGridExamples.Controllers
{
    public class HomeController : Controller
    {
        class VisitorInfo
        {
            public string UserAgent { get; set; }
            public string ScreenSize { get; set; }
            public string Referer { get; set; }
            public DateTime VisitTime { get; set; }
        }

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetData()
        {
            JsonData data = new JsonData()
            {
                TotalPages = 1,
                CurrentPage = 1,
                Records = 2,
                Rows = new List<VisitorInfo>() 
                {
                    new VisitorInfo()
                    {
                        UserAgent = "Google Chrome",
                        ScreenSize = "1024x768",
                        Referer = "Google",
                        VisitTime = new DateTime(2014, 6, 27)
                    },
                    new VisitorInfo()
                    {
                        UserAgent = "Mozilla Firefox",
                        ScreenSize = "1024x900",
                        Referer = "Yandex",
                        VisitTime = new DateTime(2014, 7, 27)
                    }
                }
            };
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}