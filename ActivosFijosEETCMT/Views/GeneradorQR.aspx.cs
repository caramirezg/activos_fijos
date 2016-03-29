using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Drawing.Imaging;

namespace ActivosFijosEETC.Views
{
    public partial class GeneradorQR : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            QRImage.Height = 300;
            QRImage.Width = 300;
            QRImage.ImageUrl = "~/Views/qr/qrmiteleferico.jpg";
        }
        /// <summary>
        /// Genera codigo qr
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
       
    }
}