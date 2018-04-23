<%@ Page Language="C#" MasterPageFile="~/MasterPages/Home.Master" AutoEventWireup="true" CodeBehind="BarCode.aspx.cs" Inherits="BarCode.BarCode" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
        function AlertPopup() {
            $("#btnAlertPopup").click();
        }
        function DeleteShowPopup() {
            $("#btnDeleteShowPopup").click();
        }
        function DeleteHidePopup() {
            $("#btnDeleteHidePopup").click();
        }
    </script>
    <%--  <asp:UpdatePanel ID="UpdatePanel_usercreation" runat="server">

        <ContentTemplate>--%>
    <asp:Panel ID="Panel_usercreation" runat="server">
        <div class="container">

            <div class="panel-border panel-Custom">
                <div class="panel-heading">
                    <center>
                                <h4>
                                    <span class="glyphicon glyphicon-credit-card"></span>&nbsp;&nbsp;&nbsp;Product Entry</h4>
                            </center>
                </div>
                <br />
                <br />
                <div class="row">
                    <div class="col-md-2">
                        <asp:Label ID="lbl_area" runat="server" Text="Area :" CssClass="labelRMS"></asp:Label>
                    </div>
                    <div class="col-md-3">
                        <asp:DropDownList ID="ddl_area" runat="server" CssClass="pull-left form-control" AutoPostBack="true" OnSelectedIndexChanged="ddl_area_SelectedIndexChanged"></asp:DropDownList>
                    </div>
                    <div class="col-md-2">
                        <asp:Label ID="lbl_supplier" runat="server" Text="Supplier :" CssClass="labelRMS"></asp:Label>
                    </div>
                    <div class="col-md-3">
                        <asp:DropDownList ID="ddl_supplier" runat="server" CssClass="pull-left form-control" AutoPostBack="true" OnSelectedIndexChanged="ddl_supplier_SelectedIndexChanged"></asp:DropDownList>
                    </div>
                </div>
                <br />
                <div class="row">
                    <div class="col-md-2">
                        <asp:Label ID="lbl_PID" runat="server" Text="Product Code :" CssClass="labelRMS"></asp:Label>
                    </div>
                    <div class="col-md-3">
                        <asp:TextBox ID="txt_PID" runat="server" CssClass="pull-left form-control" placeholder="Product Code" AutoPostBack="true" OnTextChanged="txt_PID_TextChanged"></asp:TextBox>
                    </div>
                    <div class="col-md-2">
                        <asp:Label ID="lbl_pname" runat="server" Text="Product Name :" CssClass="labelRMS"></asp:Label>
                    </div>
                    <div class="col-md-3">
                        <asp:TextBox ID="txt_pname" runat="server" CssClass="pull-left form-control" placeholder="Product Name"></asp:TextBox>
                    </div>
                </div>
                <br />
                <div class="row">
                    <div class="col-md-2">
                        <asp:Label ID="lbl_item" runat="server" Text="Item :" CssClass="labelRMS"></asp:Label>
                    </div>
                    <div class="col-md-3">
                        <asp:DropDownList ID="ddl_Item" runat="server" CssClass="pull-left form-control" AutoPostBack="true" OnSelectedIndexChanged="ddl_Item_SelectedIndexChanged"></asp:DropDownList>
                    </div>
                    <div class="col-md-2">
                        <asp:Label ID="lbl_subitem" runat="server" Text="Sub Item :" CssClass="labelRMS"></asp:Label>
                    </div>
                    <div class="col-md-3">
                        <asp:DropDownList ID="ddl_SubItem" runat="server" CssClass="pull-left form-control"></asp:DropDownList>
                    </div>
                </div>
                <br />
                <div class="row">
                    <div class="col-md-2">
                        <asp:Label ID="lbl_pprice" runat="server" Text="Purchase Price :" CssClass="labelRMS"></asp:Label>
                    </div>
                    <div class="col-md-3">
                        <asp:TextBox ID="txt_pprice" runat="server" CssClass="pull-left form-control" onkeypress="return IsNumberKey(event)" placeholder="Purchase Price" AutoPostBack="true" OnTextChanged="txt_pprice_TextChanged"></asp:TextBox>
                    </div>
                    <div class="col-md-2">
                        <asp:Label ID="lbl_sprice" runat="server" Text="Sales Price :" CssClass="labelRMS"></asp:Label>
                    </div>
                    <div class="col-md-3">
                        <asp:TextBox ID="txt_sprice" AutoPostBack="true" runat="server" CssClass="pull-left form-control" onkeypress="return IsNumberKey(event)" OnTextChanged="txt_sprice_TextChanged" placeholder="Sales Price"></asp:TextBox>
                    </div>
                </div>
                <br />
                <div class="row">
                    <div class="col-md-2">
                        <asp:Label ID="lbl_CGST" runat="server" Text="CGST(%) :" CssClass="labelRMS"></asp:Label>
                    </div>
                    <div class="col-md-3">
                        <asp:TextBox ID="txt_CGST" runat="server" CssClass="pull-left form-control" onkeypress="return IsNumberKey(event)" placeholder="CGst"></asp:TextBox>
                    </div>
                    <div class="col-md-2">
                        <asp:Label ID="lbl_SGst" runat="server" Text="SGST(%) :" CssClass="labelRMS"></asp:Label>
                    </div>
                    <div class="col-md-3">
                        <asp:TextBox ID="txt_SGst" runat="server" CssClass="pull-left form-control" onkeypress="return IsNumberKey(event)" placeholder="SGst"></asp:TextBox>
                    </div>
                </div>
                <br />
                <div class="row">
                    <div class="col-md-2">
                        <asp:Label ID="lbl_discountRs" runat="server" Text="Discount Rs. :" CssClass="labelRMS"></asp:Label>
                    </div>
                    <div class="col-md-3">
                        <asp:TextBox ID="txt_discountRs" runat="server" CssClass="pull-left form-control" onkeypress="return IsNumberKey(event)" placeholder="Discount Rs."></asp:TextBox>
                    </div>
                    <div class="col-md-2">
                        <asp:Label ID="lbl_Hcode" runat="server" Text="HSN Code :" CssClass="labelRMS"></asp:Label>
                    </div>
                    <div class="col-md-3">
                        <asp:TextBox ID="txt_HCode" runat="server" CssClass="pull-left form-control" placeholder="HSN Code"></asp:TextBox>
                    </div>
                </div>
                <br />
                <div class="row">
                    <div class="col-md-2">
                        <asp:Label ID="lbl_quantity" runat="server" Text="Quantity :" CssClass="labelRMS"></asp:Label>
                    </div>
                    <div class="col-md-3">
                        <asp:TextBox ID="txt_quantity" runat="server" CssClass="pull-left form-control" onkeypress="return IsNumberKey(event)" placeholder="Quantity"></asp:TextBox>
                    </div>
                    <div class="col-md-2">
                        <asp:Label ID="lbl_productdate" runat="server" Text="Purchase Date :" CssClass="labelRMS"></asp:Label>
                    </div>
                    <div class="col-md-3">
                        <asp:TextBox ID="txt_productdate" AutoPostBack="true" runat="server" CssClass="pull-left form-control" OnTextChanged="txt_productdate_TextChanged" placeholder="Product Date"></asp:TextBox>
                        <cc1:CalendarExtender ID="txt_date_CalendarExtender" runat="server" Enabled="True"
                            CssClass="black" TargetControlID="txt_productdate" Format="dd/MM/yyyy">
                        </cc1:CalendarExtender>
                    </div>

                </div>
                <br />
                <div class="row">
                    <div class="col-md-2">
                        <asp:Label ID="lbl_vocharno" runat="server" Text="Vochar No :" CssClass="labelRMS"></asp:Label>
                    </div>
                    <div class="col-md-3">
                        <asp:TextBox ID="txt_vocharno" runat="server" CssClass="pull-left form-control" placeholder="Vochar No"></asp:TextBox>
                    </div>
                    <div class="col-md-2">
                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" DisplayMode="BulletList"
                            HeaderText="Error: " ShowMessageBox="true" ShowSummary="false"></asp:ValidationSummary>
                    </div>
                </div>
                <br />
                <div class="well">
                    <div class="row">
                        <div class="col-md-2 col-md-offset-1">
                            <asp:Button ID="Button1" runat="server" Visible="false" Text="Button" OnClick="Button1_Click" />
                            <asp:LinkButton ID="lbtn_imagelabel" Text="BarCode" Font-Size="14pt" runat="server" />
                        </div>
                        <div class="col-md-2 col-md-offset-5">
                            <asp:LinkButton ID="LinkButton1" Text="ClickForNewPhoto!" Font-Size="14pt" runat="server"
                                OnClientClick="return OpenNewWindow();" />
                        </div>
                        <div class="col-md-2 col-md-offset-1">
                            <asp:Image ID="Image1" runat="server" />
                        </div>
                        <div class="col-md-2 col-md-offset-8">
                            <asp:UpdatePanel ID="up" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <asp:Image ID="SImage" runat="server" Width="130px" Height="150px" />
                                    <label class="file-upload">
                                        <asp:FileUpload ID="file_image" runat="server" />

                                        <%-- <asp:CustomValidator ID="CustomValidator2" runat="server" Display="Dynamic" ControlToValidate="file_image"
                                            ErrorMessage="Please upload Image" SetFocusOnError="True" ValidateEmptyText="True"
                                            ValidationGroup="ValGrp1" ClientValidationFunction="CheckValidFile"></asp:CustomValidator>--%>
                                    </label>
                                    <asp:LinkButton ID="lbtn_imgupload" runat="server" CssClass="btn btn-info" OnClick="lbtn_imgupload_Click">Upload</asp:LinkButton>
                                    <%--<asp:LinkButton ID="lbtn_imgupload" runat="server" CssClass="btn btn-info" OnClick="lbtn_imgupload_Click"><span class="glyphicon glyphicon-save"></span>Upload</asp:LinkButton>--%>
                                    <asp:Label ID="lblphoto" runat="server" ForeColor="#660033" Font-Bold="True" Font-Size="10"></asp:Label>

                                </ContentTemplate>

                                <Triggers>
                                    <asp:PostBackTrigger ControlID="lbtn_imgupload" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </div>

                    </div>
                </div>
                <br />

                <%--   <div class="modal fade" id="AlertModal" tabindex="-1" role="dialog" aria-labelledby="AlertModalLabel"
                    aria-hidden="true" data-keyboard="true">
                    <div class="modal-dialog modal-md">
                        <div class="modal-content">
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                    <span aria-hidden="true">&times;</span></button>
                                <center>
                                                    <h4 class="modal-title" id="AlertModalLabel">Alert...!</h4>
                                                </center>
                            </div>
                            <div class="modal-body">
                                <div class="container">
                                    <asp:Label ID="lbl_alert" runat="server"></asp:Label>
                                </div>
                            </div>
                            <div class="modal-footer">
                                <asp:Button ID="Alert_Close" Text="Close" runat="server" data-dismiss="modal" CssClass="btn btn-primary" />
                            </div>
                        </div>
                    </div>
                </div>--%>
                <asp:UpdatePanel ID="UpdatePanel_usercreation" runat="server">

                    <ContentTemplate>
                        <div class="row">
                            <div class="col-md-2 col-md-offset-5">
                                <asp:LinkButton ID="lbl_confirm" runat="server" CssClass="btn btn-insert" OnClick="lbl_confirm_Click" Visible="false"><span class="glyphicon glyphicon-warning-sign"></span> Confirm</asp:LinkButton>

                                <asp:TextBox ID="txt_confirm" runat="server" CssClass="pull-left form-control" ReadOnly="true" placeholder="Total Counts" Visible="false"></asp:TextBox>
                            </div>
                        </div>
                        <br />
                        <br />
                        <br />
                        <br />
                        <center>
                            <div class="row">
                                <asp:LinkButton ID="lbtn_add" runat="server" CssClass="btn btn-insert" OnClientClick="return validateAdd()" OnClick="lbtn_add_Click"><span class="glyphicon glyphicon-plus"></span> Add</asp:LinkButton>
                                <asp:LinkButton ID="lbtn_delete" runat="server" CssClass="btn btn-insert" OnClick="lbtn_delete_Click"  Visible="false" ><span class="glyphicon glyphicon-trash"></span> Delete</asp:LinkButton>
                                
                                <asp:Button ID="LinkButton3" runat="server"  CssClass="btn btn-insert" OnClick="LinkButton3_Click" Text="BarCode Print" OnClientClick="return SetTarget()"></asp:Button>
                                <asp:LinkButton ID="lbtn_clear" runat="server" CssClass="btn btn-insert" OnClick="lbtn_clear_Click" ><span class="glyphicon glyphicon-refresh"></span> Clear</asp:LinkButton>
                                   <asp:LinkButton ID="lbtn_barcode" runat="server" CssClass="btn btn-insert" Visible="false" OnClick="lbtn_barcode_Click"><span class="glyphicon glyphicon-refresh"></span> GenerateBarCode</asp:LinkButton>
                                  <asp:LinkButton ID="LinkButton2" runat="server" CssClass="btn btn-insert"  Visible="false" OnClick="LinkButton2_Click"><span class="glyphicon glyphicon-refresh"></span> ShowBarCode</asp:LinkButton>

                                  <asp:LinkButton ID="lbtn_BulkBar" runat="server" CssClass="btn btn-insert" OnClick="lbtn_BulkBar_Click" Visible="false"><span class="glyphicon glyphicon-refresh"></span> Bulk BarCode</asp:LinkButton>
                                   <asp:LinkButton ID="lbtn_BulkBarCodeInsert" runat="server" CssClass="btn btn-insert" OnClick="lbtn_BulkBarCodeInsert_Click"  Visible="false"><span class="glyphicon glyphicon-refresh"></span> Bulk BarCode Insert</asp:LinkButton>
                                <asp:LinkButton ID="lbtn_BulkItemInsert" runat="server" CssClass="btn btn-insert" OnClick="lbtn_BulkItemInsert_Click"  Visible="false"><span class="glyphicon glyphicon-refresh"></span> Bulk Item Insert</asp:LinkButton>
                                


                            </div>
                            <br />
                            </center>
                    </ContentTemplate>
                    <Triggers>
                        <asp:PostBackTrigger ControlID="lbtn_add" />
                        <asp:PostBackTrigger ControlID="LinkButton1" />
                        <asp:PostBackTrigger ControlID="lbtn_clear" />
                        <asp:PostBackTrigger ControlID="lbtn_delete" />
                        <asp:PostBackTrigger ControlID="LinkButton3" />
                        <asp:PostBackTrigger ControlID="lbtn_barcode" />
                        <asp:PostBackTrigger ControlID="lbtn_imgupload" />
                        <asp:PostBackTrigger ControlID="LinkButton2" />
                        <asp:PostBackTrigger ControlID="lbtn_BulkBar" />


                    </Triggers>
                </asp:UpdatePanel>
                <br />

                <div id="divGrid" style="overflow-x: scroll; overflow-y: scroll; height: 100%; width: 100%;" runat="server">
                    <asp:GridView ID="gv_productentry" runat="server" HeaderStyle-CssClass="header" HorizontalAlign="Center"
                        PagerStyle-CssClass="pager" RowStyle-CssClass="rows" AllowPaging="True" AutoGenerateColumns="False"
                        AutoGenerateSelectButton="True" OnPageIndexChanging="gv_productentry_PageIndexChanging" CssClass="table table-striped table-bordered table-hover" OnSelectedIndexChanged="gv_productentry_SelectedIndexChanged">
                        <Columns>
                            <asp:BoundField DataField="Item_Name" HeaderText="Item" HeaderStyle-Font-Size="Large" />
                            <asp:BoundField DataField="SubItem_Name" HeaderText="SubItem" HeaderStyle-Font-Size="Medium" />
                            <asp:BoundField DataField="Product_Code" HeaderText="Code" HeaderStyle-Font-Size="Medium" />
                            <asp:BoundField DataField="Product_Name" HeaderText="Name" HeaderStyle-Font-Size="Medium" />
                            <asp:BoundField DataField="Purchase_Price" HeaderText="PurchasePrice" HeaderStyle-Font-Size="Medium" />
                            <asp:BoundField DataField="Sales_Price" HeaderText="SalesPrice" HeaderStyle-Font-Size="Medium" />
                            <asp:BoundField DataField="HSN_Code" HeaderText="HSNCode" HeaderStyle-Font-Size="Medium" />
                            <asp:BoundField DataField="C_Gst" HeaderText="CGst" HeaderStyle-Font-Size="Medium" />
                            <asp:BoundField DataField="S_Gst" HeaderText="SGst" HeaderStyle-Font-Size="Medium" />
                            <asp:BoundField DataField="Discount_Rs" HeaderText="Dis(%)" HeaderStyle-Font-Size="Medium" />
                            <asp:BoundField DataField="Vocher_No" HeaderText="VocherNo." HeaderStyle-Font-Size="Medium" />
                            <asp:BoundField DataField="Quantity" HeaderText="Quantity" HeaderStyle-Font-Size="Medium" />
                            <asp:BoundField DataField="Product_Date" HeaderText="Date" HeaderStyle-Font-Size="Medium" />
                        </Columns>
                        <HeaderStyle CssClass="header"></HeaderStyle>
                        <PagerStyle CssClass="pager"></PagerStyle>
                        <RowStyle CssClass="rows"></RowStyle>
                    </asp:GridView>

                </div>
            </div>
        </div>
        <br />
        <br />
    </asp:Panel>

    <br />
    <br />
    <script runat="server">
        void LinkButton1_Click(Object sender, EventArgs e)
        {
            Response.Redirect("https://webcamtoy.com");
        }
    </script>
    <script type="text/javascript">
        function OpenNewWindow() {
            window.open("https://webcamtoy.com", "List", "scrollbars=no,resizable=no,width=1000,height=500");
            return false;
        }
    </script>
    <script language="javascript" type="text/javascript">
        function IsNumberKey(evt) {
            var charcode = (evt.which) ? evt.which : evt.keyCode;
            if (charcode != 46 && charcode > 31 && (charcode < 48 || charcode > 57))
                return false;

            return true;
        }
    </script>
    <script type="text/javascript">
        function SetTarget() {
            document.forms[0].target = "_blank";
            return true;
        }
    </script>
    <script language="javascript" type="text/javascript">
        function validateAdd() {
            if (document.getElementById("<%=ddl_area.ClientID%>").selectedIndex == "") {
                alert("Please Select Area");
                document.getElementById("<%=ddl_area.ClientID%>").focus();
                return false;
            }
            if (document.getElementById("<%=ddl_supplier.ClientID%>").selectedIndex == "") {
                alert("Please Select Supplier");
                document.getElementById("<%=ddl_supplier.ClientID%>").focus();
                return false;
            }
            if (document.getElementById("<%=txt_pname.ClientID%>").value == "") {
                alert("Please enter product name.");
                document.getElementById("<%=txt_pname.ClientID%>").focus();
                return false;
            }
            if (document.getElementById("<%=txt_pprice.ClientID%>").value == "") {
                alert("Please enter product price.");
                document.getElementById("<%=txt_pprice.ClientID%>").focus();
                return false;
            }
            if (document.getElementById("<%=txt_sprice.ClientID%>").value == "") {
                alert("Please enter sales price.");
                document.getElementById("<%=txt_sprice.ClientID%>").focus();
                return false;
            }
            if (document.getElementById("<%=txt_CGST.ClientID%>").value == "") {
                alert("Please enter CGst.");
                document.getElementById("<%=txt_CGST.ClientID%>").focus();
                return false;
            }
            if (document.getElementById("<%=txt_SGst.ClientID%>").value == "") {
                alert("Please enter SGst.");
                document.getElementById("<%=txt_SGst.ClientID%>").focus();
                return false;
            }
            if (document.getElementById("<%=txt_discountRs.ClientID%>").value == "") {
                alert("Please enter Discount Rs.");
                document.getElementById("<%=txt_discountRs.ClientID%>").focus();
                return false;
            }
            if (document.getElementById("<%=txt_quantity.ClientID%>").value == "") {
                alert("Please enter quantity.");
                document.getElementById("<%=txt_quantity.ClientID%>").focus();
                return false;
            }
            if (document.getElementById("<%=txt_productdate.ClientID%>").value == "") {
                alert("Please enter product date.");
                document.getElementById("<%=txt_productdate.ClientID%>").focus();
                return false;
            }
            if (document.getElementById("<%=txt_vocharno.ClientID%>").value == "") {
                alert("Please enter vochar no.");
                document.getElementById("<%=txt_vocharno.ClientID%>").focus();
                return false;
            }
            return true;
        }
    </script>
</asp:Content>
