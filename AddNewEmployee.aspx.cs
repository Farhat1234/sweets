using HRMWcfService1.Utilities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HumanResourceApplication.Employee_Mgt
{

    public partial class AddNewEmployee : System.Web.UI.Page
    {
        //HRMRef.Service1Client Proxy;
        //HRMRef.Employee Employ;

        HRMBAL.BALService Proxy;
        HRMDAL.Entites.Employee Employ;

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["HumanResourceConnectionString"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            Proxy = new HRMBAL.BALService();
            Employ = new HRMDAL.Entites.Employee();

            txtEmpID.Text = Request.QueryString["EmpId"].ToString();
            bool result = Proxy.CheckEmpId(Convert.ToInt32(Request.QueryString["EmpId"]));
            DataSet details = Proxy.GetDetailsEmployeeRegistration(Convert.ToInt32(Request.QueryString["EmpId"]));

            txtDOJ.Text = details.Tables[0].Rows[0][0].ToString();
            txtDepartment.Text = details.Tables[0].Rows[0][1].ToString();
            txtEmail.Text = details.Tables[0].Rows[0][3].ToString();
            txtRM.Text = details.Tables[0].Rows[0][4].ToString();
            txtNewRole.Text = details.Tables[0].Rows[0][5].ToString();

            if (Convert.ToInt32(details.Tables[0].Rows[0][2]) == (int)HRMSEnums.Role.Executive)
            {
                txtDesignation.Text = "Executive";
            }
            else if (Convert.ToInt32(details.Tables[0].Rows[0][2]) == (int)HRMSEnums.Role.HR)
            {
                txtDesignation.Text = "HR";
            }
            else if (Convert.ToInt32(details.Tables[0].Rows[0][2]) == (int)HRMSEnums.Role.Manager)
            {
                txtDesignation.Text = "Manager";
            }
            else
            {
                txtDesignation.Text = "Admin";
            }

            if (!IsPostBack)
            {
                //Call countries DropDownList on page load event
                BindCountriesCADropDownList();

                //Call countries DropDownList on page load event
                BindCountriesPADropDownList();

            }

            if (result)
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
            if (FileUpload1.HasFile)
            {
                System.IO.Stream fs = FileUpload1.PostedFile.InputStream;
                System.IO.BinaryReader br = new System.IO.BinaryReader(fs);
                Byte[] bytes = br.ReadBytes((Int32)fs.Length);
                Employ.Photo = bytes;
                string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
                Employ.Photo = bytes;
            }
        }

        protected void FileUpload2_Load2(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)
            {
                System.IO.Stream fs = FileUpload2.PostedFile.InputStream;
                System.IO.BinaryReader br = new System.IO.BinaryReader(fs);
                Byte[] bytes = br.ReadBytes((Int32)fs.Length);
                Employ.Photo = bytes;
                string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
                Employ.Photo = bytes;
            }
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
                Employ.Gender = ddlGender.SelectedItem.Text;
                Employ.PAddress = txtAddressPA.Text;
                Employ.PCity = ddlCityPA.SelectedItem.Text;
                Employ.CCountry = ddlCountryCA.SelectedItem.Text;
                Employ.PCountry = ddlCountryPA.SelectedItem.Text;
                Employ.PState = ddlStatePA.SelectedItem.Text;
                Employ.Phone = Convert.ToDecimal(txtPhone.Text);
                Employ.CAddress = txtAddressCA.Text;
                Employ.CCity = ddlCityCA.SelectedItem.Text;
                Employ.CState = ddlStateCA.SelectedItem.Text;
                Employ.Email = txtEmail.Text;
                if (txtDesignation.Text == "HR")
                {
                    Employ.Designation = 2;
                }
                else if (txtDesignation.Text == "Manager")
                {
                    Employ.Designation = 1;
                }
                else
                {
                    Employ.Designation = 3;
                }

                ;
                Employ.Department = txtDepartment.Text;
                Employ.BloodGroup = ddlBloodGroup.SelectedItem.Text;
                Employ.FromDate = Convert.ToDateTime(txtFromDate.Text);
                Employ.ToDate = Convert.ToDateTime(txtToDate.Text);
                Employ.PreviousCompany = txtPreviousCompany.Text;
                Employ.PreviousContactNumber = Convert.ToDecimal(txtRefNumber.Text);
                Employ.PreviousDesignation = txtPreviousDesignation.Text;
                Employ.PreviousContactPerson = txtContactPersonName.Text;
                Employ.ReportingManager = txtRM.Text;
                Employ.Password = txtPassword.Text;
                Employ.Photo = FileUpload1.FileBytes;
                Employ.Resume = FileUpload2.FileBytes;
                Proxy.AddEmployee(Employ);
                //Utility.SendMail("sydmuzakir@gmail.com", "ajrekarfarhat@gmail.com", null, "hi", "hello world");
                Response.Redirect("~/Default.aspx?EmpId=" + Request.QueryString["EmpId"]);
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record Inserted Successfully')", true);
                //ClientScript.RegisterStartupScript(typeof(Page), "alertMessage", "<script type='text/javascript'>alert('Record Inserted Successfully');window.location.href='Default.aspx?EmpId=" + Request.QueryString["EmpId"] + "'</script>");
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
            txtDOJ.Text = details.Tables[0].Rows[0][0].ToString();
            txtDOB.Text = ds.Tables[0].Rows[0][4].ToString();
            txtAddressPA.Text = ds.Tables[0].Rows[0][6].ToString();
            ddlCityPA.SelectedItem.Text = ds.Tables[0].Rows[0][7].ToString();
            ddlStatePA.SelectedItem.Text = ds.Tables[0].Rows[0][8].ToString();
            txtPhone.Text = ds.Tables[0].Rows[0][9].ToString();
            txtEmail.Text = details.Tables[0].Rows[0][3].ToString();
            int roleId = (int)ds.Tables[0].Rows[0][12];
            ddlGender.SelectedItem.Text = ds.Tables[0].Rows[0][5].ToString();
            txtAddressCA.Text = ds.Tables[0].Rows[0][13].ToString();
            ddlCityCA.SelectedItem.Text = ds.Tables[0].Rows[0][14].ToString();
            ddlStateCA.SelectedItem.Text = ds.Tables[0].Rows[0][15].ToString();
            txtDepartment.Text = details.Tables[0].Rows[0][1].ToString();
            ddlBloodGroup.SelectedItem.Text = ds.Tables[0].Rows[0][19].ToString();
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
            txtEmail.Enabled = false;
            txtAddressPA.Enabled = false;
            txtAddressCA.Enabled = false;
            btnEdit.Visible = true;
            btnSubmit.Visible = false;
            ddlGender.Enabled = false;
            txtDesignation.Enabled = false;
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
            txtEmail.Enabled = true;
            txtAddressPA.Enabled = false;
            txtAddressCA.Enabled = false;
            btnEdit.Visible = false;
            btnSubmit.Visible = false;
            //ddlGender.Enabled = false;
            //ddlRole.Enabled = false;
        }

        protected void BindCountriesCADropDownList()
        {
            try
            {
                SqlDataAdapter adp = new SqlDataAdapter("select * from CountryMaster", con);
                DataSet ds = new DataSet();
                adp.Fill(ds);
                ddlCountryCA.DataSource = ds;
                ddlCountryCA.DataTextField = "CountryName";
                ddlCountryCA.DataValueField = "CountryID";
                ddlCountryCA.DataBind();
                ddlCountryCA.Items.Insert(0, new ListItem("-- Select Country --", "0"));
                ddlStateCA.Items.Insert(0, new ListItem("-- Select State --", "0"));
                ddlCityCA.Items.Insert(0, new ListItem("-- Select City --", "0"));
            }
            catch (Exception ex)
            {
                Response.Write("Error occured : " + ex.Message.ToString());
            }
            finally
            {
                con.Close();
            }
        }

        protected void BindCountriesPADropDownList()
        {
            try
            {
                SqlDataAdapter adp = new SqlDataAdapter("select * from CountryMaster", con);
                DataSet ds = new DataSet();
                adp.Fill(ds);
                ddlCountryPA.DataSource = ds;
                ddlCountryPA.DataTextField = "CountryName";
                ddlCountryPA.DataValueField = "CountryID";
                ddlCountryPA.DataBind();
                ddlCountryPA.Items.Insert(0, new ListItem("-- Select Country --", "0"));
                ddlStatePA.Items.Insert(0, new ListItem("-- Select State --", "0"));
                ddlCityPA.Items.Insert(0, new ListItem("-- Select City --", "0"));
            }
            catch (Exception ex)
            {
                Response.Write("Error occured : " + ex.Message.ToString());
            }
            finally
            {
                con.Close();
            }
        }

        protected void ddlStatePA_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int StateId = Convert.ToInt32(ddlStatePA.SelectedValue);
                //Select all Cities corresponding to the selected State
                SqlDataAdapter adp = new SqlDataAdapter("select * from CityMaster where StateID=" + StateId, con);
                DataSet ds = new DataSet();
                adp.Fill(ds);
                ddlCityPA.DataSource = ds;
                ddlCityPA.DataTextField = "CityName";
                ddlCityPA.DataValueField = "CityID";
                ddlCityPA.DataBind();
                ddlCityPA.Items.Insert(0, new ListItem("-- Select City --", "0"));
            }
            catch (Exception ex)
            {
                Response.Write("Error occured : " + ex.Message.ToString());
            }
            finally
            {
                con.Close();
            }
        }

        protected void ddlCountryPA_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int CountryId = Convert.ToInt32(ddlCountryPA.SelectedValue);
                //Select all States corresponding to the selected Country
                SqlDataAdapter adp = new SqlDataAdapter("Select * from StateMaster where CountryID=" + CountryId, con);
                DataSet ds = new DataSet();
                adp.Fill(ds);
                ddlStatePA.DataSource = ds;
                ddlStatePA.DataTextField = "StateName";
                ddlStatePA.DataValueField = "StateID";
                ddlStatePA.DataBind();
                ddlStatePA.Items.Insert(0, new ListItem("-- Select State --", "0"));
                //If State is not selected then clear City DropDownList also
                if (ddlStatePA.SelectedValue == "0")
                {
                    ddlCityPA.Items.Clear();
                    ddlCityPA.Items.Insert(0, new ListItem("-- Select City --", "0"));
                }
            }
            catch (Exception ex)
            {
                //Printing any exception if occcured.
                Response.Write("Error occured: " + ex.Message.ToString());
            }
            finally
            {
                //Close the connection
                con.Close();
            }
        }

        protected void ddlStateCA_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int StateId = Convert.ToInt32(ddlStateCA.SelectedValue);
                //Select all Cities corresponding to the selected State
                SqlDataAdapter adp = new SqlDataAdapter("select * from CityMaster where StateID=" + StateId, con);
                DataSet ds = new DataSet();
                adp.Fill(ds);
                ddlCityCA.DataSource = ds;
                ddlCityCA.DataTextField = "CityName";
                ddlCityCA.DataValueField = "CityID";
                ddlCityCA.DataBind();
                ddlCityCA.Items.Insert(0, new ListItem("-- Select City --", "0"));
            }
            catch (Exception ex)
            {
                Response.Write("Error occured : " + ex.Message.ToString());
            }
            finally
            {
                con.Close();
            }
        }

        protected void ddlCountryCA_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int CountryId = Convert.ToInt32(ddlCountryCA.SelectedValue);
                //Select all States corresponding to the selected Country
                SqlDataAdapter adp = new SqlDataAdapter("Select * from StateMaster where CountryID=" + CountryId, con);
                DataSet ds = new DataSet();
                adp.Fill(ds);
                ddlStateCA.DataSource = ds;
                ddlStateCA.DataTextField = "StateName";
                ddlStateCA.DataValueField = "StateID";
                ddlStateCA.DataBind();
                ddlStateCA.Items.Insert(0, new ListItem("-- Select State --", "0"));
                //If State is not selected then clear City DropDownList also
                if (ddlStateCA.SelectedValue == "0")
                {
                    ddlCityCA.Items.Clear();
                    ddlCityCA.Items.Insert(0, new ListItem("-- Select City --", "0"));
                }
            }
            catch (Exception ex)
            {
                //Printing any exception if occcured.
                Response.Write("Error occured: " + ex.Message.ToString());
            }
            finally
            {
                //Close the connection
                con.Close();
            }
        }
    }
}