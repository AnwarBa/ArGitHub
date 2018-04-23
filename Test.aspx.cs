using System;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.IO;
using System.Drawing;
using System.Diagnostics;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using CrystalDecisions.Web;
using Aanchal_RIMS.AppCode.BE;
using Aanchal_RIMS.AppCode.BL;
using System.Text;


namespace Aanchal_RIMS
{
    public partial class Test : System.Web.UI.Page
    {
        BE_Class BE = new BE_Class();
        BL_Class BL = new BL_Class();
        DataSet ds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack==true)
            {
                if (Request.QueryString["Product_Code"]!=null)
                {
                    BE.Product_Code = Request.QueryString["Product_Code"];
                    Session["Image1"] = "images/" + BE.Product_Code + ".png";
                    byte[] bytImage = File.ReadAllBytes(Server.MapPath(Session["Image1"].ToString()));
                    BE.BarCode_Pic = bytImage;
                    BE.flag = BL.Exe_UpdateBarCode(BE);
                    Response.Redirect("~/BarCode.aspx?Product_Code=" + BE.Product_Code);
                }
            }

        }
    }
}