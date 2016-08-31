using BarcodeLib;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BarcodeLab.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public void Barcode(string sn = null)
        {
            ////http://localhost:56316/Home/Barcode?sn=19880621
            Response.ContentType = "image/gif";
            Barcode bc = new Barcode();
            bc.IncludeLabel = true;//顯示文字標籤
            bc.LabelFont = new Font("Verdana", 9f);//文字標籤字型、大小
            bc.Width = 300;//寬度
            bc.Height = 100;//高度
            Image img = bc.Encode(TYPE.CODE39, sn, bc.Width, bc.Height);//產生影像
            img.Save(Response.OutputStream, ImageFormat.Gif);
            Response.End();
        }
}
}