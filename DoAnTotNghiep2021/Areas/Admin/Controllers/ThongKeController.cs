using Model.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList.Mvc;
using Model.ThongKe;
using System.Text;
using OfficeOpenXml;

namespace DoAnTotNghiep2021.Areas.Admin.Controllers
{
    public class ThongKeController : BaseController
    {
        // GET: Admin/ThongKe
        [HasCredential(RoleID = "THONGKE")]
        public ActionResult ThongKeDonHang(int page = 1 , int pagesize =10)
        {
            var dao = new DonHangDao();
            var model = dao.ListAllPaging(page, pagesize);
            return View(model);
        }
        [HasCredential(RoleID = "THONGKE")]
        public ActionResult ThongKeLuongHang( string searChing,int page = 1, int pagesize = 10)
        {
            var product = new ProductDao();
            var model = product.ListAllPaging(searChing,page, pagesize);
            return View(model);
        }
        //[HasCredential(RoleID = "THONGKE")]
        public ActionResult ThongKeTheoNgay(string month,string date, int page =1 , int pagesize =20)
        {
            var thongke = new ThongKeDao();
            var model = thongke.ListThongKe(month,date,page,pagesize);
            ViewBag.SearchString = date;
            return View(model);
        }
        public ActionResult ThongKeTheoThang(DateTime date , DateTime todate, int page=1 , int pagesize=10)
        {
            return View();
        }

        public void ExportToExcel(string month, string date, int page = 1, int pagesize = 20)
        {
            var thongke = new ThongKeDao();
            var model = thongke.ListThongKe(month, date, page, pagesize);
            ViewBag.SearchString = date;
            ExcelPackage.LicenseContext = LicenseContext.Commercial;
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            ExcelPackage pck = new ExcelPackage();
            ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Report");

            ws.Cells["A1"].Value = "Báo cao doanh thu";
            ws.Cells["B1"].Value = "Nông Sản Thanh Hà";

            ws.Cells["A2"].Value = "Report";
            ws.Cells["B2"].Value = "Báo cáo doanh thu";

            ws.Cells["A3"].Value = "Date";
            ws.Cells["B3"].Value = string.Format("{0:dd MMMM yyyy} at {0:H: mm tt }", DateTimeOffset.Now);

            ws.Cells["A6"].Value = "Mã đơn hàng";
            ws.Cells["B6"].Value = "Mã sản phẩm";
            ws.Cells["C6"].Value = "Số lượng";
            ws.Cells["D6"].Value = "Đơn giá";
            ws.Cells["E6"].Value = "Ngày đặt";
            ws.Cells["F6"].Value = "Đã xác nhận";
            ws.Cells["G6"].Value = "Đã giao xong";

            int rowStart = 7;
            foreach (var item in model)
            {
                ws.Cells[string.Format("A{0}", rowStart)].Value = item.DonHangID;
                ws.Cells[string.Format("B{0}", rowStart)].Value = item.ProductID;
                ws.Cells[string.Format("C{0}", rowStart)].Value = item.SoLuong;
                ws.Cells[string.Format("D{0}", rowStart)].Value = item.Gia;
                ws.Cells[string.Format("E{0}", rowStart)].Value = item.CreateDate;
                ws.Cells[string.Format("F{0}", rowStart)].Value = item.DaXacNhan;
                ws.Cells[string.Format("G{0}", rowStart)].Value = item.DaGiaoXong;
                rowStart++;
            }
            ws.Cells["A:AZ"].AutoFitColumns();
            Response.Clear();
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.AddHeader("content-disposition", "attachment: filename=" + "ExcelReport.xlsx");
            Response.BinaryWrite(pck.GetAsByteArray());
            Response.End();

        }

    }
}