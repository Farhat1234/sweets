using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HumanResourceApplication.EmployeeMgt
{
    public partial class EmployeeIDProof : System.Web.UI.Page
    {
        //HRMRef.Service1Client Proxy;
        //HRMRef.IDProof Idproof;

        HRMBAL.BALService Proxy;
        HRMDAL.Entites.IDProof Idproof;

        protected void Page_Load(object sender, EventArgs e)
        {
            Proxy = new HRMBAL.BALService();
            Idproof = new HRMDAL.Entites.IDProof();

            DataSet value = Proxy.GetIDProofDetails(Convert.ToInt32(Request.QueryString["EmpId"]));

            if (value.Tables[0].Rows.Count > 0 && !IsPostBack)
            {
                txtPAN.Text = value.Tables[0].Rows[0][2].ToString() == string.Empty ? null : value.Tables[0].Rows[0][2].ToString();
                txtPRAN.Text = value.Tables[0].Rows[0][3].ToString() == string.Empty ? null : value.Tables[0].Rows[0][3].ToString();
                txtUAN.Text = value.Tables[0].Rows[0][4].ToString() == string.Empty ? null : value.Tables[0].Rows[0][4].ToString();
                txtESIC.Text = value.Tables[0].Rows[0][6].ToString() == string.Empty ? null : value.Tables[0].Rows[0][6].ToString();
                txtDriving.Text = value.Tables[0].Rows[0][5].ToString() == string.Empty ? null : value.Tables[0].Rows[0][5].ToString();
                txtAadhaar.Text = value.Tables[0].Rows[0][1].ToString() == string.Empty ? null : value.Tables[0].Rows[0][1].ToString();
                txtVoters.Text = value.Tables[0].Rows[0][7].ToString() == string.Empty ? null : value.Tables[0].Rows[0][7].ToString();
                txtPAN.Enabled = false;
                txtVoters.Enabled = false;
                txtUAN.Enabled = false;
                txtPRAN.Enabled = false;
                txtESIC.Enabled = false;
                txtDriving.Enabled = false;
                txtAadhaar.Enabled = false;
                btnSubmit.Visible = false;
                btnEdit.Visible = true;
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                Idproof.PAN = txtPAN.Text;
                Idproof.PRAN = txtPRAN.Text;
                Idproof.Aadhar = txtAadhaar.Text;
                Idproof.UAN = txtUAN.Text;
                Idproof.DrivingLicense = txtDriving.Text;
                Idproof.ESIC = txtESIC.Text;
                Idproof.VoterID = txtVoters.Text;
                Idproof.EmpID = Convert.ToInt32(Request.QueryString["EmpId"]);
                Proxy.AddIDProof(Idproof);
                txtPAN.Enabled = false;
                txtVoters.Enabled = false;
                txtUAN.Enabled = false;
                txtPRAN.Enabled = false;
                txtESIC.Enabled = false;
                txtDriving.Enabled = false;
                txtAadhaar.Enabled = false;
                btnSubmit.Visible = false;
                btnEdit.Visible = true;
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record Inserted Successfully')", true);
            }
            catch
            {
                throw;
            }
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            txtPAN.Enabled = true;
            txtVoters.Enabled = true;
            txtUAN.Enabled = true;
            txtPRAN.Enabled = true;
            txtESIC.Enabled = true;
            txtDriving.Enabled = true;
            txtAadhaar.Enabled = true;
            btnSubmit.Visible = false;
            btnEdit.Visible = false;
            btnUpdate.Visible = true;
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            Proxy.UpdateIDProofDetails(Convert.ToInt32(Request.QueryString["EmpId"]),txtPAN.Text,txtPRAN.Text,txtUAN.Text,txtDriving.Text,txtVoters.Text,txtESIC.Text,txtAadhaar.Text);
            txtPAN.Enabled = false;
            txtVoters.Enabled = false;
            txtUAN.Enabled = false;
            txtPRAN.Enabled = false;
            txtESIC.Enabled = false;
            txtDriving.Enabled = false;
            txtAadhaar.Enabled = false;
            btnSubmit.Visible = false;
            btnEdit.Visible = true;
            btnUpdate.Visible = false;
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Data Updated Successfully')", true);
        }

    }
}