using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QBox.Web.Controllers
{
    public class InfoController : Controller
    {
        // GET: Info
        public ActionResult Index()
        {
            using (var sr = new StreamReader("c:\\temp\\info.txt"))
            {
                var text = sr.ReadToEnd();
                Response.Write(text);
                Response.End();
            }
            return View();
        }
    }
}