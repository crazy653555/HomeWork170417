using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HomeWork.Models;
using HomeWork.Controllers.ActionFilterAttribute;
using System.Web.Security;
using HomeWork.Models.ViewModels;

namespace HomeWork.Controllers
{
    public class 客戶資料Controller : Controller
    {
        //private 客戶資料Entities db = new 客戶資料Entities();
        客戶資料Repository repo客戶資料 = RepositoryHelper.Get客戶資料Repository();
        客戶清單Repository repo客戶清單;
        客戶聯絡人Repository repo客戶聯絡人;

        public 客戶資料Controller()
        {
            repo客戶清單 = RepositoryHelper.Get客戶清單Repository(repo客戶資料.UnitOfWork);
            repo客戶聯絡人 = RepositoryHelper.Get客戶聯絡人Repository(repo客戶資料.UnitOfWork);
        }
        public ActionResult 客戶清單()
        {
            return View(repo客戶清單.All());
        }

        [宣告客戶分類的SelectList物件]

        // GET: 客戶資料
        public ActionResult Index(客戶資料篩選條件ViewModel filter,升降冪排序ViewModel orderfilter)
        {
            var data = repo客戶資料.get客戶資料_包含篩選條件(filter);

            data = repo客戶資料.get客戶資料_升冪降冪排序排序(data, orderfilter);
           
            return View(data);
        }

        // GET: 客戶資料/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            客戶資料 客戶資料 = repo客戶資料.Find(id.Value);
            if (客戶資料 == null)
            {
                return HttpNotFound();
            }
            return View(客戶資料);
        }

        [HttpPost]
        public ActionResult BatchUpdateForContacts(int? id,List<客戶聯絡人批次更新ViewModle> data)
        {
            if (ModelState.IsValid)
            {
                foreach (var item in data)
                {
                    var c = repo客戶聯絡人.Find(item.Id);
                    if (c != null)
                    {
                        c.職稱 = item.職稱;
                        c.手機 = item.手機;
                        c.電話 = item.電話;
                    }
                    
                }
                repo客戶資料.UnitOfWork.Commit();

                return RedirectToAction("Details", new { id = id });
            }
               

            客戶資料 客戶資料 = repo客戶資料.Find(id.Value);
            if (客戶資料 == null)
            {
                return HttpNotFound();
            }
            return View("Details",客戶資料);
           
        }


        [宣告客戶分類的SelectList物件]
        // GET: 客戶資料/Create
        public ActionResult Create()
        {           
            return View();
        }

        // POST: 客戶資料/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        [宣告客戶分類的SelectList物件]
        public ActionResult Create([Bind(Include = "Id,客戶名稱,統一編號,電話,傳真,地址,Email,客戶分類,帳號,密碼")] 客戶資料 客戶資料)
        {
            if (ModelState.IsValid)
            {
                客戶資料.對密碼進行雜湊運算();
                repo客戶資料.Add(客戶資料);
                repo客戶資料.UnitOfWork.Commit();
                return RedirectToAction("Index");
            }

            return View(客戶資料);
        }

        // GET: 客戶資料/Edit/5
        [宣告客戶分類的SelectList物件]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            客戶資料 客戶資料 = repo客戶資料.Find(id.Value);
            if (客戶資料 == null)
            {
                return HttpNotFound();
            }

            客戶資料.密碼 = "";

            return View(客戶資料);
        }

        // POST: 客戶資料/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        [宣告客戶分類的SelectList物件]
        public ActionResult Edit(int id ,FormCollection form)
        {
            //[Bind(Include = "Id,客戶名稱,統一編號,電話,傳真,地址,Email")] 客戶資料 客戶資料

            客戶資料 客戶資料 = repo客戶資料.Find(id);
            
            if (客戶資料 == null)
            {
                return HttpNotFound();
            }

            var oldPW = 客戶資料.密碼;

            if (TryUpdateModel(客戶資料))
            {
                if (!string.IsNullOrEmpty(客戶資料.密碼))
                {
                    客戶資料.對密碼進行雜湊運算();
                }
                else
                {
                    客戶資料.密碼 = oldPW;
                }

                
                repo客戶資料.UnitOfWork.Commit();
                return RedirectToAction("Index");
            }
            return View(客戶資料);
        }

        // GET: 客戶資料/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            客戶資料 客戶資料 = repo客戶資料.Find(id.Value);
            if (客戶資料 == null)
            {
                return HttpNotFound();
            }
            return View(客戶資料);
        }

        // POST: 客戶資料/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            客戶資料 客戶資料 = repo客戶資料.Find(id);
            //db.客戶資料.Remove(客戶資料);
            客戶資料.是否已刪除 = true;

            repo客戶資料.UnitOfWork.Commit();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                repo客戶資料.UnitOfWork.Context.Dispose();                
            }
            base.Dispose(disposing);
        }
    }
}
