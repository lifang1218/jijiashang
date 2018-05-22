using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using jjs.Models;
using PagedList;

namespace jjs.Controllers
{
    public class MessagesController : Controller
    {
        private JiJiaShangDB db = new JiJiaShangDB();

        int pageSize = 10;

        // GET: Messages
        public ActionResult Index(int pageIndex = 1)
        {
            return View(db.Messages.OrderBy(o => o.InDateTime).ToPagedList(pageIndex, pageSize));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="disposing"></param>
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
