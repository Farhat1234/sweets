<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="EmployeeRegisteration.aspx.cs" Inherits="HumanResourceApplication.EmployeeMgt.EmployeeRegisteration" %>

<%@ Register Src="~/UserControls/Navigation.ascx" TagPrefix="uc1" TagName="Navigation" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Styles/form.css" rel="stylesheet" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:Navigation runat="server" ID="Navigation" />
    <body class="fixed-navbar sidebar-scroll hide-sidebar">
        <div class="row">
            <div class="col-md-12">
                <div class="text-center m-b-md">
                    <h3><b>Add Employee</b></h3>
                </div>
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
                <div class="hpanel">
                    <div class="panel-body">
                        <div class="contentform">
                            <div class="leftcontact">
                                <div class="form-group">
                                    <p>Employee ID</p>
                                    <span class="icon-case"><i class="fa fa-id-card"></i></span>
                                    <asp:TextBox ID="txtEmpID" runat="server" TabIndex="1"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <p>Employee Name</p>
                                    <span class="icon-case"><i class="fa fa-user"></i></span>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtEmpName" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                                    <asp:TextBox ID="txtEmpName" runat="server" TabIndex="5"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <p>Role</p>
                                    <span class="icon-case"><i class="fa fa-user"></i></span>
                                    <asp:DropDownList ID="ddlRole" runat="server" class="dropdownlist" TabIndex="3">
                                        <asp:ListItem Text="-- Select --" Value="-1"></asp:ListItem>
                                        <asp:ListItem Text="Executive" Value="3"></asp:ListItem>
                                        <asp:ListItem Text="Manager" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="HR" Value="2"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="form-group">
                                    <p>Select Reporting Manager</p>
                                    <span class="icon-case"><i class="fa fa-user"></i></span>
                                    <asp:DropDownList ID="ddlReportingManager" runat="server" class="dropdownlist" TabIndex="2" AutoPostBack="true" ></asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlReportingManager" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="rightcontact">
                                <div class="form-group">
                                    <p>Date of Joining</p>
                                    <span class="icon-case"><i class="fa fa-calendar"></i></span>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtDOJ" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                                    <asp:TextBox ID="txtDOJ" runat="server" TabIndex="9"></asp:TextBox>
                                    <cc1:CalendarExtender ID="TbDOJ_CalendarExtender" runat="server" Enabled="True" TargetControlID="txtDOJ">
                                    </cc1:CalendarExtender>
                                </div>
                                <div class="form-group">
                                    <p>Email Address</p>
                                    <span class="icon-case"><i class="fa fa-envelope-open"></i></span>
                                    <asp:TextBox ID="txtEmail" runat="server" TabIndex="8"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtEmail" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmail" ErrorMessage="Enter a valid E-mail address" ForeColor="Red" Style="margin: 96px;" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                </div>
                                <div class="form-group">
                                    <p>Select Department</p>
                                    <span class="icon-case"><i class="fa fa-user"></i></span>
                                    <asp:DropDownList ID="ddlDepartment" runat="server" class="dropdownlist" TabIndex="2" AutoPostBack="true" ></asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="ddlDepartment" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>
                                <div class="form-group">
                                    <p>Designation</p>
                                    <span class="icon-case"><i class="fa fa-building-o"></i></span>
                                    <asp:DropDownList ID="ddlNewRole" runat="server" TabIndex="22" AutoPostBack="true" class="dropdownlist">
                                    </asp:DropDownList>
                                </div>
                                <asp:Button ID="btnSubmit" class="btn btn-success" runat="server" Text="Submit" OnClick="btnSubmit_Click" Style="width: 20%; position: relative; float: right; margin: auto; margin-right: 5%; margin-bottom: 5%" />

                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </body>
</asp:Content>
