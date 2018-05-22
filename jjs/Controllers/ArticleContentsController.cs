using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using jjs.Common;
using jjs.Models;

namespace jjs.Views
{
    public class ArticleContentsController : Controller
    {
        private JiJiaShangDB db = new JiJiaShangDB();

        // GET: ArticleContents
        public ActionResult Index()
        {
            string typestr = Request.QueryString["type"];
            int type = 0;
            if (typestr == null || !Int32.TryParse(typestr, out type) || !Enum.IsDefined(typeof(AcTypeEmun), type))
            {
                return View("error");
            }
            if (type.Equals("0"))
            {
                return View("error");
            }
            ViewBag.TypeText = RemarkAttribute.GetEnumRemark((AcTypeEmun)type);
            ViewBag.TypeNum = type;
            var list = new List<ArticleContent>();
            string pagenum = "_";
            AcTypeEmun typeEnum = (AcTypeEmun)type;
            string enumText = RemarkAttribute.GetEnumRemark(typeEnum);
            if (typeEnum == AcTypeEmun.GROUPBUILD || typeEnum == AcTypeEmun.HOMEDESIGN || typeEnum == AcTypeEmun.ENVIRONMENTAL)
            {
                pagenum += "4";
            }
            else
            {
                pagenum += type.ToString();
            }

            if (!db.ArticleContents.Any())
            {
                return View("Index" + pagenum, list);
            }

            list = db.ArticleContents
               .Where(w => w.ACType == ((AcTypeEmun)type).ToString())
               .OrderBy(o => new { o.ACSortNum, o.InDateTime })
               .ToList();

            if (list.Any())
            {
                list.ForEach(f => { f.ACType = enumText; });
            }
           

            return View("Index" + pagenum, list);
        }

        // GET: ArticleContents/Details/5
        public ActionResult Details()
        {
            string idnum = Request.QueryString["id"];
            int id = 0;
            if (!Int32.TryParse(idnum, out id))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ArticleContent articleContent = db.ArticleContents.Find(id);
            if (articleContent == null)
            {
                return HttpNotFound();
            }

            AcTypeEmun typeEnum = AcTypeEmun.ROLL;
            typeEnum = (AcTypeEmun)Enum.Parse((typeof(AcTypeEmun)), articleContent.ACType);
            string emumtext = RemarkAttribute.GetEnumRemark(typeEnum);
            ViewBag.TypeText = emumtext;
            ViewBag.TypeNum = (int)typeEnum;
            ViewBag.Content = articleContent.AContent;
            articleContent.ACType = emumtext;

            string pagenum = "_";
            if (typeEnum == AcTypeEmun.GROUPBUILD || typeEnum == AcTypeEmun.HOMEDESIGN || typeEnum == AcTypeEmun.ENVIRONMENTAL)
            {
                pagenum += "4";
            }
            else
            {
                pagenum += ((int)typeEnum).ToString();
            }

            if (typeEnum == AcTypeEmun.CLASSCASE)
            {
                foreach (var item in db.Designers)
                {
                    if (articleContent.DId == item.Id)
                    {
                        ViewBag.DesignerName = item.DName + "_" + item.DUniversity + "_" + item.DDepartment;
                    }
                }
            }
            return View("Details" + pagenum, articleContent);
        }

        // GET: ArticleContents/Create
        [ValidateInput(false)]
        public ActionResult Create()
        {
            string typestr = Request.QueryString["type"];
            int type = 0;
            if (typestr == null || !Int32.TryParse(typestr, out type) || !Enum.IsDefined(typeof(AcTypeEmun), type))
            {
                return View("error");
            }
            if (type.Equals("0"))
            {
                return View("error");
            }
            ViewBag.TypeText = RemarkAttribute.GetEnumRemark((AcTypeEmun)type);
            ViewBag.TypeNum = type;

            string pagenum = "_";
            if (type == (int)AcTypeEmun.GROUPBUILD ||
                type == (int)AcTypeEmun.HOMEDESIGN ||
                type == (int)AcTypeEmun.ENVIRONMENTAL)
            {
                pagenum += "4";
            }
            else
            {
                pagenum += type.ToString();
            }
            int designerListCount = 0;
            List<SelectListItem> designerList = new List<SelectListItem>();
            if (type == (int)AcTypeEmun.CLASSCASE)
            {
                foreach (var item in db.Designers)
                {
                    designerList.Add(new SelectListItem()
                    {
                        Text = item.DName + "_" + item.DUniversity + "_" + item.DDepartment,
                        Value = item.Id.ToString()
                    });
                }

                designerListCount = db.Designers.Count();
            }
            ViewData["DesignerList"] = designerList;
            ViewBag.DesignerListCount = designerListCount;
            return View("Create" + pagenum);
        }

