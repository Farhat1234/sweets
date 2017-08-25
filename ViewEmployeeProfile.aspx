<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="ViewEmployeeProfile.aspx.cs" Inherits="HumanResourceApplication.EmployeeMgt.ViewEmployeeProfile" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/UserControls/Navigation.ascx" TagPrefix="uc1" TagName="Navigation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        #ContentPlaceHolder1_grdSavings {
            width: 100%;
            height: 70px;
            text-align: center;
            margin-bottom: 35px;
        }

        #ContentPlaceHolder1_grdReimburse {
            width: 100%;
            height: 70px;
            text-align: center;
            margin-bottom: 35px;
        }

        #ContentPlaceHolder1_grdIDProof {
            width: 100%;
            height: 70px;
            text-align: center;
            margin-bottom: 35px;
        }

        #ContentPlaceHolder1_grdEducationDetails {
            width: 100%;
            height: 70px;
            text-align: center;
            margin-bottom: 35px;
        }

        #ContentPlaceHolder1_grdFamilyNominations {
            width: 100%;
            height: 70px;
            text-align: center;
            margin-bottom: 35px;
        }

        #ContentPlaceHolder1_grdPassport {
            width: 100%;
            height: 70px;
            text-align: center;
            margin-bottom: 35px;
        }

        #ContentPlaceHolder1_grdEmployeeDetails {
            width: 100%;
            height: 70px;
            text-align: center;
            margin-bottom: 35px;
        }

        tr {
            height: 30px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:Navigation runat="server" ID="Navigation" />
    <div class="row">
        <div class="col-md-12">
            <div class="text-center m-b-md">
                <h3><b>Employee Profile</b></h3>
            </div>
            <div class="hpanel">
                <div class="panel-body">
                    <div class="contentform">
                        <div class="leftcontact">
                            <div class="form-group">
                                <p>Employee Name</p>
                                <span class="icon-case"><i class="fa fa-info"></i></span>
                                <asp:DropDownList runat="server" ID="ddlEmployeeName" class="dropdownlist" TabIndex="12" OnSelectedIndexChanged="ddlEmployeeName_SelectedIndexChanged" AutoPostBack="true">
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <!-- employee details-->
            <div>
                <h4>
                    <asp:Literal ID="ltrEmployee" runat="server" Text="Personal Details" Visible="false"></asp:Literal></h4>
                <asp:GridView runat="server" ID="grdEmployeeDetails" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="Both"
                    ShowHeaderWhenEmpty="True" EmptyDataText="No records Found"
                    RowStyle-HorizontalAlign="Center" HorizontalAlign="Center">
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <EditRowStyle BackColor="#999999" />
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#4cc9ce" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#E9E7E2" />
                    <SortedAscendingHeaderStyle BackColor="#506C8C" />
                    <SortedDescendingCellStyle BackColor="#FFFDF8" />
                    <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                    <Columns>
                        <asp:BoundField DataField="EFname" HeaderText="Employee FirstName" />
                        <asp:BoundField DataField="ELname" HeaderText="Employee LastName" />
                        <asp:BoundField DataField="DOJ" HeaderText="Date of Joining" DataFormatString="{0: dd MMM yyyy}" />
                        <asp:BoundField DataField="DOB" HeaderText="Date of Birth" DataFormatString="{0: dd MMM yyyy}" />
                        <asp:BoundField DataField="Email" HeaderText="Email" />
                        <asp:BoundField DataField="Department" HeaderText="Department" />
                        <asp:BoundField DataField="ReportingManager" HeaderText="Reporting Manager" />
                    </Columns>
                </asp:GridView>
            </div>

            <!-- bank details-->
            <div>
                <h4>
                    <asp:Literal ID="ltrSavings" runat="server" Text="Savings Account" Visible="false"></asp:Literal></h4>
                <asp:GridView runat="server" ID="grdSavings" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="Both"
                    ShowHeaderWhenEmpty="True" EmptyDataText="No records Found"
                    RowStyle-HorizontalAlign="Center" HorizontalAlign="Center">
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <EditRowStyle BackColor="#999999" />
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#4cc9ce" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#E9E7E2" />
                    <SortedAscendingHeaderStyle BackColor="#506C8C" />
                    <SortedDescendingCellStyle BackColor="#FFFDF8" />
                    <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                    <Columns>
                        <asp:BoundField DataField="SavingsAccountType" HeaderText="Account Type" />
                        <asp:BoundField DataField="SavingsAccountNo" HeaderText="Account No" />
                        <asp:BoundField DataField="AccountHolderName" HeaderText="Account Holder Name" />
                        <asp:BoundField DataField="SavingsBankName" HeaderText="Bank Name" />
                        <asp:BoundField DataField="Branch" HeaderText="Branch" />
                        <asp:BoundField DataField="SavingsCountry" HeaderText="Country" />
                        <asp:BoundField DataField="SavingsIFSC" HeaderText="IFSC Code" />
                    </Columns>
                </asp:GridView>
            </div>
            <div>
                <h4>
                    <asp:Literal ID="ltrReimburse" runat="server" Text="Reimburse Account" Visible="false"></asp:Literal></h4>
                <asp:GridView runat="server" ID="grdReimburse" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="Both"
                    ShowHeaderWhenEmpty="True" EmptyDataText="No records Found"
                    RowStyle-HorizontalAlign="Center" HorizontalAlign="Center">
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <EditRowStyle BackColor="#999999" />
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#4cc9ce" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#E9E7E2" />
                    <SortedAscendingHeaderStyle BackColor="#506C8C" />
                    <SortedDescendingCellStyle BackColor="#FFFDF8" />
                    <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                    <Columns>
                        <asp:BoundField DataField="ReimburseAccountType" HeaderText="Account Type" />
                        <asp:BoundField DataField="ReimburseAccountNo" HeaderText="Account No" />
                        <asp:BoundField DataField="ReimburseAccHolder" HeaderText="Account Holder Name" />
                        <asp:BoundField DataField="ReimburseBankName" HeaderText="Bank Name" />
                        <asp:BoundField DataField="ReimburseBranch" HeaderText="Branch" />
                        <asp:BoundField DataField="ReimburseCountry" HeaderText="Country" />
                        <asp:BoundField DataField="ReimburseIFSC" HeaderText="IFSC Code" />
                    </Columns>
                </asp:GridView>
            </div>

            <!-- idproof details-->
            <div>
                <h4>
                    <asp:Literal ID="ltrIDProof" runat="server" Text="ID Proof Details" Visible="false"></asp:Literal></h4>
                <asp:GridView runat="server" ID="grdIDProof" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="Both"
                    ShowHeaderWhenEmpty="True" EmptyDataText="No records Found"
                    RowStyle-HorizontalAlign="Center" HorizontalAlign="Center">
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <EditRowStyle BackColor="#999999" />
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#4cc9ce" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#E9E7E2" />
                    <SortedAscendingHeaderStyle BackColor="#506C8C" />
                    <SortedDescendingCellStyle BackColor="#FFFDF8" />
                    <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                    <Columns>
                        <asp:BoundField DataField="Aadhar" HeaderText="Aadhar" />
                        <asp:BoundField DataField="PAN" HeaderText="PAN" />
                        <asp:BoundField DataField="PRAN" HeaderText="PRAN" />
                        <asp:BoundField DataField="UAN" HeaderText="UAN" />
                        <asp:BoundField DataField="DrivingLicense" HeaderText="DrivingLicense" />
                        <asp:BoundField DataField="ESIC" HeaderText="ESIC" />
                        <asp:BoundField DataField="VoterID" HeaderText="VoterID" />
                    </Columns>
                </asp:GridView>
            </div>

            <!-- education details-->
            <div>
                <h4>
                    <asp:Literal ID="ltrEducation" runat="server" Text="Education Details" Visible="false"></asp:Literal></h4>
                <asp:GridView runat="server" ID="grdEducationDetails" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="Both"
                    ShowHeaderWhenEmpty="True" EmptyDataText="No records Found"
                    RowStyle-HorizontalAlign="Center" HorizontalAlign="Center">
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <EditRowStyle BackColor="#999999" />
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#4cc9ce" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#E9E7E2" />
                    <SortedAscendingHeaderStyle BackColor="#506C8C" />
                    <SortedDescendingCellStyle BackColor="#FFFDF8" />
                    <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                    <Columns>
                        <asp:BoundField DataField="Education" HeaderText="Education" />
                        <asp:BoundField DataField="BranchStudy1" HeaderText="Branch of Study" />
                        <asp:BoundField DataField="NameofInstitute" HeaderText="Name of Institute" />
                        <asp:BoundField DataField="DurationOfCourse" HeaderText="Duration of Course" />
                    </Columns>
                </asp:GridView>
            </div>
            <!-- nomination details-->
            <div>
                <h4>
                    <asp:Literal ID="ltrNomination" runat="server" Text="Family & Nomination Details" Visible="false"></asp:Literal></h4>
                <asp:GridView ID="grdFamilyNominations" runat="server" AutoGenerateColumns="False" GridLines="Both"
                    ShowHeaderWhenEmpty="True" EmptyDataText="No records Found"
                    RowStyle-HorizontalAlign="Center" HorizontalAlign="Center">
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <EditRowStyle BackColor="#999999" />
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#4cc9ce" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#E9E7E2" />
                    <SortedAscendingHeaderStyle BackColor="#506C8C" />
                    <SortedDescendingCellStyle BackColor="#FFFDF8" />
                    <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                    <Columns>                       
                        <asp:BoundField DataField="Relation" HeaderText="Relation"/>
                        <asp:BoundField DataField="Initials" HeaderText="Initials" />
                        <asp:BoundField DataField="FirstName" HeaderText="FirstName" />
                        <asp:BoundField DataField="LastName" HeaderText="LastName" />
                        <asp:BoundField DataField="Gender" HeaderText="Gender" />   
                        <asp:BoundField DataField="Nationality" HeaderText="Nationality" />                    
                    </Columns>
                </asp:GridView>
            </div>

            <!-- passport details-->
            <div>
                <h4>
                    <asp:Literal ID="ltrPassport" runat="server" Text="Passport Details" Visible="false"></asp:Literal></h4>
                <asp:GridView ID="grdPassport" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="Both"
                    ShowHeaderWhenEmpty="True" EmptyDataText="No records Found"
                    RowStyle-HorizontalAlign="Center" HorizontalAlign="Center">
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <EditRowStyle BackColor="#999999" />
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#4cc9ce" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#E9E7E2" />
                    <SortedAscendingHeaderStyle BackColor="#506C8C" />
                    <SortedDescendingCellStyle BackColor="#FFFDF8" />
                    <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                    <Columns>
                        <asp:BoundField DataField="PassportFor" HeaderText="Passport For" SortExpression="PassportFor" />
                        <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                        <asp:BoundField DataField="Gender" HeaderText="Gender" SortExpression="Gender" />
                        <asp:BoundField DataField="Nationality" HeaderText="Nationality" SortExpression="Nationality" />
                        <asp:BoundField DataField="PassportIssuingCountry" HeaderText="Passport Issuing Country" SortExpression="PassportIssuingCountry" />
                        <asp:BoundField DataField="IssueDate" HeaderText="Issue Date" SortExpression="IssueDate" DataFormatString="{0: dd MMM yyyy}" />
                        <asp:BoundField DataField="ExpiryDate" HeaderText="Expiry Date" SortExpression="ExpiryDate" DataFormatString="{0: dd MMM yyyy}" />
                        <asp:BoundField DataField="PlaceofIssue" HeaderText="Place of Issue" SortExpression="PlaceofIssue" />
                    </Columns>
                </asp:GridView>
            </div>

        </div>
    </div>
</asp:Content>
