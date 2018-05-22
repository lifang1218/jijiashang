using jjs.Common;
using jjs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace jjs.Controllers
{
    public class ShowController : FrontBaseController
    {
        private JiJiaShangDB db = new JiJiaShangDB();

        // POST: MessageCreate/Create
        [HttpPost]
        public ActionResult MessageCreate(FormCollection collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string name = collection["Name"];
                    string phone = collection["Phone"];
                    string address = collection["Address"];
                    if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(phone) || string.IsNullOrEmpty(address))
                    {
                        return Content("姓名、电话、地址都必须填写！");
                    }
                    Message messageModel = new Message()
                    {
                        Name = name,
                        Phone = phone,
                        Address = address,
                        InDateTime = DateTime.Now,
                        EditDateTime = DateTime.Now
                    };

                    db.Messages.Add(messageModel);
                    db.SaveChanges();
                    return Content(" <script type=\"text/javascript\"> alert(\"留言完成\"); ", "text/html",
                System.Text.Encoding.UTF8);
                }
                return Content("");
            }
            catch (Exception ex)
            {
                return Content("出异常了，稍后重试！");
            }
        }

        //// GET: ShowItem
        //public ActionResult Index()
        //{
        //    string idstr = Request.QueryString["id"];
        //    int id = 0;
        //    if (idstr == null || !Int32.TryParse(idstr, out id))
        //    {
        //        return View("error");
        //    }

        //    LayoutViewModel masterModel = new LayoutViewModel(db);
        //    ArticleContent model = db.ArticleContents.Find(id);
        //    // 根据不同的类型可以把title改下
        //    AcTypeEmun typeEnum = (AcTypeEmun)Enum.Parse((typeof(AcTypeEmun)), model.ACType);
        //    string emumtext = RemarkAttribute.GetEnumRemark(typeEnum);
        //    ViewBag.Title = "吉家尚" + emumtext + "详情页";
        //    ViewBag.Content = model.AContent;
        //    masterModel.groupBuilds = db.ArticleContents
        //                                .Where(w => w.ACType == AcTypeEmun.GROUPBUILD.ToString().ToUpper())
        //                                .Take(4).OrderBy(o => new { o.ACSortNum, o.InDateTime })
        //                                .OrderBy(o => o.ACSortNum).ToList();

        //    return View(masterModel);
        //}

        /// <summary>
        /// 热门套餐，经典案例，团装，家居设计，环保装修详情页
        /// </summary>
        /// <returns></returns>
        public ActionResult ArticleContent()
        {
            string idstr = Request.QueryString["id"];
            int id = 0;
            if (idstr == null || !Int32.TryParse(idstr, out id))
            {
                return View("error");
            }

            ArticleContent model = db.ArticleContents.Find(id);
            if (model == null)
            {
                return View("error");
            }

            // 根据不同的类型可以把title改下
            AcTypeEmun typeEnum = (AcTypeEmun)Enum.Parse((typeof(AcTypeEmun)), model.ACType);
            string emumtext = RemarkAttribute.GetEnumRemark(typeEnum);
            ViewBag.Title = "吉家尚" + emumtext + "详情页";
            ViewBag.Content = model.AContent;

            LayoutViewModel masterModel = new LayoutViewModel(db);
            masterModel.groupBuilds = db.ArticleContents
                                        .Where(w => w.ACType == AcTypeEmun.GROUPBUILD.ToString().ToUpper())
                                        .Take(4).OrderBy(o => new { o.ACSortNum, o.InDateTime })
                                        .OrderBy(o => o.ACSortNum).ToList();


            return View(masterModel);
        }

        /// <summary>
        /// 经典案例
        /// </summary>
        /// <returns></returns>
        public ActionResult ClassCases()
        {
            // 根据不同的类型可以把title改下
            string emumtext = RemarkAttribute.GetEnumRemark(AcTypeEmun.CLASSCASE);
            ViewBag.Title = "吉家尚" + emumtext + "列表页";

            LayoutViewModel masterModel = new LayoutViewModel(db);
            masterModel.classicCase = db.ArticleContents
                                        .Where(w => w.ACType == AcTypeEmun.CLASSCASE.ToString().ToUpper())
                                        .OrderBy(o => new { o.ACSortNum, o.InDateTime })
                                        .OrderBy(o => o.ACSortNum).ToList();

            masterModel.groupBuilds = db.ArticleContents
                                           .Where(w => w.ACType == AcTypeEmun.GROUPBUILD.ToString().ToUpper())
                                           .Take(4).OrderBy(o => new { o.ACSortNum, o.InDateTime })
                                           .OrderBy(o => o.ACSortNum).ToList();

            return View(masterModel);
        }

        /// <summary>
        /// 所有设计者列表
        /// </summary>
        /// <returns></returns>
        public ActionResult Designers()
        {
            LayoutViewModel layoutViewModel = new LayoutViewModel(db);

            layoutViewModel.designers = db.Designers.ToList();
            layoutViewModel.groupBuilds = db.ArticleContents
                                            .Where(w => w.ACType == AcTypeEmun.GROUPBUILD.ToString().ToUpper())
                                            .Take(4).OrderBy(o => new { o.ACSortNum, o.InDateTime })
                                            .OrderBy(o => o.ACSortNum).ToList();

            ViewBag.Title = "吉家尚设计师团队";
            return View(layoutViewModel);

        }

        /// <summary>
        /// 设计师+案例
        /// </summary>
        /// <returns></returns>
        public ActionResult DesignerCase()
        {
            // 设计师编号
            string idstr = Request.QueryString["id"];
            int id = 0;
            if (idstr == null || !Int32.TryParse(idstr, out id))
            {
                return View("error");
            }

            LayoutViewModel layoutViewModel = new LayoutViewModel(db);
            layoutViewModel.designers = db.Designers.ToList();

            if (layoutViewModel.designers == null || layoutViewModel.designers.Count() == 0)
            {
                return View("error");
            }
            // 团装小区
            layoutViewModel.groupBuilds = db.ArticleContents
                                              .Where(w => w.ACType == AcTypeEmun.GROUPBUILD.ToString().ToUpper())
                                              .Take(4).OrderBy(o => new { o.ACSortNum, o.InDateTime })
                                              .OrderBy(o => o.ACSortNum).ToList();

            ViewBag.Title = "吉家尚设计师" + layoutViewModel.designers.First().DName + "案例";
            layoutViewModel.classicCase = db.ArticleContents.Where(w => w.DId == id).ToList();
            ViewBag.CaseNameList = string.Join("、", layoutViewModel.classicCase.Select(s => s.ACTitle));
            layoutViewModel.designers = db.Designers.Where(w => w.Id == id).ToList();
            return View(layoutViewModel);
        }
    }
}