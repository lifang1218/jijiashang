using jjs.Models;
using jjs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace jjs.Controllers
{
    /// <summary>
    /// 前端模板控制器
    /// </summary>
    public class FrontBaseController : Controller
    {
        private JiJiaShangDB db = new JiJiaShangDB();
        public LayoutViewModel layoutViewModel;

        public JiJiaShangDB Db { get => db; }

        public FrontBaseController()
        {          
        }
     
    }
}