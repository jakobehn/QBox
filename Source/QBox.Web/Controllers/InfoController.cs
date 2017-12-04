using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Caching;
using System.Web.Mvc;

namespace QBox.Web.Controllers
{
    public class InfoController : Controller
    {
        // GET: Info
        public ActionResult Index()
        {
            int nr = 0;
            var file = "c:\\temp\\data\\info.txt";
            if (!System.IO.File.Exists(file))
            {
                using (var sw = new StreamWriter(System.IO.File.Create(file)))
                {
                    sw.Write(0);
                }
            }
            else
            {
                using (var sr = new StreamReader(file))
                {
                    nr = Convert.ToInt32(sr.ReadToEnd());
                }
            }

            using (var sw = new StreamWriter(file))
            {
                sw.Write(nr+1);
            }

            Response.Write(nr+1);
                Response.End();
            return View();
        }
    }
}