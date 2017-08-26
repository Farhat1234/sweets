using HRMWcfService1.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HumanResourceApplication.Employee_Mgt
{

    public partial class EmployeeProfiles : System.Web.UI.Page
    {
        //HRMRef.Service1Client Proxy;
        //HRMRef.Employee Employ;

        HRMBAL.BALService Proxy;
        HRMDAL.Entites.Employee Employ;

        protected void Page_Load(object sender, EventArgs e)
        {
            Proxy = new HRMBAL.BALService();
            Employ = new HRMDAL.Entites.Employee();

            txtEmpID.Text = Request.QueryString["EmpId"].ToString();
            bool result = Proxy.CheckEmpId(Convert.ToInt32(Request.QueryString["EmpId"]));

            DataSet details = Proxy.GetDetailsEmployeeRegistration(Convert.ToInt32(Request.QueryString["EmpId"]));

            txtDOJ.Text = Convert.ToDateTime(details.Tables[0].Rows[0][0]).ToString("dd MMM yyyy");
            txtDepartment.Text = details.Tables[0].Rows[0][1].ToString();
            txtDesignation.Text = details.Tables[0].Rows[0][2].ToString();
            txtEmail.Text = details.Tables[0].Rows[0][3].ToString();
            txtRM.Text = details.Tables[0].Rows[0][4].ToString();

            if (result && !IsPostBack)
            {
                GetEmpDetails(Convert.ToInt32(Request.QueryString["EmpId"]));
                GetVisibilty();
            }
            else
            {
                //Do Nothing
            }
        }

        protected void FileUpload1_Load1(object sender, EventArgs e)
        {
            //if (FileUpload1.HasFile)
            //{
            //    System.IO.Stream fs = FileUpload1.PostedFile.InputStream;
            //    System.IO.BinaryReader br = new System.IO.BinaryReader(fs);
            //    Byte[] bytes = br.ReadBytes((Int32)fs.Length);
            //    Employ.Photo = bytes;
            //    string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
            //    Employ.Photo = bytes;
            //}
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                string[] base64String = new string[0];
                Employ.EmpID = Convert.ToInt32(Request.QueryString["EmpId"]);
                Employ.FirstName = txtEmpFname.Text;
                Employ.LastName = txtEmpLname.Text;
                Employ.DOJ = Convert.ToDateTime(txtDOJ.Text);
                Employ.DOB = Convert.ToDateTime(txtDOB.Text);
                Employ.Gender = txtGender.Text;
                Employ.PAddress = txtAddressPA.Text;
                Employ.PCity = ddlCityPA.SelectedItem.Text;
                Employ.CCountry = txtCountryCA.Text;
                Employ.PCountry = txtCountryPA.Text;
                Employ.PState = ddlStatePA.SelectedItem.Text;
                Employ.Phone = Convert.ToDecimal(txtPhone.Text);
                Employ.CAddress = txtAddressCA.Text;
                Employ.CCity = ddlCityCA.SelectedItem.Text;
                Employ.CState = ddlStateCA.SelectedItem.Text;
                Employ.Email = txtEmail.Text;
                Employ.Designation = int.Parse(txtDesignation.Text);
                Employ.Department = txtDepartment.Text;
                Employ.FromDate = Convert.ToDateTime(txtFromDate.Text);
                Employ.ToDate = Convert.ToDateTime(txtToDate.Text);
                Employ.PreviousCompany = txtPreviousCompany.Text;
                Employ.PreviousContactNumber = Convert.ToDecimal(txtRefNumber.Text);
                Employ.PreviousDesignation = txtPreviousDesignation.Text;
                Employ.PreviousContactPerson = txtContactPersonName.Text;
                Employ.ReportingManager = txtRM.Text;
                Proxy.AddEmployee(Employ);
                Response.Redirect("Default.aspx?EmpId=" + Request.QueryString["EmpId"]);
            }
            catch (Exception ex)
            {                
                throw ex;
            }
            
        }


        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                Employ.EmpID = Convert.ToInt32(Request.QueryString["EmpId"]);
                Employ.LastName = txtEmpLname.Text;
                Employ.PAddress = txtAddressPA.Text;
                Employ.PCity = ddlCityPA.SelectedItem.Text;
                Employ.CCountry = txtCountryCA.Text;
                Employ.PCountry = txtCountryPA.Text;
                Employ.PState = ddlStatePA.SelectedItem.Text;
                Employ.Phone = Convert.ToDecimal(txtPhone.Text);
                Employ.CAddress = txtAddressCA.Text;
                Employ.CCity = ddlCityCA.SelectedItem.Text;
                Employ.CState = ddlStateCA.SelectedItem.Text;
                Proxy.AddEmployee(Employ);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Records Updated Successfully')", true);
                btnUpdate.Visible = false;
                btnEdit.Visible = true;
                txtEmpLname.Enabled = false;
                txtPhone.Enabled = false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void GetEmpDetails(int empid)
        {
            DataSet ds = new DataSet(); 
            ds = Proxy.GetEmployeeInfo(empid);

            DataSet details = Proxy.GetDetailsEmployeeRegistration(Convert.ToInt32(Request.QueryString["EmpId"]));

            txtEmpID.Text = ds.Tables[0].Rows[0][0].ToString();
            txtEmpFname.Text = ds.Tables[0].Rows[0][1].ToString();
            txtEmpLname.Text = ds.Tables[0].Rows[0][2].ToString();
            txtDOJ.Text = Convert.ToDateTime(details.Tables[0].Rows[0][0]).ToString("dd MMM yyyy");
            txtDOB.Text = Convert.ToDateTime(ds.Tables[0].Rows[0][4]).ToString("dd MMM yyyy");
            txtAddressPA.Text = ds.Tables[0].Rows[0][6].ToString();
            ddlCityPA.SelectedItem.Text = ds.Tables[0].Rows[0][7].ToString();
            ddlStatePA.SelectedItem.Text = ds.Tables[0].Rows[0][8].ToString();
            txtPhone.Text = ds.Tables[0].Rows[0][9].ToString();
            txtEmail.Text = details.Tables[0].Rows[0][3].ToString();
            txtNewRole.Text = details.Tables[0].Rows[0][5].ToString();

            int roleId = (int)ds.Tables[0].Rows[0][12];
            if (roleId == (int)HRMSEnums.Role.Executive)
            {
                txtDesignation.Text= "Executive";
            }
            else if (roleId == (int)HRMSEnums.Role.HR)
            {
                txtDesignation.Text = "HR";
            }
            else if (roleId == (int)HRMSEnums.Role.Manager)
            {
                txtDesignation.Text = "Manager";
            }
            else
            {
                txtDesignation.Text = "Admin";
            }
            txtGender.Text = ds.Tables[0].Rows[0][5].ToString();
            txtAddressCA.Text = ds.Tables[0].Rows[0][13].ToString();
            ddlCityCA.SelectedItem.Text = ds.Tables[0].Rows[0][14].ToString();
            ddlStateCA.SelectedItem.Text = ds.Tables[0].Rows[0][15].ToString();
            txtDepartment.Text = ds.Tables[0].Rows[0][18].ToString();
            txtRM.Text = details.Tables[0].Rows[0][4].ToString();
        }

        public void GetVisibilty()
        {
            PanelPreviousCompany.Visible = false;
            txtEmpFname.Enabled = false;
            txtEmpLname.Enabled = false;
            txtDOJ.Enabled = false;
            txtDOB.Enabled = false;
            txtPhone.Enabled = false;
            txtAddressPA.Enabled = false;
            txtAddressCA.Enabled = false;
            btnEdit.Visible = true;
            btnSubmit.Visible = false;
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            btnUpdate.Visible = true;
            PanelPreviousCompany.Visible = false;
            txtEmpFname.Enabled = false;
            txtEmpLname.Enabled = true;
            txtDOJ.Enabled = false;
            txtDOB.Enabled = false;
            txtPhone.Enabled = true;
            txtAddressPA.Enabled = false;
            txtAddressCA.Enabled = false;
            btnEdit.Visible = false;
            btnSubmit.Visible = false;
        }
    }
}