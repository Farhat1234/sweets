using HRMBAL;
using System;
using System.Web.UI;

namespace HumanResourceApplication
{
    public partial class Login : System.Web.UI.Page
    {
        //LoginService.LoginClient Proxy;
         HRMBAL.BALService Proxy;

        protected void Page_Load(object sender, EventArgs e)
        {
            Proxy = new HRMBAL.BALService();
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                Session["EmpId"] = txtEmpID.Text;
                Session["Password"] = txtPass.Text;
                
                bool valid = Proxy.LoginRep(Convert.ToInt32(txtEmpID.Text));

                if (valid)
                {
                    var exists = Proxy.CheckEmpId(Convert.ToInt32(txtEmpID.Text));

                    if (exists)
                    {
                        Response.Redirect("Default.aspx?EmpId=" + txtEmpID.Text);
                    }
                    else
                    {
                        Response.Redirect("~/EmployeeMgt/AddNewEmployee.aspx?EmpId=" + txtEmpID.Text);
                    }
                }
                else
                {
                    Response.Redirect("~/ErrorScreens/HRMUnauthorised.Html");
                }

            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}

