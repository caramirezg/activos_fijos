using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Drawing.Imaging;
using System.Drawing;

using System.Drawing.Drawing2D;


namespace ActivosFijosEETC.Views
{
    public partial class GeneradorCodigoBarras : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Image2.ImageUrl = "~/Views/barcode/barcodemiteleferico.gif";
        }


     
   }
}