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
using System.Diagnostics;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using CrystalDecisions.Web;
using Aanchal_RIMS.AppCode.BE;
using Aanchal_RIMS.AppCode.BL;
using System.Text;
using System.Drawing.Design;
using System.Drawing.Imaging;





namespace BarCode
{
    public partial class BarCode : System.Web.UI.Page
    {
        BE_Class BE = new BE_Class();
        BL_Class BL = new BL_Class();
        DataSet ds = new DataSet();
        ReportDocument rep = new ReportDocument();
        string value2, value1;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack == true)
            {
                Bind_item();
                BindArea();
                txt_CGST.Text = "0";
                txt_SGst.Text = "0";
                txt_discountRs.Text = "0";
                txt_HCode.Text = "0";
                if (Request.QueryString["Product_Code"] != null)
                {

                }
            }
        }

        #region Methods
        public void Bind_item()
        {
            ddl_Item.Items.Clear();
            ds = BL.Exec_Bind_Item();
            ddl_Item.DataSource = ds;
            ddl_Item.DataValueField = "Item_id";
            ddl_Item.DataTextField = "Item_Name";
            ddl_Item.DataBind();
            ddl_Item.Items.Insert(0, new ListItem("Select", "0"));
        }
        public void Bind_Subitem()
        {
            BE.Item_ID = ddl_Item.SelectedValue;
            ds = BL.Exe_Bind_SubItem(BE);
            ddl_SubItem.DataSource = ds;
            ddl_SubItem.DataValueField = "SubItem_id";
            ddl_SubItem.DataTextField = "SubItem_Name";
            ddl_SubItem.DataBind();
            ddl_SubItem.Items.Insert(0, new ListItem("Select", "0"));
        }
        public void SetData()
        {
            BE.Area_Code = ddl_area.SelectedValue;
            BE.Supplier_ID = ddl_supplier.SelectedValue;
            BE.Product_Code = txt_PID.Text;
            BE.Product_Name = txt_pname.Text;
            BE.Item_ID = ddl_Item.SelectedValue;
            BE.SubItem_ID = ddl_SubItem.SelectedValue;
            BE.Purchase_Price = Convert.ToDouble(txt_pprice.Text);
            BE.Sales_Price = Convert.ToDouble(txt_sprice.Text);

            BE.C_Gst = Convert.ToDouble(txt_CGST.Text);
            BE.S_Gst = Convert.ToDouble(txt_SGst.Text);
            BE.HSN_Code = txt_HCode.Text;
            BE.Discount_Rs = Convert.ToDouble(txt_discountRs.Text);

            BE.Quantity = Convert.ToInt32(txt_quantity.Text);
            if (txt_productdate.Text == "")
            { BE.Product_Date = Convert.ToDateTime("01/01/1900"); }
            else
            {
                string[] Reg_Date1;
                Reg_Date1 = txt_productdate.Text.Split('/');
                BE.Product_Date = Convert.ToDateTime(Reg_Date1[1].ToString() + "/" + Reg_Date1[0].ToString() + "/" + Reg_Date1[2].ToString()).Date;
            }

            BE.Vocher_No = txt_vocharno.Text;
            BE.Delete_Status = "N";
            BE.Created_User = Session["User"].ToString();
            BE.Branch_ID = "1";
            byte[] imgByte = (byte[])ViewState["photo"];
            BE.Item_Pic = imgByte;
            BE.Item_PicName = ViewState["photo_Name"].ToString();

            BE.BarCode_PicName = "";
            if (Session["Image1"] != null)
            {
                byte[] bytImage = File.ReadAllBytes(Server.MapPath(Session["Image1"].ToString()));
                BE.BarCode_Pic = bytImage;
            }
            else { BE.BarCode_Pic = (byte[])ViewState["Image1"]; }
        }
        private void GenerateID()
        {
            BE.Area_Code = ddl_area.SelectedValue;
            BE.Supplier_ID = ddl_supplier.SelectedValue;
            ds = BL.Exe_Generate_ProductEntry(BE);
            int id = Convert.ToInt32(ds.Tables[0].Rows[0]["TCOUNT"]);
            int value = id + 1;
            if (value == 0)
            {
                value2 = "1000";

            }
            else
            {
                string str = value.ToString();
                value1 = str;
                switch ((value1.ToString().Length))
                {
                    case 1:
                        value2 = "100" + value1.ToString();
                        value1 = value2;
                        break;
                    case 2:
                        value2 = "10" + value1.ToString();
                        value1 = value2;
                        break;
                    case 3:
                        value2 = value1.ToString();
                        value1 = value2;
                        break;
                }

            }
            txt_PID.Text = value1;
        }
        private void Bind_Grid()
        {
            BE.Area_Code = ddl_area.SelectedValue;
            BE.Supplier_ID = ddl_supplier.SelectedValue;
            ds = BL.Exe_Selete_ProductEntry(BE);
            gv_productentry.DataSource = ds;
            gv_productentry.DataBind();
        }
        private void BindArea()
        {
            try
            {
                ds = BL.Exe_GridFill_Area(BE);
                ddl_area.Items.Clear();
                ddl_area.DataSource = ds;
                ddl_area.DataTextField = "Area_Name";
                ddl_area.DataValueField = "Area_Code";
                ddl_area.DataBind();
                ddl_area.Items.Insert(0, new ListItem("Select", "0"));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void BindSupplier()
        {
            try
            {
                BE.Area_Code = ddl_area.SelectedValue.Trim();
                ds = BL.Exec_Fill_M_Supplier(BE);
                ddl_supplier.Items.Clear();
                ddl_supplier.DataSource = ds;
                ddl_supplier.DataTextField = "Supplier_Name";
                ddl_supplier.DataValueField = "Supplier_ID";
                ddl_supplier.DataBind();
                ddl_supplier.Items.Insert(0, new ListItem("Select", "0"));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void PhotoUpload()
        {
            if (file_image.HasFile)
            {
                if ((file_image.PostedFile != null) && (file_image.PostedFile.ContentLength < 102500))
                {
                    //file_image =Server.MapPath("~/PictureUploads/whatever2.png");
                    Stream fs = file_image.PostedFile.InputStream;
                    BE.Item_PicName = Path.GetFileName(file_image.PostedFile.FileName);
                    ViewState["photo_Name"] = BE.Item_PicName;
                    BinaryReader br = new BinaryReader(fs);
                    BE.Item_Pic = br.ReadBytes((Int32)fs.Length);
                    ViewState["photo"] = BE.Item_Pic;
                    string base64String = Convert.ToBase64String(BE.Item_Pic, 0, BE.Item_Pic.Length);
                    SImage.ImageUrl = "data:image/jpeg;base64," + base64String;
                }
                else
                {
                    if (ViewState["photo"] == null)
                    {
                        BE.Item_PicName = "";
                        BE.Item_Pic = new byte[0];
                    }
                    else
                    {
                        byte[] imgByte = (byte[])ViewState["photo"];
                        BE.Item_Pic = imgByte;
                        BE.Item_PicName = ViewState["photo_Name"].ToString();
                    }
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Alert", "alert('Please insert image size below 50KB.');", true);
                }
            }
            else
            {
                if (ViewState["photo"] == null)
                {
                    BE.Item_PicName = "";
                    BE.Item_Pic = new byte[0];
                }
                else
                {
                    byte[] imgByte = (byte[])ViewState["photo"];
                    BE.Item_Pic = imgByte;
                    BE.Item_PicName = ViewState["photo_Name"].ToString();
                }
            }
        }
        public void GetImage()
        {
            BE.Area_Code = ddl_area.SelectedValue;
            BE.Supplier_ID = ddl_supplier.SelectedValue;
            BE.Product_Code = txt_PID.Text;
            DataSet ds_image = new DataSet();
            ds_image = BL.Exe_Selete_ProductEntry_Images(BE);
            if (ds_image.Tables[0].Rows.Count != 0)
            {
                ViewState["photo"] = ds_image.Tables[0].Rows[0]["ItemPic"];
                if (ViewState["photo"].ToString() == "")
                {
                }
                else
                {
                    byte[] bytes = (byte[])(ds_image.Tables[0].Rows[0]["ItemPic"]);
                    BE.Item_Pic = bytes;
                    ViewState["photo"] = BE.Item_Pic;
                    string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
                    SImage.ImageUrl = "data:image/jpeg;base64," + base64String;
                    BE.Item_PicName = ds_image.Tables[0].Rows[0]["ItemPic_Name"].ToString();
                    ViewState["photo_Name"] = BE.Item_PicName;
                }
                ViewState["Image1"] = ds_image.Tables[0].Rows[0]["BarCode"];
                if (ViewState["Image1"].ToString() == "")
                {
                }
                else
                {
                    byte[] bytes_Barcode = (byte[])(ds_image.Tables[0].Rows[0]["BarCode"]);
                    BE.BarCode = bytes_Barcode;
                    ViewState["Image1"] = BE.BarCode;
                    string base64StringBarCode = Convert.ToBase64String(bytes_Barcode, 0, bytes_Barcode.Length);
                    Image1.ImageUrl = "data:image/jpeg;base64," + base64StringBarCode;

                }
            }
        }
        #endregion

        #region Button
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (txt_PID.Text == null)
            {
                return;
            }
            else
            {
                if (File.Exists(Server.MapPath("Barcode.txt")))
                {
                    File.Delete(Server.MapPath("BarCode.txt"));
                }
                File.WriteAllText(Server.MapPath("BarCode.txt"), txt_PID.Text);

                Process.Start(Server.MapPath("BarCodeGenerate.exe"));
                BE.Product_Id = txt_PID.Text;
                DataSet ds_pro = BL.Exe_Select_ProductDetails(BE);
                if (ds_pro.Tables[0].Rows.Count != 0)
                {
                    lbtn_add.Text = "Modify";
                    //ddl_area.Enabled = false;
                    //ddl_supplier.Enabled = false;
                    BindArea();
                    string area = ds_pro.Tables[0].Rows[0]["Area_Id"].ToString();
                    ddl_area.SelectedIndex = ddl_area.Items.IndexOf(ddl_area.Items.FindByValue(area));
                    BE.Area_Code = area;
                    BindSupplier();
                    string Supplier_Id = ds_pro.Tables[0].Rows[0]["Supplier_Id"].ToString();
                    ddl_supplier.SelectedIndex = ddl_supplier.Items.IndexOf(ddl_supplier.Items.FindByValue(Supplier_Id));
                
                    txt_pname.Text = ds_pro.Tables[0].Rows[0]["Product_Name"].ToString();
                    txt_pprice.Text = ds_pro.Tables[0].Rows[0]["Purchase_Price"].ToString();
                    txt_sprice.Text = ds_pro.Tables[0].Rows[0]["Sales_Price"].ToString();
                    txt_HCode.Text = ds_pro.Tables[0].Rows[0]["HSN_Code"].ToString();

                    txt_CGST.Text = ds_pro.Tables[0].Rows[0]["C_Gst"].ToString();
                    txt_SGst.Text = ds_pro.Tables[0].Rows[0]["S_Gst"].ToString();
                    txt_discountRs.Text = ds_pro.Tables[0].Rows[0]["Discount_Rs"].ToString();
                    txt_vocharno.Text = ds_pro.Tables[0].Rows[0]["Vocher_No"].ToString();

                    txt_quantity.Text = ds_pro.Tables[0].Rows[0]["Quantity"].ToString();

                    BE.Product_Date = Convert.ToDateTime(ds_pro.Tables[0].Rows[0]["Product_Date"]);

                    DateTime dt3 = BE.Product_Date;

                    string[] productdate = dt3.Date.ToShortDateString().Split('/');
                    txt_productdate.Text = productdate[1] + "/" + productdate[0] + "/" + productdate[2];

                    string Item_Name = ds_pro.Tables[0].Rows[0]["Item_id"].ToString();
                    ddl_Item.SelectedIndex = ddl_Item.Items.IndexOf(ddl_Item.Items.FindByValue(Item_Name));
                    Bind_Subitem();

                    string SubItem_Name = ds_pro.Tables[0].Rows[0]["SubItem_id"].ToString();
                    ddl_SubItem.SelectedIndex = ddl_SubItem.Items.IndexOf(ddl_SubItem.Items.FindByValue(SubItem_Name));
                    txt_PID.Text = ds_pro.Tables[0].Rows[0]["Product_Code"].ToString();

                    GetImage();

                }
            }
        }
        protected void txt_PID_TextChanged(object sender, EventArgs e)
        {
            Button1_Click(sender, e);
        }
        protected void lbtn_add_Click(object sender, EventArgs e)
        {
            if (ViewState["photo"] != null)
            {
                SetData();
                BE.flag = BL.Exe_ProductEntry(BE);
                if (BE.flag == "1")
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", "alert('Inserted successfully');", true);
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", "alert('Not Inserted successfully');", true);
                }
                Bind_Grid();
                lbtn_add.Text = "Add";
                ddl_area.Enabled = false;
                ddl_supplier.Enabled = false;
            }
            else { ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", "alert('Please Select Item Image!');", true); }
           // GenerateID();
           //  LinkButton3_Click(sender, e);
        }
        protected void lbtn_delete_Click(object sender, EventArgs e)
        {
            SetData();
            BE.flag = BL.Exe_Delete_ProductEntry(BE);
            if (BE.flag == "1")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", "alert('Data is deleted successfully.');", true);

            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", "alert('A problem has occurred in deletion');", true);
            }
            Bind_Grid();
            ddl_area.Enabled = false;
            ddl_supplier.Enabled = false;
        }
        protected void lbtn_clear_Click(object sender, EventArgs e)
        {
            GenerateID();
            txt_PID.Focus();
            Image1.ImageUrl = null;
            SImage.ImageUrl = null;
            //BL.ClearControls(this);
            gv_productentry.DataSource = null;
            gv_productentry.DataBind();
            //ddl_area.Enabled = false;
            //ddl_supplier.Enabled = false;
        }
        protected void lbtn_barcode_Click(object sender, EventArgs e)
        {
            Button1_Click(sender, e);
        }
        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Image1.ImageUrl = "images/" + txt_PID.Text + ".png";
            Session["Image1"] = Image1.ImageUrl;
        }
        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            BE.Area_Code = ddl_area.SelectedValue;
            BE.Supplier_ID = ddl_supplier.SelectedValue;
            BE.Product_Code = txt_PID.Text;
            rep.Load(Server.MapPath("~/Reports/Reports/Rpt_BarCode.rpt"));
            DataSet ds = BL.Exe_ProductCode_Checking(BE);
            rep.DataSourceConnections.Clear();
            rep.SetDataSource(ds.Tables[0]);
            rep.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, "BarCode");
          
        }
        #endregion

        #region event
        protected void gv_productentry_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbtn_add.Text = "Modify";
            string Item_Name = gv_productentry.SelectedRow.Cells[1].Text;
            ddl_Item.SelectedIndex = ddl_Item.Items.IndexOf(ddl_Item.Items.FindByText(Item_Name));
            Bind_Subitem();
            string SubItem_Name = gv_productentry.SelectedRow.Cells[2].Text;
            ddl_SubItem.SelectedIndex = ddl_SubItem.Items.IndexOf(ddl_SubItem.Items.FindByText(SubItem_Name));
            txt_PID.Text = gv_productentry.SelectedRow.Cells[3].Text;
            BE.Product_Code = txt_PID.Text;
            GetImage();
            txt_pname.Text = gv_productentry.SelectedRow.Cells[4].Text;
            txt_pprice.Text = gv_productentry.SelectedRow.Cells[5].Text;
            txt_sprice.Text = gv_productentry.SelectedRow.Cells[6].Text;
            txt_HCode.Text = gv_productentry.SelectedRow.Cells[7].Text;

            txt_CGST.Text = gv_productentry.SelectedRow.Cells[8].Text;
            txt_SGst.Text = gv_productentry.SelectedRow.Cells[9].Text;
            txt_discountRs.Text = gv_productentry.SelectedRow.Cells[10].Text;
            txt_vocharno.Text = gv_productentry.SelectedRow.Cells[11].Text;

            txt_quantity.Text = gv_productentry.SelectedRow.Cells[12].Text;
            DateTime dt3 = Convert.ToDateTime(gv_productentry.SelectedRow.Cells[13].Text);

            string[] productdate = dt3.Date.ToShortDateString().Split('/');
            txt_productdate.Text = productdate[1] + "/" + productdate[0] + "/" + productdate[2];
        }
        protected void ddl_area_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindSupplier();
            gv_productentry.DataSource = null;
            gv_productentry.DataBind();
        }
        protected void ddl_supplier_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddl_supplier.SelectedValue != "0")
            {
                Bind_Grid();
                GenerateID();
                txt_PID.Focus();
                Button1_Click(sender, e);
            }
        }
        protected void txt_sprice_TextChanged(object sender, EventArgs e)
        {
            if (txt_pprice.Text != "")
            {
                BE.Purchase_Price = Convert.ToDouble(txt_pprice.Text);
                BE.Sales_Price = Convert.ToDouble(txt_sprice.Text);

                if (BE.Purchase_Price >= BE.Sales_Price)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", "alert('Sales Price should not be less than Purchase Price');", true);
                    txt_sprice.Text = "";
                    txt_sprice.Focus();
                    return;
                }
            }
        }
        protected void txt_productdate_TextChanged(object sender, EventArgs e)
        {
            if (txt_productdate.Text != "")
            {
                string[] strfrm;
                strfrm = txt_productdate.Text.Split('/');
                BE.Product_Date = Convert.ToDateTime(strfrm[1].ToString() + "/" + strfrm[0].ToString() + "/" + strfrm[2].ToString()).Date;
                TimeSpan ts = new TimeSpan();
                DateTime present_date = Convert.ToDateTime(BE.Product_Date);
                DateTime future_Date = Convert.ToDateTime(System.DateTime.Now);
                ts = present_date.Subtract(future_Date);
                if (ts.Hours > 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Alert", "alert('Ooops......You Selected Wrong Date');", true);
                }
            }
        }
        protected void lbtn_imgupload_Click(object sender, EventArgs e)
        {
            LinkButton2_Click(sender, e);
            Button1_Click(sender, e);
            PhotoUpload();
        }
        protected void txt_pprice_TextChanged(object sender, EventArgs e)
        {
            if (txt_pprice.Text != "")
            {
                BE.Purchase_Price = Convert.ToDouble(txt_pprice.Text);

                BE.Discount_Per = 140;
                BE.Total = ((BE.Purchase_Price * BE.Discount_Per) / 100);

                BE.Total2 = BE.Purchase_Price.ToString();
                txt_sprice.Text = Convert.ToString(BE.Total + BE.Purchase_Price);
            }
            else { }
        }
        protected void ddl_Item_SelectedIndexChanged(object sender, EventArgs e)
        {
            Bind_Subitem();
        }
        protected void gv_productentry_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gv_productentry.PageIndex = e.NewPageIndex;
            Bind_Grid();
        }
        #endregion

        protected void lbtn_BulkBar_Click(object sender, EventArgs e)
        {
            ds = BL.Exe_GetProductCode(BE);
            int J = ds.Tables[0].Rows.Count;

            foreach (DataRow row1 in ds.Tables[0].Rows)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {

                    BE.Product_Code = "";
                    BE.Product_Code = ds.Tables[0].Rows[i]["Product_Code"].ToString();

                    if (BE.Product_Code == null)
                    {
                        return;
                    }

                    if (File.Exists(Server.MapPath("Barcode.txt")))
                    {
                        File.Delete(Server.MapPath("BarCode.txt"));
                    }
                    File.WriteAllText(Server.MapPath("BarCode.txt"), BE.Product_Code);

                    Process.Start(Server.MapPath("BarCodeGenerate.exe"));
                    //int K;

                    //for (K = 0; K < 20; K++)
                    //{

                    //}
                }
            }

        }

        protected void lbtn_BulkBarCodeInsert_Click(object sender, EventArgs e)
        {
            ds = BL.Exe_GetProductCode(BE);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                BE.Product_Code = ds.Tables[0].Rows[i]["Product_Code"].ToString();
                Session["Image1"] = null;
                Image1.ImageUrl = null;
                //Session["Image1"] = "images/" + BE.Product_Code + ".png";
                Session["Image1"] = System.IO.File.Exists("images/" + BE.Product_Code + ".png");
                if (Session["Image1"] != null)
                {
                    Session["Image2"] = null;
                    Session["Image2"] = "images/" + BE.Product_Code + ".png";
                    byte[] bytImage = File.ReadAllBytes(Server.MapPath(Session["Image2"].ToString()));
                    BE.BarCode_Pic = bytImage;
                    BE.flag = BL.Exe_UpdateBarCode(BE);
                }
            }
        }

        protected void lbtn_BulkItemInsert_Click(object sender, EventArgs e)
        {
            ds = BL.Exe_GetProductCode(BE);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                BE.Product_Code = ds.Tables[0].Rows[i]["Product_Code"].ToString();
                BE.Item_PicName = BE.Product_Code + ".jpg";
                Image1.ImageUrl = null;
                Session["Image2"] = null;
                Session["Image2"] = "~/images/" + BE.Product_Code + ".jpg";
                string curFile = @"D:/AR/13.AachalSales/Application/FinalAanchal/Aanchal_RIMS/Aanchal_RIMS/images/" + BE.Product_Code + ".jpg";
                string bytImag = File.Exists(curFile) ? "File exists." : "File does not exist.";
                if (bytImag == "File exists.")
                {
                    byte[] bytImage = File.ReadAllBytes(Server.MapPath(Session["Image2"].ToString()));
                    BE.Item_Pic = bytImage;
                    BE.flag = BL.Exe_UpdateItem(BE);
                }
            }
        }

        protected void lbl_confirm_Click(object sender, EventArgs e)
        {
            SetData();
            BE.flag = BL.Exe_SelectAndConfirm(BE);
            if (ViewState["photo"] != null)
            {
                BL.Exe_SelectAndConfirm_AndUpdate(BE);
            }
            BL.Exe_SelectAndConfirm_AndUpdate_Quantity(BE);
          
            if (BE.flag == "1")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", "alert('Confirmed successfully');", true);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", "alert('Not Confirmed successfully');", true);
            }
            DataSet ds_confirm;
            ds_confirm =BL.Exe_Get_Confirmed(BE);
            txt_confirm.Text = ds_confirm.Tables[0].Rows[0]["Count_Confrim"].ToString();
        }
    }
}