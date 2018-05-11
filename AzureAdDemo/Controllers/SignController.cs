using System;
using System.Collections.Generic;
using System.Linq;
using Weeb = System.Web;
using System.Web.Mvc;
using System.IO;

namespace AzureAdDemo.Controllers
{
    [Authorize]
    public class SignController : Controller
    {
        public ActionResult Index()
        {
            var localPath = Weeb.HttpContext.Current.Server.MapPath("UserImage");

            var images = Directory.GetFiles(localPath, "*.PNG");
            var imagePaths = images.Select(i => Path.GetFileName(i)).ToArray();

            ViewBag.ImagePaths = imagePaths;
            return View();
        }
    }
}