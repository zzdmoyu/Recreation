using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Recreation.Controllers
{
    public class ImageController : Controller
    {
        public ActionResult UploadIndex()
        {
            return View();
        }

        public ActionResult UploadImg(string className)
        {
            string imgPath = "/Files/"+ className + "/";
            if (!Directory.Exists(HttpContext.Server.MapPath(imgPath)))
            {
                Directory.CreateDirectory(HttpContext.Server.MapPath(imgPath));
            }
            string fileUrl = "#";
            string fileName = string.Empty;
            if (Request.Files.Count > 0)
            {
                HttpPostedFileBase file = Request.Files[0];
                fileName = file.FileName;
                fileUrl = imgPath + fileName;
                file.SaveAs(Server.MapPath(fileUrl));
            }

            return Json(new { Code = "200", Message = "success", FileUrl = fileUrl, FileName = fileName, Status = true });
        }

        public ActionResult ImageIndex()
        {
            return View();
        }
    }
}