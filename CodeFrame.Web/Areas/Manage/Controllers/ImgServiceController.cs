using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;

namespace CodeFrame.Web.Areas.Manage.Controllers
{

    [Produces("application/json")]
    [Route("api/ImgService")]
    public class ImgServiceController : Controller
    {
        private readonly IHostingEnvironment _hostingEnv;

        public ImgServiceController(IHostingEnvironment env)
        {
            this._hostingEnv = env;
        }

        public ActionResult LayerUpload()
        {
            #region 文件上传
            var imgFile = Request.Form.Files[0];
            if (imgFile != null && !string.IsNullOrEmpty(imgFile.FileName))
            {
                long size = 0;
                string tempname = "";
                var filename = ContentDispositionHeaderValue
                    .Parse(imgFile.ContentDisposition)
                    .FileName.Value.Trim('"');
                var extname = filename.Substring(filename.LastIndexOf('.'), filename.Length - filename.LastIndexOf('.'));
                var filename1 = System.Guid.NewGuid().ToString().Substring(0, 6) + extname;
                tempname = filename1;
                var path = _hostingEnv.WebRootPath;
                string dir = DateTime.Now.ToString("yyyyMMdd");
                if (!System.IO.Directory.Exists(_hostingEnv.WebRootPath + $@"\upload\{dir}"))
                {
                    System.IO.Directory.CreateDirectory(_hostingEnv.WebRootPath + $@"\upload\{dir}");
                }
                filename = _hostingEnv.WebRootPath + $@"\upload\{dir}\{filename1}";
                size += imgFile.Length;
                using (FileStream fs = System.IO.File.Create(filename))
                {
                    imgFile.CopyTo(fs);
                    fs.Flush();
                }
                return Json(new { code = 0, msg = "上传成功", data = new { src = $"/upload/{dir}/{filename1}", title = "图片标题" } });
            }
            return Json(new { code = 1, msg = "上传失败", });
            #endregion

            //{
            //    "code": 0
            //        ,"msg": ""
            //        ,"data": {
            //        "src": "http://cdn.layui.com/123.jpg"
            //    }
            //}
        }

    }
}