        // POST: ArticleContents/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create([Bind(Include = "Id,ACPhoto,ACTitle,ACSortNum,DId,AContent,ACEpitome,ACLink,ACType,InDateTime,EditDateTime,InUserName,EditUserName")] ArticleContent articleContent
            , HttpPostedFileBase file)
        {
            string typestr = Request.QueryString["type"];
            int type = 0;
            if (typestr == null || !Int32.TryParse(typestr, out type) || !Enum.IsDefined(typeof(AcTypeEmun), type))
            {
                return View("error");
            }
            if (type.Equals("0"))
            {
                return View("error");
            }

            ViewBag.TypeNum = type;
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    var uploadResult = Helper.Upload(file);
                    if (uploadResult.code == "666")
                    {
                        articleContent.ACPhoto = uploadResult.url;
                    }
                    else
                    {
                        return Content("上传异常 ！", "text/plain");
                    }
                }

                articleContent.ACType = ((AcTypeEmun)type).ToString();
                articleContent.InDateTime = DateTime.Now;
                articleContent.EditDateTime = DateTime.Now;
                db.ArticleContents.Add(articleContent);
                db.Configuration.ValidateOnSaveEnabled = false;
                db.SaveChanges();
                db.Configuration.ValidateOnSaveEnabled = true;
                return RedirectToAction("Index", new { type = type });
            }
            string pagenum = "_";
            if (type == (int)AcTypeEmun.GROUPBUILD ||
                type == (int)AcTypeEmun.HOMEDESIGN ||
                type == (int)AcTypeEmun.ENVIRONMENTAL)
            {
                pagenum += "4";
            }
            else
            {
                pagenum += type.ToString();
            }

            return View("Create" + pagenum);
        }

        // GET: ArticleContents/Edit/5
        public ActionResult Edit()
        {
            string idnum = Request.QueryString["id"];
            int id = 0;
            if (idnum == null || !Int32.TryParse(idnum, out id))
            {
                return View("error");
            }
            if (id.Equals("0"))
            {
                return View("error");
            }

            ArticleContent articleContent = db.ArticleContents.Find(id);
            if (articleContent == null)
            {
                return HttpNotFound();
            }
            string typestr = Request.QueryString["type"];
            int type = 0;
            if (typestr == null || !Int32.TryParse(typestr, out type) || !Enum.IsDefined(typeof(AcTypeEmun), type))
            {
                return View("error");
            }
            ViewBag.TypeText = RemarkAttribute.GetEnumRemark((AcTypeEmun)type);
            ViewBag.TypeNum = type;
            ViewBag.TypeEmnu = (AcTypeEmun)type;
            string pagenum = "_";
            if (type == (int)AcTypeEmun.GROUPBUILD ||
                type == (int)AcTypeEmun.HOMEDESIGN ||
                type == (int)AcTypeEmun.ENVIRONMENTAL)
            {
                pagenum += "4";
            }
            else
            {
                pagenum += type.ToString();
            }
            int designerListCount = 0;
            List<SelectListItem> designerList = new List<SelectListItem>();
            if (type == (int)AcTypeEmun.CLASSCASE)
            {
                foreach (var item in db.Designers)
                {
                    SelectListItem selectList = new SelectListItem();
                    if (articleContent.DId == item.Id)
                    {
                        selectList = new SelectListItem() { Text = item.DName + "_" + item.DUniversity + "_" + item.DDepartment, Value = item.Id.ToString(), Selected = true };
                    }
                    else
                    {
                        selectList = new SelectListItem() { Text = item.DName + "_" + item.DUniversity + "_" + item.DDepartment, Value = item.Id.ToString() };
                    }
                    designerList.Add(selectList);
                }

                designerListCount = db.Designers.Count();
            }
            ViewData["DesignerList"] = designerList;
            ViewBag.DesignerListCount = designerListCount;

            return View("Edit" + pagenum, articleContent);
        }

        // POST: ArticleContents/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ACPhoto,ACTitle,ACSortNum,DId,AContent,ACEpitome,ACLink,ACType,InDateTime,EditDateTime,InUserName,EditUserName")] ArticleContent articleContent
                        , HttpPostedFileBase ACPhoto)
        {
            string typestr = Request.QueryString["type"];
            int type = 0;
            if (typestr == null || !Int32.TryParse(typestr, out type) || !Enum.IsDefined(typeof(AcTypeEmun), type))
            {
                return View("error");
            }
            if (ModelState.IsValid)
            {
                if (type != (int)AcTypeEmun.OTHER)
                {
                    if (ACPhoto != null)
                    {
                        var uploadResult = Helper.Upload(ACPhoto);
                        if (uploadResult.code == "666")
                        {
                            articleContent.ACPhoto = uploadResult.url;
                        }
                        else
                        {
                            return Content("上传异常 ！", "text/plain");
                        }
                    }
                    else
                    {
                        articleContent.ACPhoto = Request.QueryString["oldphone"].ToString();
                    }
                }
                articleContent.ACType = ((AcTypeEmun)type).ToString();
                articleContent.EditDateTime = DateTime.Now;
                db.Entry(articleContent).State = EntityState.Modified;
                db.Configuration.ValidateOnSaveEnabled = false;
                db.SaveChanges();
                db.Configuration.ValidateOnSaveEnabled = true;

                return RedirectToAction("Index", new { type = (int)Enum.Parse(typeof(AcTypeEmun), articleContent.ACType) });
            }

            string pagenum = "_";
            if (type == (int)AcTypeEmun.GROUPBUILD ||
                type == (int)AcTypeEmun.HOMEDESIGN ||
                type == (int)AcTypeEmun.ENVIRONMENTAL)
            {
                pagenum += "4";
            }
            else
            {
                pagenum += type.ToString();
            }
            return View("Index" + pagenum);
        }

        // GET: ArticleContents/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArticleContent articleContent = db.ArticleContents.Find(id);
            if (articleContent == null)
            {
                return HttpNotFound();
            }

            ViewBag.TypeText = RemarkAttribute.GetEnumRemark((AcTypeEmun)Enum.Parse(typeof(AcTypeEmun), articleContent.ACType));
            int type = (int)Enum.Parse(typeof(AcTypeEmun), articleContent.ACType);
            ViewBag.TypeNum = type;
            ViewBag.TypeEmnu = articleContent.ACType.ToString();
            string pagenum = "_";
            if (type == (int)AcTypeEmun.GROUPBUILD ||
                type == (int)AcTypeEmun.HOMEDESIGN ||
                type == (int)AcTypeEmun.ENVIRONMENTAL)
            {
                pagenum += "4";
            }
            else
            {
                pagenum += type.ToString();
            }

            if (type == (int)AcTypeEmun.CLASSCASE)
            {
                foreach (var item in db.Designers)
                {
                    if (articleContent.DId == item.Id)
                    {
                        ViewBag.DesignerName = item.DName + "_" + item.DUniversity + "_" + item.DDepartment;
                    }
                }
            }

            return View("Delete" + pagenum, articleContent);
        }

        // POST: ArticleContents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ArticleContent articleContent = db.ArticleContents.Find(id);
            db.ArticleContents.Remove(articleContent);
            db.SaveChanges();
            int type = (int)Enum.Parse(typeof(AcTypeEmun), articleContent.ACType);
            return RedirectToAction("Index", new { type = type });
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
