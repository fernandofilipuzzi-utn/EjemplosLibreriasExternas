using QRCoder;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Ej1_QR_Web
{
    public partial class _Default : Page
    {
        protected void Page_PreRender(object sender, EventArgs e)
        {
           
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
                /*
                System.Web.UI.WebControls.Image imgQR = this.Master.FindControl("MainContent").FindControl("imgQR") as System.Web.UI.WebControls.Image;
                if (imgQR != null)
                {
                    string base64Image = GenerarQR("valor de prueba");
                    imgQR.ImageUrl = "data:image/png;base64," + base64Image;
                }
                */

                string base64Image = GenerarQR("valor de prueba");
                imgQR.ImageUrl = "data:image/png;base64," + base64Image;
            }
        }

        private string GenerarQR(string data)
        {
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(data, QRCodeGenerator.ECCLevel.Q);
            
            Base64QRCode qrCode = new Base64QRCode(qrCodeData);
            string qrCodeImageAsBase64 = qrCode.GetGraphic(20, Color.Blue, Color.Transparent, true);
            return qrCodeImageAsBase64;
        }
    }
}