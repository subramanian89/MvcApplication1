using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace MvcApplication1.Controllers
{
    public class NewImageController : ApiController
    {
        //
        // GET: /NewImage/

        
        [System.Web.Http.HttpGet]
        [OutputCache(CacheProfile = "CustomerImages")]
        public HttpResponseMessage instance(string id, string top, string bottom)
        {
            var path = string.Concat(@"C:\Users\Subramanian\Documents\Visual Studio 2012\Projects\MvcApplication1\MvcApplication1\Content\Images\", id, ".jpeg");
            using (var image = Image.FromFile(path))
            {
                using (Graphics g = Graphics.FromImage(image))
                {
                    // do something with the Graphics (eg. write "Hello World!") 

                    string text = top + " " + bottom;

                    // Create font and brush.
                    Font drawFont = new Font("Arial", 20);
                    SolidBrush drawBrush = new SolidBrush(Color.White);

                    // Create point for upper-left corner of drawing.
                    RectangleF toprect = new RectangleF(0, 0, image.Width, 50);
                    RectangleF bottomrect = new RectangleF(0, image.Height - 50, image.Width, 50);
                    StringFormat sf = new StringFormat();
                    sf.LineAlignment = StringAlignment.Center;
                    sf.Alignment = StringAlignment.Center;
                    g.DrawString(top, drawFont, drawBrush, toprect, sf);
                    g.DrawString(bottom, drawFont, drawBrush, bottomrect, sf);

                }
                MemoryStream ms = new MemoryStream();
                image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);

                var ofile = new HttpResponseMessage()
                {
                    Content = new System.Net.Http.ByteArrayContent(ms.ToArray())

                };

                return ofile;
            }
        }
    }
}
