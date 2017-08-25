using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HumanResourceApplication.EmployeeMgt
{
    public partial class ViewEmployeeProfile : System.Web.UI.Page
    {
        HRMBAL.BALService Proxy;

        protected void Page_Load(object sender, EventArgs e)
        {
            Proxy = new HRMBAL.BALService();

            int empid = Convert.ToInt32(Request.QueryString["EmpId"]);

            if (!IsPostBack)
            {
                ddlEmployeeName.DataSource = Proxy.GetEmpName();
                ddlEmployeeName.DataTextField = "EmpName";
                ddlEmployeeName.DataValueField = "EmpName";
                ddlEmployeeName.DataBind();
                ddlEmployeeName.Items.Insert(0, new ListItem("-- Select --", "0"));
            }

        }

        protected void ddlEmployeeName_SelectedIndexChanged(object sender, EventArgs e)
        {
            ltrEducation.Visible = true;
            ltrEmployee.Visible = true;
            ltrNomination.Visible = true;
            ltrPassport.Visible = true;
            ltrReimburse.Visible = true;
            ltrSavings.Visible = true;
            ltrIDProof.Visible = true;

            string ddlVlaue = ddlEmployeeName.SelectedItem.Text;

            if (ddlVlaue == "-- Select --")
            {
                // Do Nothing
            }
            else
            {
                string[] ddlSelect = ddlVlaue.Split(',');

                DataSet ds = Proxy.GetEducationById(Convert.ToInt32(ddlSelect[1]));
                grdEducationDetails.DataSource = ds;
                grdEducationDetails.DataBind();

                DataSet dsNom = Proxy.GetFamilyNomination(Convert.ToInt32(ddlSelect[1]));
                grdFamilyNominations.DataSource = dsNom;
                grdFamilyNominations.DataBind();

                DataSet dsSav = Proxy.GetBankById(Convert.ToInt32(ddlSelect[1]));
                grdSavings.DataSource = dsSav;
                grdSavings.DataBind();

                DataSet dsRem = Proxy.GetReimburseBankById(Convert.ToInt32(ddlSelect[1]));
                grdReimburse.DataSource = dsRem;
                grdReimburse.DataBind();

                DataSet dsPass = Proxy.GetEmployeePassport(Convert.ToInt32(ddlSelect[1]));
                grdPassport.DataSource = dsPass;
                grdPassport.DataBind();

                DataSet dsID = Proxy.GetIDProofDetails(Convert.ToInt32(ddlSelect[1]));
                grdIDProof.DataSource = dsID;
                grdIDProof.DataBind();

                DataSet dsEmp = Proxy.GetEmpDetails(Convert.ToInt32(ddlSelect[1]));
                grdEmployeeDetails.DataSource = dsEmp;
                grdEmployeeDetails.DataBind();
            }          

        }
    }
}