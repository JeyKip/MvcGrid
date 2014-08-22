using MvcGrid.DataFormat;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using MvcGridExamples.Models;
using MvcGridExamples.Data;

namespace MvcGridExamples.Controllers
{
    public class HomeController : Controller
    {
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
                Rows = DataReferenceReader.GetDataReferenceList()
            };
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetDataReferenceValues(int id)
        {
            JsonData data = new JsonData() 
            {
                Rows = DataReferenceReader.GetValues(id)
            };
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}