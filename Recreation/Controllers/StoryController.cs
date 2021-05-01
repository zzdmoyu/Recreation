using Recreation.Models;
using Recreation.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Recreation.Controllers
{
    public class StoryController : Controller
    {
        /// <summary>
        /// 写入页面
        /// </summary>
        public ActionResult StoryIndex()
        {
            return View();
        }

        /// <summary>
        /// 列表页
        /// </summary>
        /// <returns></returns>
        public ActionResult StoryList()
        {
            return View();
        }

        /// <summary>
        /// 详情页
        /// </summary>
        /// <returns></returns>
        public ActionResult StoryInfo(string id)
        {
            StoryService service = new StoryService();
            var info = service.GetListById(id);
            return View(info);
        }

        //
        /// <summary>
        /// 编辑详情页
        /// </summary>
        /// <returns></returns>
        public ActionResult EditStoryInfo(string id)
        {
            StoryService service = new StoryService();
            var info = service.GetListById(id);
            return View(info);
        }


        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public ActionResult SaveStory(Story info)
        {
            info.StoryId = Guid.NewGuid().ToString();
            info.CreateDate = DateTime.Now;
            info.UpdateDate = DateTime.Now;
            StoryService service = new StoryService();
            service.Insert(info);
            return Json(new { Code = "200", Message = "success" });
        }

        public ActionResult EditStory(Story info)
        {
            info.UpdateDate = DateTime.Now;
            StoryService service = new StoryService();
            service.Update(info);
            return Json(new { Code = "200", Message = "success" });
        }

        public ActionResult GetStoryList()
        {
            StoryService service = new StoryService();
            var list = service.GetList().OrderBy(a=>a.IndexSort).ToList();
            return Json(new { Code = "200", infolist = list });
        }

    }
}