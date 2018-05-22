using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using jjs.Common;

namespace jjs.Controllers
{
    public class ImageUploadController : Controller
    {


        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase upload)
        {
            var returnHelper = Helper.Upload(upload);
            string returnStr = returnHelper.code;
            if (returnStr == "666")
            {
                returnStr = "alert('上传成功！')";
            }
            else if (returnStr == "100")
            {
                returnStr = "alert('请先选择要上传的图片！')";
            }
            else if (returnStr == "110")
            {
                returnStr = "alert('上传文件不能大于2M！')";
            }
            return Content("<script type=\"text/javascript\">" + returnStr + "</script>",
                "text/html",
                System.Text.Encoding.UTF8);
        }
    }
}