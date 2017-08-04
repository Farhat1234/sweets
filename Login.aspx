<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="HumanResourceApplication.Login" EnableSessionState="True" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
 <style type="text/css">
     #header
{
 display:none;
}
     .fixed-navbar #wrapper {
    top: 0px;
}
     #menu{
         display:none;
     }
     input{
            height: 45px;
    width: 130%;
    border: 1px solid grey;
    border-radius: 4px;
    margin: 10px 30px;
    box-shadow: 2px 2px 2px #a0a0a0;
     }
     .hpanel .panel-body {
                background: rgba(23, 45, 72, 0.76);
    border: 1px solid #000000;
    border-radius: 2px;
    padding: 40px;
    position: relative;

    box-shadow: 14px 2px 16px #0a0a0a;
    height: 500px;
}
     #wrapper {
         margin: 0 0 0 0px;
         padding: 0;
         background: rgba(49, 121, 114, 0.65);
         border-left: 1px solid #eaeaea;
         transition: margin .4s ease 0s;
         position: relative;
         color: black;
         background-image:url("Images/login_bg1.jpg");
     }
     .btn-link {
    color: inherit;
    color: #020202;
    /* background-color: #2a4580; */
    margin: 26px 0px 25px -96px;
    font-size: 16px;
}
     #wrapper{
         min-height:100%!important;
     }
   @media only screen and (min-device-width : 320px) and (max-width: 500px) {
              .hpanel .panel-body  {
                width: 100% !important;
               margin:auto;
                display: block;
            }
        }
    @media only screen and (min-device-width : 320px) and (max-width: 500px) {
              #ContentPlaceHolder1_txtEmpID,#ContentPlaceHolder1_txtPass,.btn-success  {
                 width: 120%;
    margin: 10% 7%;
    display: block;
            }
        }
     .btn-success {
         background-color:transparent;
        border-color: rgb(28, 58, 86);
    color: #fff;
box-shadow: 2px 2px 2px transparent;
}


 </style>
    <!-- Simple splash screen-->
<div class="splash"> <div class="color-line"></div><div class="splash-title"><h1>HRMS</h1><p>Special Admin Theme for small and medium webapp with very clean and aesthetic style and feel. </p><div class="spinner"> <div class="rect1"></div> <div class="rect2"></div> <div class="rect3"></div> <div class="rect4"></div> <div class="rect5"></div> </div> </div> </div>

<%--<div class="color-line"></div>--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

 
    
    

<div class="login-container">
    <div class="row">
        <div class="col-md-12">
            <div class="text-center m-b-md">
                <img src="Images/Logo.png" style="    box-shadow: 5px 7px 70px #4e4e4e;"/>
         <%--       <h1>PLEASE LOGIN TO APP</h1>--%>
               
            </div>
            <div class="hpanel">
                <div class="panel-body">
                        
               
     <h3 style="color: antiquewhite;">Login</h3>
    
    
       <table style="    margin-top: 20%;">
    
       
            <tr>
                <td>
         <%-- <nav>
        <ul>
        <li><a href="EmployeeMgt/AddNewEmployee.aspx"><span></span> Register Here </a></li>
        <li> <a href="#"><span></span>Forgot Password</a></li>
    </ul>
    </nav>--%>
                </td>
                <td class="auto-style2">
        <table class="style1">
            <tr>
                <td class="style4">
                
                     </td>
                <td class="style3">
                    <asp:TextBox ID="txtEmpID" runat="server" placeholder=" Enter Employee ID" ></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style4">
    
                </td>
                <td class="style3">
                    <asp:TextBox ID="txtPass" runat="server"
                        TextMode="Password" placeholder="Enter Password"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style2" colspan="2">
                    <asp:ImageButton ID="ImageButton1" runat="server" 
                      OnClick="ImageButton1_Click" class="btn btn-success" AlternateText="Login"/>
                     </td>
                <td>
                    <%--<a href="EmployeeMgt/AddNewEmployee.aspx" class="btn btn-link">New Employee Registration</a>--%>

                </td>
            </tr>
        </table>
                    </td>
                </tr>

            </table>
        </div>
                </div>
            </div>
        </div>
    </div>
    
</asp:Content>