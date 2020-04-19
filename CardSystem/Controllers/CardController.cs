using CardSystem.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Windows.Media.Imaging;

namespace CardSystem.Controllers
{
    public class CardController : Controller
    {
        //Get cards
        public ActionResult Index()
        {
            return View();
        }

        // Generate Caard From Data
        // use barcodelib https://github.com/barnhill/barcodelib
        public ActionResult Generate()
        {
            var data = new CardData()
            {
                Id=1,
                Name="Test User",
                Image = "",
                Address = "20 Cairo",
                
            };

            BarcodeLib.Barcode b = new BarcodeLib.Barcode();
            data.Barcode = "data:image/png;base64," + GetBase64(b.Encode(BarcodeLib.TYPE.CODE39, "123456789"));
            return View(data);
        }

        public string GetBase64(Image image)
        {
            byte[] bytearray;
            bytearray = converterImageToByte(image);
            return Convert.ToBase64String(bytearray);
        }

        public static byte[] converterImageToByte(Image x)
        {
            ImageConverter _imageConverter = new ImageConverter();
            byte[] xByte = (byte[])_imageConverter.ConvertTo(x, typeof(byte[]));
            return xByte;
        }

        // search for Card 
        public ActionResult Search()
        {
            return View();
        }

        //post Search
        [HttpPost]
        public ActionResult Search(int? id)
        {
            // if found id go to data View
            if (id.HasValue)
            {
                return RedirectToAction(nameof(Data));
            }
            return View();
        }

        // get card data from search
        public ActionResult Data()
        {
            var data = new CardData()
            {
                Id = 1,
                Name = "Test User",
                Image = "",
                Address = "20 Cairo",

            };

            BarcodeLib.Barcode b = new BarcodeLib.Barcode();
            data.Barcode = "data:image/png;base64," + GetBase64(b.Encode(BarcodeLib.TYPE.CODE39, "123456789"));
            return View(data);
        }
    }
}