using AutoMapper;
using HomeWork.Models;
using HomeWork.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HomeWork.Controllers
{
    public class 客戶專區Controller : Controller
    {
        客戶資料Repository repo客戶資料 = RepositoryHelper.Get客戶資料Repository();
        // GET: 客戶專區
        public ActionResult Index()
        {

            var data = repo客戶資料.Find(Convert.ToInt32(User.Identity.Name));

            Mapper.Initialize(cfg => cfg.CreateMap<客戶資料, 客戶專區_資料修改VM>());
            客戶專區_資料修改VM model = Mapper.Map<客戶專區_資料修改VM>(data);

            model.密碼 = "";
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(客戶專區_資料修改VM item)
        {
            if (ModelState.IsValid)
            {
                //取得目前入的使用者個人資料
                var data = repo客戶資料.Find(Convert.ToInt32(User.Identity.Name));

                Mapper.Initialize(cfg => cfg.CreateMap<客戶專區_資料修改VM, 客戶資料>());
                Mapper.Map(item, data, typeof(客戶專區_資料修改VM), typeof(客戶資料));

                if (!string.IsNullOrEmpty(data.密碼))
                {
                    data.對密碼進行雜湊運算();
                }

                repo客戶資料.UnitOfWork.Commit();
                return RedirectToAction("Index","客戶資料");
            }

            return View();
        }

    }
}