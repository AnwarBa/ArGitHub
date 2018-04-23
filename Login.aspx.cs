using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Aanchal_RIMS.AppCode.BE;
using Aanchal_RIMS.AppCode.BL;
using Aanchal_RIMS.AppCode.DA;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace Aanchal_RIMS
{
    public partial class Login : System.Web.UI.Page
    {
        BE_Class BE = new BE_Class();
        BL_Class BL = new BL_Class();
        DataSet ds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack == true) { }
        }

        protected void btn_login_Click(object sender, EventArgs e)
        {
            BE.UserName = txt_Username.Text.Trim();
            BE.UserPassword = txt_pwd.Text.Trim();
            ds = BL.select_Student_login(BE);
            if (ds.Tables[0].Rows.Count == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Alert", "alert('Invalid Userid or Password.');", true);
            }
            else
            {
                BE.UserName = ds.Tables[0].Rows[0]["UserName"].ToString();
                BE.ID = Convert.ToInt32(ds.Tables[0].Rows[0]["ID"]);
                Session["User"] = BE.UserName;
                Session["ID"] = BE.ID;
                Response.Redirect("~/Account/Home.aspx");
            }
        }

        protected void btn_cancal_Click(object sender, EventArgs e)
        {

        }

    }
}