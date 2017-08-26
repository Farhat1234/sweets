<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="AddNewEmployee.aspx.cs" Inherits="HumanResourceApplication.Employee_Mgt.AddNewEmployee" EnableEventValidation="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Styles/form.css" rel="stylesheet" />
    <style type="text/css">
        input[type="checkbox"] {
            margin: 16px -140px -29px !important;
            float: left;
        }

        input[type="radio"] {
            width: 11% !important;
            height: 18px;
            float: none;
        }

        .sidebar-scroll #menu {
            position: fixed;
            background-color: #f1f3f6;
        }

        .slimScrollDiv {
            display: none;
        }

        .fixed-navbar sidebar-scroll {
            display: none;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <body class="fixed-navbar sidebar-scroll hide-sidebar">
        <div class="row">
            <div class="col-md-12">
                <div class="text-center m-b-md">
                    <h3><b>Profile</b></h3>
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
                                    <asp:TextBox ID="txtEmpID" runat="server" Enabled="false" TabIndex="1"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <p>Role</p>
                                    <span class="icon-case"><i class="fa fa-user"></i></span>
                                    <asp:TextBox ID="txtDesignation" runat="server" TabIndex="7" Enabled="false"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <p>First Name</p>
                                    <span class="icon-case"><i class="fa fa-user"></i></span>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtEmpFname" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                                    <asp:TextBox ID="txtEmpFname" runat="server" TabIndex="5"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <p>Mobile Number</p>
                                    <span class="icon-case"><i class="fa fa-phone"></i></span>
                                    <asp:TextBox ID="txtPhone" runat="server" TabIndex="7"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtPhone" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtPhone" ErrorMessage="Enter a valid Mobile numer" ForeColor="Red" Style="margin: 96px;" ValidationExpression="[0-9]{10}"></asp:RegularExpressionValidator>
                                </div>
                                <div class="form-group">
                                    <p>Date of Joining</p>
                                    <span class="icon-case"><i class="fa fa-calendar"></i></span>
                                    <asp:TextBox ID="txtDOJ" runat="server" TabIndex="9" Enabled="false"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <p>Gender</p>
                                    <span class="icon-case"><i class="fa fa-male"></i></span>
                                    <asp:DropDownList ID="ddlGender" runat="server" class="dropdownlist" TabIndex="11">
                                        <asp:ListItem Text="--- Select Gender ---" Value="-1"></asp:ListItem>
                                        <asp:ListItem Text="Male" Value="Male"></asp:ListItem>
                                        <asp:ListItem Text="Female" Value="Female"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="form-group">
                                    <p>Upload Photo</p>
                                    <span class="icon-case"><i class="fa fa-comments-o"></i></span>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="FileUpload1" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                                    <asp:FileUpload ID="FileUpload1" runat="server" OnLoad="FileUpload1_Load1" TabIndex="13" />
                                </div>
                            </div>
                            <div class="rightcontact">
                                <div class="form-group">
                                    <p>Department</p>
                                    <span class="icon-case"><i class="fa fa-user"></i></span>
                                    <asp:TextBox ID="txtDepartment" runat="server" TabIndex="6" Enabled="false"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <p>Reporting Manager</p>
                                    <span class="icon-case"><i class="fa fa-user"></i></span>
                                    <asp:TextBox ID="txtRM" runat="server" TabIndex="6" Enabled="false"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <p>Last Name</p>
                                    <span class="icon-case"><i class="fa fa-user"></i></span>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtEmpLname" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                                    <asp:TextBox ID="txtEmpLname" runat="server" TabIndex="6"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <p>Email Address</p>
                                    <span class="icon-case"><i class="fa fa-envelope-open"></i></span>
                                    <asp:TextBox ID="txtEmail" runat="server" TabIndex="8"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <p>Date of Birth</p>
                                    <span class="icon-case"><i class="fa fa-calendar"></i></span>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtDOB" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                                    <asp:TextBox ID="txtDOB" runat="server" TabIndex="10"></asp:TextBox>
                                    <cc1:CalendarExtender ID="TbDOB_CalendarExtender" runat="server" Enabled="True"
                                        TargetControlID="txtDOB">
                                    </cc1:CalendarExtender>
                                </div>
                                <div class="form-group">
                                    <p>Blood Group</p>
                                    <span class="icon-case"><i class="fa fa-info"></i></span>
                                    <asp:DropDownList runat="server" ID="ddlBloodGroup" class="dropdownlist" TabIndex="12">
                                        <asp:ListItem Text="--- Select Blood Group ---" Value="-1"></asp:ListItem>
                                        <asp:ListItem Text="A+" Value="A+"></asp:ListItem>
                                        <asp:ListItem Text="A-" Value="A-"></asp:ListItem>
                                        <asp:ListItem Text="B+" Value="B+"></asp:ListItem>
                                        <asp:ListItem Text="B-" Value="B-"></asp:ListItem>
                                        <asp:ListItem Text="O+" Value="O+"></asp:ListItem>
                                        <asp:ListItem Text="O-" Value="O-"></asp:ListItem>
                                        <asp:ListItem Text="AB+" Value="AB+"></asp:ListItem>
                                        <asp:ListItem Text="AB-" Value="AB-"></asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="ddlBloodGroup" ErrorMessage="*" ForeColor="Red" InitialValue="-1"></asp:RequiredFieldValidator>
                                </div>
                                <div class="form-group">
                                    <p>Upload Resume</p>
                                    <span class="icon-case"><i class="fa fa-comments-o"></i></span>
                                  <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="FileUpload2" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                                    <asp:FileUpload ID="FileUpload2" runat="server" OnLoad="FileUpload2_Load2" TabIndex="14" />
                                </div>
                                
                            </div>
                        </div>
                        <h2>Permanent Address Details</h2>
                        <div class="contentform">

                            <div class="leftcontact">
                                <div class="form-group">
                                    <p>Address</p>
                                    <span class="icon-case"><i class="fa fa-home"></i></span>
                                    <asp:TextBox ID="txtAddressPA" runat="server" TabIndex="15"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <p>State</p>
                                    <span class="icon-case"><i class="fa fa-building-o"></i></span>
                                    <asp:DropDownList ID="ddlStatePA" OnSelectedIndexChanged="ddlStatePA_SelectedIndexChanged" runat="server" TabIndex="17" ToolTip="Please Select A State" AutoPostBack="true" class="dropdownlist">
                                    </asp:DropDownList>
                                </div>
                            </div>

                            <div class="rightcontact">
                                <div class="form-group">
                                    <p>Country</p>
                                    <span class="icon-case"><i class="fa fa-building-o"></i></span>
                                    <asp:DropDownList ID="ddlCountryPA" runat="server" OnSelectedIndexChanged="ddlCountryPA_SelectedIndexChanged" AutoPostBack="true" TabIndex="16" ToolTip="Please Select A Country" class="dropdownlist"></asp:DropDownList>
                                </div>
                                <div class="form-group">
                                    <p>City</p>
                                    <span class="icon-case"><i class="fa fa-building-o"></i></span>
                                    <asp:DropDownList ID="ddlCityPA" runat="server" TabIndex="18" AutoPostBack="true" ToolTip="Please Select A City" class="dropdownlist">
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <h2>Current Address Details</h2>
                        <div class="contentform">
                            <div class="leftcontact">
                                <div class="form-group">
                                    <p>Address</p>
                                    <span class="icon-case"><i class="fa fa-home"></i></span>
                                    <asp:TextBox ID="txtAddressCA" TabIndex="19" runat="server"></asp:TextBox>
                                </div>

                                <div class="form-group">
                                    <p>State</p>
                                    <span class="icon-case"><i class="fa fa-building-o"></i></span>
                                    <asp:DropDownList ID="ddlStateCA" runat="server" OnSelectedIndexChanged="ddlStateCA_SelectedIndexChanged" AutoPostBack="true" TabIndex="21" ToolTip="Please Select A State" class="dropdownlist">
                                    </asp:DropDownList>
                                </div>
                            </div>

                            <div class="rightcontact">
                                <div class="form-group">
                                    <p>Country</p>
                                    <span class="icon-case"><i class="fa fa-building-o"></i></span>
                                    <asp:DropDownList ID="ddlCountryCA" runat="server" OnSelectedIndexChanged="ddlCountryCA_SelectedIndexChanged" AutoPostBack="true" TabIndex="20" ToolTip="Please Select A Country" class="dropdownlist">
                                    </asp:DropDownList>
                                </div>
                                <div class="form-group">
                                    <p>City</p>
                                    <span class="icon-case"><i class="fa fa-building-o"></i></span>
                                    <asp:DropDownList ID="ddlCityCA" runat="server" TabIndex="22" AutoPostBack="true" ToolTip="Please Select A City" class="dropdownlist">
                                    </asp:DropDownList>
                                </div>

                            </div>
                        </div>
                        <asp:Panel runat="server" ID="PanelPreviousCompany">
                            <h2>Previous Company Details</h2>
                            <div class="contentform">
                                <div class="leftcontact">
                                    <div class="form-group">
                                        <p>Company Name</p>
                                        <span class="icon-case"><i class="fa fa-building-o"></i></span>
                                        <asp:TextBox ID="txtPreviousCompany" runat="server" TabIndex="23"></asp:TextBox>
                                    </div>
                                    <div class="form-group">
                                        <p>Previous Designation</p>
                                        <span class="icon-case"><i class="fa fa-male"></i></span>
                                        <asp:TextBox ID="txtPreviousDesignation" runat="server" TabIndex="25"></asp:TextBox>
                                    </div>
                                    <div class="form-group">
                                        <p>From Date</p>
                                        <span class="icon-case"><i class="fa fa-calendar"></i></span>
                                        <asp:TextBox ID="txtFromDate" runat="server" TabIndex="27"></asp:TextBox>
                                        <cc1:CalendarExtender ID="txtFromDateCalendarExtender" runat="server" Enabled="True"
                                            TargetControlID="txtFromDate">
                                        </cc1:CalendarExtender>
                                    </div>                   
                                      <div class="form-group">
                                        <p>Designation</p>
                                        <span class="icon-case"><i class="fa fa-male"></i></span>
                                        <asp:TextBox ID="txtNewRole" runat="server" TabIndex="24"></asp:TextBox>
                                    </div>               
                                </div>
                                <div class="rightcontact">
                                    <div class="form-group">
                                        <p>Contact Person Name</p>
                                        <span class="icon-case"><i class="fa fa-male"></i></span>
                                        <asp:TextBox ID="txtContactPersonName" runat="server" TabIndex="24"></asp:TextBox>
                                    </div>
                                    <div class="form-group">
                                        <p>Contact Number</p>
                                        <span class="icon-case"><i class="fa fa-phone"></i></span>
                                        <asp:TextBox ID="txtRefNumber" runat="server" TabIndex="26"></asp:TextBox>
                                    </div>
                                    <div class="form-group">
                                        <p>To Date</p>
                                        <span class="icon-case"><i class="fa fa-calendar"></i></span>
                                        <asp:TextBox ID="txtToDate" runat="server" TabIndex="28"></asp:TextBox>
                                        <cc1:CalendarExtender ID="txtToDateCalendarExtender" runat="server" Enabled="True"
                                            TargetControlID="txtToDate">
                                        </cc1:CalendarExtender>
                                        <asp:CompareValidator ID="CompareValidator1" ValidationGroup="Date" ForeColor="Red"
                                            runat="server" ControlToValidate="txtFromDate" ControlToCompare="txtToDate"
                                            Operator="LessThan" Type="Date" Style="margin: 96px;" ErrorMessage="To Date must be greater than From Date"></asp:CompareValidator>
                                    </div>

                                    <div class="form-group">
                                        <p>SET Password (Remember the password for future reference)</p>
                                        <span class="icon-case"><i class="fa fa-comments-o"></i></span>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtPassword" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                                        <asp:TextBox ID="txtPassword" runat="server" TabIndex="6" TextMode="Password"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </asp:Panel>
                    </div>
                </div>
                <asp:Button ID="btnSubmit" class="btn btn-success" runat="server" Text="Submit Employee Details" OnClick="btnSubmit_Click" Style="width: 20%; position: relative; float: right; margin: auto; margin-right: 5%; margin-bottom: 5%" />

                <asp:Button ID="btnUpdate" class="btn btn-warning" runat="server" Text="Update Employee Details" OnClick="btnSubmit_Click" Visible="false" Style="width: 20%; position: relative; float: right; margin-right: 5%;" />
                <asp:Button ID="btnEdit" runat="server" Text="Edit Employee Details" Visible="false" OnClick="btnEdit_Click" class="btn btn-primary" Style="width: 20%; position: relative; float: right; margin-right: 5%;" />
            </div>
        </div>
        <table class="style1">
            <tr>
                <td></td>
            </tr>
            <tr>
                <td class="auto-style1"></td>
                <td class="style13"></td>
            </tr>
        </table>
    </body>
</asp:Content>
