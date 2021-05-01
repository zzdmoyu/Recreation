using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViewDemo.Services;

namespace Recreation.Controllers
{
    public class VideoController : Controller
    {
        /// <summary>
        /// 主页面
        /// </summary>
        public ActionResult VideoIndex()
        {
            return View();
        }

        public ActionResult GetDirList(string path)
        {
            FileService service = new FileService();
            var list = service.GetPath(path, 0);
            return Json(new { Code = "200", Infolist = list });
        }
    }
}