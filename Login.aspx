<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Aanchal_RIMS.Login" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <link href="Content/Custom.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="backhead2">
            <center>
                    <img src="ProjectImages/aanchal4.png" class="img-responsive" />
                </center>
        </div>
        <br />
         <br />
         
        <div class="col-md-6 col-md-offset-3">

            <div class="eiplwell">

                <br />
                <center>
                <div class="hed1">
                    <img src="ProjectImages/loginavatar.png" alt="" style="height: 100pt" title="User Login" />
                </div>
                    </center>
                <br />

                <div class="row">
                    <div class="col-md-3 col-sm-offset-2">
                        <asp:Label ID="lbluname" runat="server" Text="User Name :" CssClass="labelRMS"></asp:Label>
                    </div>
                    <div class="col-md-1">
                        <div class="input-group">
                            <span class="input-group-addon" id="basic-addon1">@</span>
                            <asp:TextBox ID="txt_Username" runat="server" CssClass="form-control pull-left" Width="200px" placeholder="Enter UserID"></asp:TextBox>
                        </div>

                    </div>
                </div>
                <br />
                <div class="row">
                    <div class="col-md-3 col-sm-offset-2">
                        <asp:Label ID="lblpwd" runat="server" Text="Password :" CssClass="labelRMS"></asp:Label>
                    </div>
                    <div class="col-md-1">
                        <div class="input-group">
                            <span class="input-group-addon" id="basic-addon2"><span class="glyphicon glyphicon-lock"></span></span>
                            <asp:TextBox ID="txt_pwd" runat="server" CssClass="form-control pull-left" placeholder="Enter Password" Width="200px" TextMode="Password"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <br />
                <div class="row">
                    <div class="col-md-2 col-sm-offset-4">
                        <asp:Button ID="btn_login" runat="server" CssClass="btn btn-insert btn-md btn-block"
                            Font-Bold="true" Text="Login" Width="90px" OnClick="btn_login_Click" />
                    </div>
                    <div class="col-lg-1">
                        <asp:Button ID="btn_cancal" runat="server" CssClass="btn btn-insert btn-md btn-block"
                            Font-Bold="true" Text="Cancel" Width="90px" OnClick="btn_cancal_Click" />
                    </div>
                </div>
                <br />
                <div class="row">
                    <div class="col-md-1 col-md-offset-5">
                        <asp:LinkButton ID="lbtn_forgotpwd" runat="server" CssClass="labelRMSLite" Width="200px" Text="Lost you're Password?">
                        </asp:LinkButton>
                    </div>
                </div>
            </div>

        </div>
        <div class="navbar navbar-custom navbar-fixed-bottom">
            <center>
                    <div class="" style="color: White">
                        Copyright© Designed and Developed by<a href="http://www.extremeinfo.in/" target="_blank"
                            style="color: Yellow"> Extreme informatics pvt ltd. </a>
                    </div>
                </center>
        </div>
    </form>
</body>
</html>
