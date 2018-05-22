using jjs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace jjs.Controllers
{
    public class IndexController : FrontBaseController
    {
        private JiJiaShangDB db = new JiJiaShangDB();
        // GET: Index
        public ActionResult Index()
        {
            LayoutViewModel masterModel = new LayoutViewModel(db);
            var dbArticleSet = db.ArticleContents;
            var dbDesignerSet = db.Designers;
            masterModel.rollPictures = dbArticleSet.Where(w => w.ACType == AcTypeEmun.ROLL.ToString().ToUpper())
                .OrderBy(o => new { o.ACSortNum, o.InDateTime }).ToList();

            masterModel.hotPackages = dbArticleSet.Where(w => w.ACType == AcTypeEmun.HOTPACKAGE.ToString().ToUpper())
                .Take(3).OrderBy(o => new { o.ACSortNum, o.InDateTime }).ToList();

            masterModel.classicCase = dbArticleSet.Where(w => w.ACType == AcTypeEmun.CLASSCASE.ToString().ToUpper())
                .Take(5).OrderBy(o => new { o.ACSortNum, o.InDateTime }).ToList();

            masterModel.groupBuilds = dbArticleSet.Where(w => w.ACType == AcTypeEmun.GROUPBUILD.ToString().ToUpper())
                .Take(4).OrderBy(o => new { o.ACSortNum, o.InDateTime }).OrderBy(o => o.ACSortNum).ToList();

            masterModel.homeDesigns = dbArticleSet.Where(w => w.ACType == AcTypeEmun.HOMEDESIGN.ToString().ToUpper())
                .Take(3).OrderBy(o => new { o.ACSortNum, o.InDateTime }).OrderBy(o => o.ACSortNum).ToList();

            masterModel.environmentalBuilds = dbArticleSet.Where(w => w.ACType == AcTypeEmun.ENVIRONMENTAL.ToString().ToUpper())
                .Take(3).OrderBy(o => new { o.ACSortNum, o.InDateTime }).ToList();

            masterModel.designers = dbDesignerSet.OrderBy(o => o.DSortNum).ToList();
            ViewBag.Title = "吉家尚首页";

            return View(masterModel);
        }
    }
}