<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="EmployeeIDProof.aspx.cs" Inherits="HumanResourceApplication.EmployeeMgt.EmployeeIDProof" %>

<%@ Register Src="~/UserControls/Navigation.ascx" TagPrefix="uc1" TagName="Navigation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:Navigation runat="server" ID="Navigation" />
    <div class="row">
        <div class="col-md-12">
            <div class="text-center m-b-md">
                <h3><b>Identity Proof Details</b></h3>
            </div>
            <div class="hpanel">
                <div class="panel-body">
                    <div class="contentform">
                        <div id="sendmessage">Your message has been sent successfully. Thank you. </div>
                        <div class="leftcontact">
                            <div class="form-group">
                                <p>Permananet Account Number (PAN)</p>
                                <span class="icon-case"><i class="fa fa-info"></i></span>
                                <asp:TextBox ID="txtPAN" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="txtPAN" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                                <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtPAN" Display="Dynamic" ForeColor="Red" ErrorMessage="InValid PAN Card" ValidationExpression="[A-Z]{5}\d{4}[A-Z]{1}"></asp:RegularExpressionValidator>--%>
                            </div>
                            <div class="form-group">
                                <p>Permananet Retired Account Number (PRAN)</p>
                                <span class="icon-case"><i class="fa fa-info"></i></span>
                                <asp:TextBox ID="txtPRAN" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtPRAN" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>
                            <div class="form-group">
                                <p>Universal Account Number (UAN)</p>
                                <span class="icon-case"><i class="fa fa-info"></i></span>
                                <asp:TextBox ID="txtUAN" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtUAN" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                                <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtPAN" Display="Dynamic" ForeColor="Red" ErrorMessage="InValid PAN Card" ValidationExpression="[0-9]{12}"></asp:RegularExpressionValidator>--%>
                            </div>
                            <div class="form-group">
                                <p>Adhaar Card Number</p>
                                <span class="icon-case"><i class="fa fa-info"></i></span>
                                <asp:TextBox ID="txtAadhaar" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtAadhaar" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="rightcontact">
                            <div class="form-group">
                                <p>Voter's ID Number</p>
                                <span class="icon-case"><i class="fa fa-info"></i></span>
                                <asp:TextBox ID="txtVoters" runat="server" TabIndex="2"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <p>Driving License Number</p>
                                <span class="icon-case"><i class="fa fa-info"></i></span>
                                <asp:TextBox ID="txtDriving" runat="server" TabIndex="4"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <p>ESIC Card Number</p>
                                <span class="icon-case"><i class="fa fa-info"></i></span>
                                <asp:TextBox ID="txtESIC" runat="server" TabIndex="6"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <asp:Button ID="btnSubmit" OnClick="btnSubmit_Click" class="btn btn-success" runat="server" Text="Save Identity Proof Details" Style="float: right; width: 25%" />
                    <asp:Button ID="btnEdit" OnClick="btnEdit_Click" class="btn btn-success" runat="server" Text="Edit Details" Style="float: right; width: 25%" Visible="false" />
                    <asp:Button ID="btnUpdate" OnClick="btnUpdate_Click" class="btn btn-success" runat="server" Text="Update Details" Style="float: right; width: 25%" Visible="false" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
