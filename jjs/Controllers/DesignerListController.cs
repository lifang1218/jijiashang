using jjs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace jjs.Controllers
{
    /// <summary>
    /// 前台的设计师列表页
    /// </summary>
    public class DesignerListController : FrontBaseController
    {
        private JiJiaShangDB db = new JiJiaShangDB();
        // GET: Index
        public ActionResult Index()
        {
            LayoutViewModel masterModel = new LayoutViewModel(db);
            masterModel.groupBuilds = db.ArticleContents
                                        .Where(w => w.ACType == AcTypeEmun.GROUPBUILD.ToString().ToUpper())
                                        .Take(4).OrderBy(o => new { o.ACSortNum, o.InDateTime })
                                        .OrderBy(o => o.ACSortNum).ToList();
            masterModel.designers = db.Designers.OrderBy(o => o.DSortNum).ToList();
            return View(masterModel);
        }
    }
}