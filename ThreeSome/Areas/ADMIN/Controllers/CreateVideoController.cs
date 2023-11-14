using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ThreeSome.Models;

namespace ThreeSome.Areas.ADMIN.Controllers
{
    public class CreateVideoController : Controller
    {
        WEBEntitiesEntities db = new WEBEntitiesEntities();
        // GET: ADMIN/CreateVideo
        [HttpPost]
        public ActionResult SaveVideo(HttpPostedFileBase file)
        {
            if (file != null && file.ContentLength > 0)
            {
                // Lấy đường dẫn thư mục lưu trữ video trong dự án
                string uploadPath = Server.MapPath("~/Videos/");

                // Đảm bảo thư mục lưu trữ video tồn tại
                if (!Directory.Exists(uploadPath))
                {
                    Directory.CreateDirectory(uploadPath);
                }

                // Lưu tệp vào thư mục lưu trữ
                string filePath = Path.Combine(uploadPath, file.FileName);
                file.SaveAs(filePath);

                // Xử lý thành công, có thể thực hiện các hành động tiếp theo
                return RedirectToAction("Index");
            }

            // Xử lý lỗi hoặc không có tệp được chọn
            return RedirectToAction("Error");
        }
    }
}