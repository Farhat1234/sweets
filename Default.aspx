<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="HumanResourceApplication.EmployeeDataBank" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/UserControls/Navigation.ascx" TagPrefix="uc1" TagName="Navigation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <style type="text/css">
        .nav-label:hover {
            color: #000000;
        }

        #ContentPlaceHolder1_gvHolidayList {
            width: 430px;
            height: 260px;
            text-align: center;
        }

        #ContentPlaceHolder1_Panel1 {
            width: 450px;
            height: 300px;
        }
        /*Panel tabs*/
        .panel-tabs {
            position: relative;
            bottom: 30px;
            clear: both;
            border-bottom: 1px solid transparent;
        }

            .panel-tabs > li {
                float: left;
                margin-bottom: -1px;
            }

                .panel-tabs > li > a {
                    margin-right: 2px;
                    margin-top: 4px;
                    line-height: .85;
                    border: 1px solid transparent;
                    border-radius: 4px 4px 0 0;
                    color: #ffffff;
                }

                    .panel-tabs > li > a:hover {
                        border-color: transparent;
                        color: #ffffff;
                        background-color: transparent;
                    }

                .panel-tabs > li.active > a,
                .panel-tabs > li.active > a:hover,
                .panel-tabs > li.active > a:focus {
                    color: #fff;
                    cursor: default;
                    -webkit-border-radius: 2px;
                    -moz-border-radius: 2px;
                    border-radius: 2px;
                    background-color: rgba(255,255,255, .23);
                    border-bottom-color: transparent;
                }

        .panel-primary > .panel-heading {
            color: #fff;
            background-color: #bfbfbf;
            border-color: #898989;
        }

        .panel-primary {
            border-color: #e6e6e6;
        }

        h2 {
            color: #1f5671;
            font-weight: 500;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:Navigation runat="server" ID="Navigation" />
    <div class="row">
        <div class="col-lg-12 text-center welcome-message">
            </br>
                </br>
                <h2>Welcome to EXCEL Human Resource Management System
                </h2>

            </br>
                </br>
        </div>
    </div>
    <div class="row">
        <div class="col-lg-3">
            <a href="EmployeeMgt/EmployeeHome.aspx">
                <div class="hpanel">
                    <div class="panel-body text-center h-200" style="background-color: #73f581; border-radius: 16px;">
                        <a href='../EmployeeMgt/EmployeeProfiles.aspx?EmpId=<%=Request.QueryString["EmpId"] %>'>
                            <img src="Images/pr.png" style="height: 65px;">
                            <h3 class="font-extra-bold no-margins text-success">PROFILE
                            </h3>
                            </a>
                    </div>
                </div>
            </a>
        </div>
        <div class="col-lg-3">
            <div class="hpanel">
                <div class="panel-body text-center h-200" style="background-color: #e04346; border-radius: 16px;">
                    <a href='../AttendanceMgt/ConsolidateAttandance.aspx?EmpId=<%=Request.QueryString["EmpId"] %>'>
                        <img src="Images/planer.png" style="height: 66px;">
                        <br />
                        <h3 class="font-extra-bold no-margins text-success">ATTENDANCE
                        </h3>
                </div>
            </div>
        </div>
        <div class="col-lg-3">
            <div class="hpanel">
                <div class="panel-body text-center h-200" style="background-color: #0e868a; border-radius: 16px;">
                    <a href='../LeaveMgt/ApplyLeave.aspx?EmpId=<%=Request.QueryString["EmpId"] %>'>
                        <img src="Images/leave.png" style="height: 65px;">
                        <br />
                        <h3 class="font-extra-bold no-margins text-success">LEAVE
                        </h3>
                </div>
            </div>
        </div>
        <div class="col-lg-3">
            <div class="hpanel">
                <div class="panel-body text-center h-200" style="background-color: goldenrod; border-radius: 16px;">
                    <a href='../LeaveMgt/HolidayList.aspx?EmpId=<%=Request.QueryString["EmpId"] %>'>
                    <img src="Images/cal.png" style="height: 65px;">
                    <br />
                    <h3 class="font-extra-bold no-margins text-success">HOLIDAY LIST
                    </h3>
                        </a>
                </div>
            </div>
        </div>

    </div>
</asp:Content>
