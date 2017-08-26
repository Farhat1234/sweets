using HRMWcfService1.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HumanResourceApplication.EmployeeMgt
{
    public partial class EmployeeRegisteration : System.Web.UI.Page
    {
        HRMBAL.BALService Proxy;
        HRMDAL.Entites.Employee Employ;

        protected void Page_Load(object sender, EventArgs e)
        {
            Proxy = new HRMBAL.BALService();
            Employ = new HRMDAL.Entites.Employee();

            //string empid = Request.QueryString["EmpId"].ToString();
            //txtEmpID.Text = return_number().ToString();
            if (!IsPostBack)
            {
                ddlDepartment.DataSource = Proxy.GetDepartments();
                ddlDepartment.DataTextField = "DepartmentType";
                ddlDepartment.DataValueField = "DepartmentID";
                ddlDepartment.DataBind();
                ddlDepartment.Items.Insert(0, new ListItem("-- Select --", "0"));

                ddlReportingManager.DataSource = Proxy.GetReportingManagers();
                ddlReportingManager.DataTextField = "EmpName";
                ddlReportingManager.DataValueField = "EmpName";
                ddlReportingManager.DataBind();
                ddlReportingManager.Items.Insert(0, new ListItem("-- Select --", "0"));

                ddlNewRole.DataSource = Proxy.GetAllDesignations();
                ddlNewRole.DataTextField = "DesignationType";
                ddlNewRole.DataValueField = "DesignationID";
                ddlNewRole.DataBind();
                ddlNewRole.Items.Insert(0, new ListItem("-- Select --", "0"));
            }           
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Employ.EmpID = Convert.ToInt32(txtEmpID.Text);
            Employ.FirstName = txtEmpName.Text;
            Employ.DOJ = Convert.ToDateTime(txtDOJ.Text);
            Employ.Designation = Convert.ToInt32(ddlRole.SelectedValue);
            Employ.Department = ddlDepartment.SelectedItem.Text;
            Employ.Email = txtEmail.Text;
            Employ.ReportingManager = ddlReportingManager.SelectedItem.Text;
            Employ.Role = ddlNewRole.SelectedItem.Text;
            Proxy.EmployeeRegistration(Employ);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Employee Registered')", true);
            string body = "<table style='Border:inset';><tr ><td style='Border:inset';>Login Id</td><td style='Border:inset';>Password</td></tr><tr><td>'" + txtEmpID.Text + "'</td><td>Jamsons</td></tr></table>";
            string toEmail=txtEmail.Text;
            Utility.SendMail(toEmail, "ajrekarfarhat@gmail.com", null, "LoginCredentials", body);
            ClearFields();
        }

        public void ClearFields()
        {
            txtEmpID.Text = string.Empty;
            txtEmpName.Text = string.Empty;
            txtDOJ.Text = string.Empty;
            ddlRole.SelectedValue = "-1";
            txtEmail.Text = string.Empty;
            ddlDepartment.SelectedValue = "0";
            ddlReportingManager.SelectedValue = "0";
            ddlNewRole.SelectedValue = "0";
        }

        //public static Int32 i = 0;
        //public Int32 return_number()
        //{
        //    i++;
        //    return i;
        //}
    }
}