using System.Web.Mvc;
using MvcGrid.DataFormat;
using MvcGridExamples.Data;
using System.Linq;

namespace MvcGridExamples.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetCorporationList()
        {
            var cl = CorporationDataAccessor.GetCorporations();
            JsonData data = new JsonData() 
            {
                Rows = cl,
                Records = cl.Count,
                CurrentPage = 1,
                TotalPages = 1
            };
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCreators(int id)
        {
            var creators = CorporationDataAccessor.GetCorporations().FirstOrDefault(x => x.Id == id).Creators;
            JsonData data = new JsonData() 
            {
                Rows = creators,
                Records = creators.Count,
                CurrentPage = 1,
                TotalPages = 1
            };
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}