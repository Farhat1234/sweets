<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="EmployeeProfiles.aspx.cs" Inherits="HumanResourceApplication.Employee_Mgt.EmployeeProfiles" EnableEventValidation="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/UserControls/Navigation.ascx" TagPrefix="uc1" TagName="Navigation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Styles/form.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:Navigation runat="server" ID="Navigation" />
        <div class="row">
            <div class="col-md-12">
                <div class="text-center m-b-md">
                    <h3><b>Employee Profile</b></h3>
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
                                     <asp:TextBox ID="txtDesignation" runat="server" TabIndex="25" Enabled="false"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <p>First Name</p>
                                    <span class="icon-case"><i class="fa fa-user"></i></span>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtEmpFname" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                                    <asp:TextBox ID="txtEmpFname" runat="server" TabIndex="5"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <p>Phone Number</p>
                                    <span class="icon-case"><i class="fa fa-phone"></i></span>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtPhone" ErrorMessage="*" ForeColor="Red" ValidationExpression="[0-9]{10}"></asp:RegularExpressionValidator>
                                    <asp:TextBox ID="txtPhone" runat="server" TabIndex="7"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <p>Date of Joining</p>
                                    <span class="icon-case"><i class="fa fa-calendar"></i></span>
                                    <asp:TextBox ID="txtDOJ" runat="server" TabIndex="9" Enabled="false"></asp:TextBox>
                                    <cc1:CalendarExtender ID="TbDOJ_CalendarExtender" runat="server" Enabled="True"
                                        TargetControlID="txtDOJ">
                                    </cc1:CalendarExtender>
                                </div>
                                <div class="form-group">
                                    <p>Gender</p>
                                    <span class="icon-case"><i class="fa fa-male"></i></span>
                                    <asp:TextBox ID="txtGender" runat="server" TabIndex="9" Enabled="false"></asp:TextBox>
                                </div>
                               <%--<div class="form-group">
                                    <p>Upload Photo</p>
                                    <span class="icon-case"><i class="fa fa-comments-o"></i></span>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="FileUpload1" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                                    <asp:FileUpload ID="FileUpload1" runat="server" OnLoad="FileUpload1_Load1" TabIndex="13" />
                                </div>--%>
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
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmail" ErrorMessage="*" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                    <asp:TextBox ID="txtEmail" runat="server" TabIndex="8" Enabled="false"></asp:TextBox>
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
                                    <p>Designation</p>
                                    <span class="icon-case"><i class="fa fa-info"></i></span>
                                    <asp:TextBox ID="txtNewRole" runat="server" TabIndex="9" Enabled="false"></asp:TextBox>
                                </div>
                                <%--<div class="form-group">
                                    <p>Upload Resume</p>
                                    <span class="icon-case"><i class="fa fa-comments-o"></i></span>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="FileUpload2" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                                    <asp:FileUpload ID="FileUpload2" runat="server" TabIndex="14" />
                                </div>--%>
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
                                    <asp:DropDownList ID="ddlStatePA" runat="server" TabIndex="17" ToolTip="Please Select A State" class="dropdownlist">
                                        <asp:ListItem>--- Select State ---</asp:ListItem>
                                        <asp:ListItem>Andaman &amp; Nicobar Island</asp:ListItem>
                                        <asp:ListItem>Andra Pradesh</asp:ListItem>
                                        <asp:ListItem>Arunachal Pradesh</asp:ListItem>
                                        <asp:ListItem>Assam</asp:ListItem>
                                        <asp:ListItem>Bihar</asp:ListItem>
                                        <asp:ListItem>Chandigarh</asp:ListItem>
                                        <asp:ListItem>Chattisgarh</asp:ListItem>
                                        <asp:ListItem>Dadra &amp; Nagar hardi</asp:ListItem>
                                        <asp:ListItem>Daman &amp; Diu</asp:ListItem>
                                        <asp:ListItem>Delhi</asp:ListItem>
                                        <asp:ListItem>Goa</asp:ListItem>
                                        <asp:ListItem>Gujarat</asp:ListItem>
                                        <asp:ListItem>Haryana</asp:ListItem>
                                        <asp:ListItem>Himachal Pradesh</asp:ListItem>
                                        <asp:ListItem>Jammu &amp; Kashmir</asp:ListItem>
                                        <asp:ListItem>Jharkhand</asp:ListItem>
                                        <asp:ListItem>Karnataka</asp:ListItem>
                                        <asp:ListItem>Kerala</asp:ListItem>
                                        <asp:ListItem>Lakshdeep</asp:ListItem>
                                        <asp:ListItem>Madhya Pradesh</asp:ListItem>
                                        <asp:ListItem>Maharashtra</asp:ListItem>
                                        <asp:ListItem>Manipur</asp:ListItem>
                                        <asp:ListItem>Meghalaya</asp:ListItem>
                                        <asp:ListItem>Mizoram</asp:ListItem>
                                        <asp:ListItem>Nagaland</asp:ListItem>
                                        <asp:ListItem>Orissa</asp:ListItem>
                                        <asp:ListItem>Pondhchary</asp:ListItem>
                                        <asp:ListItem>Punjab</asp:ListItem>
                                        <asp:ListItem>Rajasthan</asp:ListItem>
                                        <asp:ListItem>Sikkim</asp:ListItem>
                                        <asp:ListItem>Tamil Nadu</asp:ListItem>
                                        <asp:ListItem>Tripura</asp:ListItem>
                                        <asp:ListItem>Uttar Pradesh</asp:ListItem>
                                        <asp:ListItem>Uttaranchal</asp:ListItem>
                                        <asp:ListItem>West Bengal</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>

                            <div class="rightcontact">
                                <div class="form-group">
                                    <p>Country</p>
                                    <span class="icon-case"><i class="fa fa-building-o"></i></span>
                                    <asp:TextBox ID="txtCountryPA" runat="server" TabIndex="16" Text="India" Enabled="false"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <p>City</p>
                                    <span class="icon-case"><i class="fa fa-building-o"></i></span>
                                    <asp:DropDownList ID="ddlCityPA" runat="server" TabIndex="18" ToolTip="Please Select A City" class="dropdownlist">
                                        <asp:ListItem>--- Select City ---</asp:ListItem>
                                        <asp:ListItem>--KARNATAKA--</asp:ListItem>
                                        <asp:ListItem>Bangalore</asp:ListItem>
                                        <asp:ListItem>Belgaum</asp:ListItem>
                                        <asp:ListItem>Bellary</asp:ListItem>
                                        <asp:ListItem>Bidar</asp:ListItem>
                                        <asp:ListItem>Dharwad</asp:ListItem>
                                        <asp:ListItem>Gulbarga</asp:ListItem>
                                        <asp:ListItem>Hubli</asp:ListItem>
                                        <asp:ListItem>Kolar</asp:ListItem>
                                        <asp:ListItem>Manglore</asp:ListItem>
                                        <asp:ListItem>Mysore</asp:ListItem>
                                        <asp:ListItem>--KERALA--</asp:ListItem>
                                        <asp:ListItem>Kannur</asp:ListItem>
                                        <asp:ListItem>Kachi</asp:ListItem>
                                        <asp:ListItem>Kollam</asp:ListItem>
                                        <asp:ListItem>Kottayam</asp:ListItem>
                                        <asp:ListItem>Palakkad</asp:ListItem>
                                        <asp:ListItem>Thrissur</asp:ListItem>
                                        <asp:ListItem>Trivandrum</asp:ListItem>
                                        <asp:ListItem>--MADHYA PRADESH--</asp:ListItem>
                                        <asp:ListItem>Bhopal</asp:ListItem>
                                        <asp:ListItem>Gwalior</asp:ListItem>
                                        <asp:ListItem>Indore</asp:ListItem>
                                        <asp:ListItem>Jabalpur</asp:ListItem>
                                        <asp:ListItem>Ujjain</asp:ListItem>
                                        <asp:ListItem>--WEST BENGAL--</asp:ListItem>
                                        <asp:ListItem>Asansol</asp:ListItem>
                                        <asp:ListItem>Durgapur</asp:ListItem>
                                        <asp:ListItem>Haldia</asp:ListItem>
                                        <asp:ListItem>Kharagpur</asp:ListItem>
                                        <asp:ListItem>Kolkata</asp:ListItem>
                                        <asp:ListItem>Silligari</asp:ListItem>
                                        <asp:ListItem>--BIHAR--</asp:ListItem>
                                        <asp:ListItem>Bhagalpur</asp:ListItem>
                                        <asp:ListItem>Patna</asp:ListItem>
                                        <asp:ListItem>--HIMACHAL PRADESH--</asp:ListItem>
                                        <asp:ListItem>Shimla</asp:ListItem>
                                        <asp:ListItem>Dharmasala</asp:ListItem>
                                        <asp:ListItem>Kulu</asp:ListItem>
                                        <asp:ListItem>--ORISSA--</asp:ListItem>
                                        <asp:ListItem>Bhubaneshwar</asp:ListItem>
                                        <asp:ListItem>Cuttack</asp:ListItem>
                                        <asp:ListItem>Paradeep</asp:ListItem>
                                        <asp:ListItem>Puri</asp:ListItem>
                                        <asp:ListItem>Kourkela</asp:ListItem>
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
                                    <asp:DropDownList ID="ddlStateCA" runat="server" TabIndex="21" ToolTip="Please Select A State" class="dropdownlist">
                                        <asp:ListItem Text="--- Select State ---" Value="-1"></asp:ListItem>
                                        <asp:ListItem>Andaman &amp; Nicobar Island</asp:ListItem>
                                        <asp:ListItem>Andra Pradesh</asp:ListItem>
                                        <asp:ListItem>Arunachal Pradesh</asp:ListItem>
                                        <asp:ListItem>Assam</asp:ListItem>
                                        <asp:ListItem>Bihar</asp:ListItem>
                                        <asp:ListItem>Chandigarh</asp:ListItem>
                                        <asp:ListItem>Chattisgarh</asp:ListItem>
                                        <asp:ListItem>Dadra &amp; Nagar hardi</asp:ListItem>
                                        <asp:ListItem>Daman &amp; Diu</asp:ListItem>
                                        <asp:ListItem>Delhi</asp:ListItem>
                                        <asp:ListItem>Goa</asp:ListItem>
                                        <asp:ListItem>Gujarat</asp:ListItem>
                                        <asp:ListItem>Haryana</asp:ListItem>
                                        <asp:ListItem>Himachal Pradesh</asp:ListItem>
                                        <asp:ListItem>Jammu &amp; Kashmir</asp:ListItem>
                                        <asp:ListItem>Jharkhand</asp:ListItem>
                                        <asp:ListItem>Karnataka</asp:ListItem>
                                        <asp:ListItem>Kerala</asp:ListItem>
                                        <asp:ListItem>Lakshdeep</asp:ListItem>
                                        <asp:ListItem>Madhya Pradesh</asp:ListItem>
                                        <asp:ListItem>Maharashtra</asp:ListItem>
                                        <asp:ListItem>Manipur</asp:ListItem>
                                        <asp:ListItem>Meghalaya</asp:ListItem>
                                        <asp:ListItem>Mizoram</asp:ListItem>
                                        <asp:ListItem>Nagaland</asp:ListItem>
                                        <asp:ListItem>Orissa</asp:ListItem>
                                        <asp:ListItem>Pondhchary</asp:ListItem>
                                        <asp:ListItem>Punjab</asp:ListItem>
                                        <asp:ListItem>Rajasthan</asp:ListItem>
                                        <asp:ListItem>Sikkim</asp:ListItem>
                                        <asp:ListItem>Tamil Nadu</asp:ListItem>
                                        <asp:ListItem>Tripura</asp:ListItem>
                                        <asp:ListItem>Uttar Pradesh</asp:ListItem>
                                        <asp:ListItem>Uttaranchal</asp:ListItem>
                                        <asp:ListItem>West Bengal</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>

                            <div class="rightcontact">
                                <div class="form-group">
                                    <p>Country</p>
                                    <span class="icon-case"><i class="fa fa-building-o"></i></span>
                                    <asp:TextBox ID="txtCountryCA" runat="server" TabIndex="20" Text="India" Enabled="false"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <p>City</p>
                                    <span class="icon-case"><i class="fa fa-building-o"></i></span>
                                    <asp:DropDownList ID="ddlCityCA" runat="server" TabIndex="22" ToolTip="Please Select A City" class="dropdownlist">
                                        <asp:ListItem>--- Select City ---</asp:ListItem>
                                        <asp:ListItem>--KARNATAKA--</asp:ListItem>
                                        <asp:ListItem>Bangalore</asp:ListItem>
                                        <asp:ListItem>Belgaum</asp:ListItem>
                                        <asp:ListItem>Bellary</asp:ListItem>
                                        <asp:ListItem>Bidar</asp:ListItem>
                                        <asp:ListItem>Dharwad</asp:ListItem>
                                        <asp:ListItem>Gulbarga</asp:ListItem>
                                        <asp:ListItem>Hubli</asp:ListItem>
                                        <asp:ListItem>Kolar</asp:ListItem>
                                        <asp:ListItem>Manglore</asp:ListItem>
                                        <asp:ListItem>Mysore</asp:ListItem>
                                        <asp:ListItem>--KERALA--</asp:ListItem>
                                        <asp:ListItem>Kannur</asp:ListItem>
                                        <asp:ListItem>Kachi</asp:ListItem>
                                        <asp:ListItem>Kollam</asp:ListItem>
                                        <asp:ListItem>Kottayam</asp:ListItem>
                                        <asp:ListItem>Palakkad</asp:ListItem>
                                        <asp:ListItem>Thrissur</asp:ListItem>
                                        <asp:ListItem>Trivandrum</asp:ListItem>
                                        <asp:ListItem>--MADHYA PRADESH--</asp:ListItem>
                                        <asp:ListItem>Bhopal</asp:ListItem>
                                        <asp:ListItem>Gwalior</asp:ListItem>
                                        <asp:ListItem>Indore</asp:ListItem>
                                        <asp:ListItem>Jabalpur</asp:ListItem>
                                        <asp:ListItem>Ujjain</asp:ListItem>
                                        <asp:ListItem>--WEST BENGAL--</asp:ListItem>
                                        <asp:ListItem>Asansol</asp:ListItem>
                                        <asp:ListItem>Durgapur</asp:ListItem>
                                        <asp:ListItem>Haldia</asp:ListItem>
                                        <asp:ListItem>Kharagpur</asp:ListItem>
                                        <asp:ListItem>Kolkata</asp:ListItem>
                                        <asp:ListItem>Silligari</asp:ListItem>
                                        <asp:ListItem>--BIHAR--</asp:ListItem>
                                        <asp:ListItem>Bhagalpur</asp:ListItem>
                                        <asp:ListItem>Patna</asp:ListItem>
                                        <asp:ListItem>--HIMACHAL PRADESH--</asp:ListItem>
                                        <asp:ListItem>Shimla</asp:ListItem>
                                        <asp:ListItem>Dharmasala</asp:ListItem>
                                        <asp:ListItem>Kulu</asp:ListItem>
                                        <asp:ListItem>--ORISSA--</asp:ListItem>
                                        <asp:ListItem>Bhubaneshwar</asp:ListItem>
                                        <asp:ListItem>Cuttack</asp:ListItem>
                                        <asp:ListItem>Paradeep</asp:ListItem>
                                        <asp:ListItem>Puri</asp:ListItem>
                                        <asp:ListItem>Kourkela</asp:ListItem>
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
                                    </div>
                                </div>
                            </div>
                        </asp:Panel>
                    </div>
                </div>
                <asp:Button ID="btnSubmit" class="btn btn-success" runat="server" Text="Submit Employee Details" OnClick="btnSubmit_Click" Style="width: 20%; position:relative;float:right;margin:auto;margin-right:5%;margin-bottom:5%" />
                
                <asp:Button ID="btnUpdate" class="btn btn-warning" runat="server" Text="Update Employee Details" OnClick="btnUpdate_Click" Visible="false" Style="width: 20%; position:relative;float:right;margin-right:5%;" />
                <asp:Button ID="btnEdit" runat="server" Text="Edit Employee Details" Visible="false" OnClick="btnEdit_Click"  class="btn btn-primary" Style="width: 20%; position:relative;float:right;margin-right:5%;"/>
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
</asp:Content>
