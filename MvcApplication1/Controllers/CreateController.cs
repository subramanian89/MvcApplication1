using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication1.Controllers
{
    public class CreateController : Controller
    {
        public string Value { get; set; }

        //
        // GET: /Create/
        public ActionResult Index()
        {
            return View();
        }
       
        public ActionResult Instance(string id)
        {
            ViewBag.Value = id ;
            return View();
        }
        [HttpPost]
        public ActionResult Instance(string id)
        {
            ViewBag.Value = id;
            return View();
        }

        [HttpPost]
        public ActionResult Index(HttpPostedFileBase file)
        {
            // Verify that the user selected a file
            if (file != null && file.ContentLength > 0)
            {
                // extract only the fielname
                var fileName = Path.GetFileName(file.FileName);
                // store the file inside ~/App_Data/uploads folder
                var path = Path.Combine(Server.MapPath("~/Content/Images"),"1293445.jpeg");
                file.SaveAs(path);
            }
            // redirect back to the index action to show the form once again
            return RedirectToAction("Instance/1239445");
        }
    }
}
