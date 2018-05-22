using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using jjs.Models;
using jjs.Common;

namespace jjs.Controllers
{
    /// <summary>
    /// 后台的设计师增删改查
    /// </summary>
    public class DesignersController : Controller
    {
        private JiJiaShangDB db = new JiJiaShangDB();

        // GET: Designers
        public ActionResult Index()
        {
            // return View(await db.Designers.ToListAsync());
            return View(db.Designers);
        }

        // GET: Designers/Details/5  
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Designer designer = db.Designers.Find(id);
            if (designer == null)
            {
                return HttpNotFound();
            }
            return View(designer);
        }

        // GET: Designers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Designers/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,DName,DPhoto,DUniversity,DIdea,DDepartment,DExtend,DSortNum,InDateTime,EditDateTime,InUserName,EditUserName")] Designer designer
            , HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                var uploadResult = Helper.Upload(file);
                if (uploadResult.code == "666")
                {
                    designer.DPhoto = uploadResult.url;
                    designer.InDateTime = DateTime.Now;
                    designer.EditDateTime = DateTime.Now;
                    db.Designers.Add(designer);
                    db.Configuration.ValidateOnSaveEnabled = false;
                    db.SaveChanges();
                    db.Configuration.ValidateOnSaveEnabled = true;
                    return RedirectToAction("Index");
                }
                else
                {
                    return Content("上传异常 ！", "text/plain");
                }
            }

            return View(designer);
        }

        // GET: Designers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Designer designer = db.Designers.Find(id);
            if (designer == null)
            {
                return HttpNotFound();
            }
            return View(designer);
        }

        // POST: Designers/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,DName,DPhoto,DUniversity,DIdea,DDepartment,DExtend,DSortNum,InDateTime,EditDateTime,InUserName,EditUserName")] Designer designer
            , HttpPostedFileBase DPhoto)
        {
            if (ModelState.IsValid)
            {
                if (DPhoto != null)
                {
                    var uploadResult = Helper.Upload(DPhoto);
                    if (uploadResult.code == "666")
                    {
                        designer.DPhoto = uploadResult.url;
                    }
                    else
                    {
                        return Content("上传异常 ！", "text/plain");
                    }
                }
                else
                {
                    designer.DPhoto = Request.QueryString["oldphone"].ToString();
                }
                designer.EditDateTime = DateTime.Now;
                db.Designers.Add(designer);
                db.Entry(designer).State = EntityState.Modified;
                db.Configuration.ValidateOnSaveEnabled = false;
                db.SaveChanges();
                db.Configuration.ValidateOnSaveEnabled = true;
                return RedirectToAction("Index");
            }
            return View(designer);
        }


        // GET: Designers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Designer designer = db.Designers.Find(id);
            if (designer == null)
            {
                return HttpNotFound();
            }
            return View(designer);
        }

        // POST: Designers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Designer designer = db.Designers.Find(id);
            db.Designers.Remove(designer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
