using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Web;
using System.Web.Mvc;
using System.Diagnostics;
using XPTO;

namespace XPTO_NET.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        private bool isValidContetType(string contentType)
        {
            return contentType.Equals("text/plain");
        }

        [HttpPost]
        public ActionResult Process(HttpPostedFileBase file)
        {
            if (!isValidContetType(file.ContentType))
            {
                ViewBag.Error = "Conteúdo do arquivo não é suportado";
                return View("Index");
            }

            string path = "";
            try
            {
                path = SaveFile(file);
            }
            catch (Exception error)
            {
                Debug.Print(error.Message);
            }

            var tuple = FileReader.OpenFile(path);

            if (tuple.Item2)
            {                
                return View("Pessoas", tuple.Item1.Pessoas.Local.ToList());
            }
            else
            {
                return View("Produtos", tuple.Item1.Produtos.Local.ToList());
            }
        }

        private String SaveFile(HttpPostedFileBase file)
        {
            String fileName = Path.GetFileName(file.FileName);
            String path = Path.Combine(Server.MapPath("~/Upload"), fileName);
            file.SaveAs(path);
            return path;
        }
    }
}