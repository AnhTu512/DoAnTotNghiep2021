using Model.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList.Mvc;

namespace DoAnTotNghiep2021.Areas.Admin.Controllers
{
    public class FeedbackController : BaseController
    {
        // GET: Admin/Feedback
        public ActionResult Index(int page = 1, int pagesize = 10)
        {
            var dao = new LienHeDao();
            var model = dao.ListAllPaging(page, pagesize);
            return View(model);
        }
    }
}