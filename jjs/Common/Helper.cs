using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace jjs.Common
{
    public static class Helper
    {
        public static HelperResult Upload(HttpPostedFileBase upload)
        {
            HelperResult helperResult = new HelperResult();
            string basePath = "\\source\\upload\\img\\{0}";
            if (upload == null)
            {
                helperResult.code = "100";// "alert('请先选择要上传的图片！')";
            }
            else
            {
                //获取文件类型
                string file = System.IO.Path.GetExtension(upload.FileName);
                string fileContentType = upload.ContentType.ToString();
                if (fileContentType == "image/bmp" || fileContentType == "image/gif" ||
                    fileContentType == "image/png" || fileContentType == "image/x-png" || fileContentType == "image/jpeg"
                    || fileContentType == "image/pjpeg")
                {
                    //当前时间
                    var now = DateTime.Now;
                    //随机数
                    Random ran = new Random();
                    int RandKey = ran.Next(1000, 9999);
                    //图片存放的大路径
                    string filePath = string.Format(basePath, now.ToString("yyyyMMdd"));
                    //图片存放的服务器本地路径
                    string localPath = System.Web.HttpContext.Current.Server.MapPath(filePath);
                    //图片存放的服务器本地路径 如果不存在 则新建文件夹
                    if (!System.IO.Directory.Exists(localPath))
                        System.IO.Directory.CreateDirectory(localPath);
                    if (upload.ContentLength <= 2097152)
                    {
                        //图片路径
                        var PicPath = string.Format("{0}\\{1}{2}{3}", filePath, now.ToString("hhmmss"), RandKey, file);
                        //保存图片
                        upload.SaveAs(System.Web.HttpContext.Current.Server.MapPath(PicPath));
                        string callback = System.Web.HttpContext.Current.Request["CKEditorFuncNum"];
                        //给编辑器返回路径
                        string url = PicPath.Replace("\\", "/");

                        helperResult.code = "666"; //"上传成功";
                        helperResult.url = url;
                    }
                    else
                    {
                        helperResult.code = "110";// "上传文件不能大于2M";
                    }
                }
            }
            return helperResult;
        }
    }

    public class HelperResult
    {
        public string code;
        public string url;
    }
}