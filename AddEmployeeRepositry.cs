using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using HRMDAL.Entites;
using System.Configuration;

namespace HRMDAL.Repositries
{
    public class AddEmployeeRepositry : BaseRepositry
    {
        public void AddEmployee(Entites.Employee emp)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(HRMConString))
                {
                    con.Open();

                    using (SqlDataAdapter da = new SqlDataAdapter())
                    {
                        string query = "select EmployeeId from EmployeeMaster where EmployeeId='" + emp.EmpID + "'";

                        using (SqlCommand cmd = new SqlCommand(query, con))
                        {
                            var result = cmd.ExecuteScalar();

                            if (result == null)
                            {
                                da.UpdateCommand = new SqlCommand();
                                da.SelectCommand = new SqlCommand();
                                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                                da.SelectCommand.CommandText = "SPAddEmployee";
                                da.SelectCommand.Connection = con;
                                da.SelectCommand.Parameters.AddWithValue("@empid", emp.EmpID);
                                da.SelectCommand.Parameters.AddWithValue("@efname", emp.FirstName);
                                da.SelectCommand.Parameters.AddWithValue("@elname", emp.LastName);
                                da.SelectCommand.Parameters.AddWithValue("@doj", emp.DOJ);
                                da.SelectCommand.Parameters.AddWithValue("@dob", emp.DOB);
                                da.SelectCommand.Parameters.AddWithValue("@gen", emp.Gender);
                                da.SelectCommand.Parameters.AddWithValue("@paddr", emp.PAddress);
                                da.SelectCommand.Parameters.AddWithValue("@pcity", emp.PCity);
                                da.SelectCommand.Parameters.AddWithValue("@pstate", emp.PState);
                                da.SelectCommand.Parameters.AddWithValue("@phne", emp.Phone);
                                da.SelectCommand.Parameters.AddWithValue("@email", emp.Email);
                                da.SelectCommand.Parameters.AddWithValue("@role", emp.Designation);
                                da.SelectCommand.Parameters.AddWithValue("@caddr", emp.CAddress);
                                da.SelectCommand.Parameters.AddWithValue("@ccity", emp.CCity);
                                da.SelectCommand.Parameters.AddWithValue("@cstate", emp.CState);
                                da.SelectCommand.Parameters.AddWithValue("@department", emp.Department);
                                da.SelectCommand.Parameters.AddWithValue("@bloodgrp", emp.BloodGroup);
                                da.SelectCommand.Parameters.AddWithValue("@reportingmanager", emp.ReportingManager);
                                da.SelectCommand.Parameters.AddWithValue("@previouscompany", emp.PreviousCompany);
                                da.SelectCommand.Parameters.AddWithValue("@contactperson", emp.PreviousContactPerson);
                                da.SelectCommand.Parameters.AddWithValue("@previousdesignation", emp.PreviousDesignation);
                                da.SelectCommand.Parameters.AddWithValue("@fromdate", emp.FromDate);
                                da.SelectCommand.Parameters.AddWithValue("@todate", emp.ToDate);
                                da.SelectCommand.Parameters.AddWithValue("@previouscontnum", emp.PreviousContactNumber);
                                da.SelectCommand.Parameters.AddWithValue("@pass", emp.Password);
                                da.SelectCommand.ExecuteNonQuery();
                            }
                            else
                            {
                                da.UpdateCommand = new SqlCommand();
                                da.UpdateCommand.CommandType = CommandType.StoredProcedure;
                                da.UpdateCommand.CommandText = "SPUpdateEmployeeDetails";
                                da.UpdateCommand.Connection = con;
                                da.UpdateCommand.Parameters.AddWithValue("@empid", emp.EmpID);
                                da.UpdateCommand.Parameters.AddWithValue("@elname", emp.LastName);
                                da.UpdateCommand.Parameters.AddWithValue("@paddr", emp.PAddress);
                                da.UpdateCommand.Parameters.AddWithValue("@pcity", emp.PCity);
                                da.UpdateCommand.Parameters.AddWithValue("@pstate", emp.PState);
                                da.UpdateCommand.Parameters.AddWithValue("@phne", emp.Phone);
                                da.UpdateCommand.Parameters.AddWithValue("@caddr", emp.CAddress);
                                da.UpdateCommand.Parameters.AddWithValue("@ccity", emp.CCity);
                                da.UpdateCommand.Parameters.AddWithValue("@cstate", emp.CState);
                                da.UpdateCommand.ExecuteNonQuery();
                            }
                        }

                    }
                }
            }
            catch
            {
                throw;
            }
        }

        public List<Entites.Employee> RetriveEmpIDImage(int EmpID)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(HRMConString))
                {
                    con.Open();

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "RetriveImage";
                        cmd.Connection = con;

                        SqlParameter prm = new SqlParameter();

                        prm = cmd.Parameters.Add("@Empid", SqlDbType.Int);
                        prm.Direction = ParameterDirection.Input;
                        prm.Value = EmpID;

                        //forward onnly,read only online cursors
                        SqlDataReader dr = cmd.ExecuteReader();
                        List<Entites.Employee> empidimage = new List<Entites.Employee>();

                        while (dr.Read())
                        {
                            Entites.Employee Emp = new Entites.Employee();
                            Emp.EmpID = dr.GetInt32(0);
                            Emp.Photo = ((byte[])dr["Photo"]);
                            empidimage.Add(Emp);

                        }
                        dr.Close();
                        con.Close();
                        con.Dispose();

                        return empidimage;
                    }

                }

            }

            catch
            {
                throw;
            }
        }

        public List<Entites.StateCity> GetStates()
        {
            try
            {
                using (SqlConnection con = new SqlConnection())
                {
                    con.ConnectionString = HRMConString;
                    con.Open();
                    string str = "RetriveState";

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = str;
                        cmd.Connection = con;

                        SqlDataReader dr = cmd.ExecuteReader();//since we r reading rows thro select stmt
                        List<Entites.StateCity> state = new List<Entites.StateCity>();
                        while (dr.Read())
                        {
                            Entites.StateCity st = new Entites.StateCity();//fetch rows
                            st.StateID = dr.GetInt32(0);
                            st.StateName = dr.GetString(1);
                            state.Add(st);
                        }

                        dr.Close();
                        con.Close();
                        con.Dispose();

                        return state;
                    }

                }

            }
            catch
            {
                throw;
            }
        }

        public List<Entites.City> GetCity(int StateID)
        {
            try
            {
                using (SqlConnection con = new SqlConnection())
                {
                    con.ConnectionString = HRMConString;
                    con.Open();
                    string str = "RetriveCity";

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = str;
                        cmd.Connection = con;

                        SqlParameter prm = cmd.Parameters.Add("@stateid", SqlDbType.Int);
                        prm.Direction = ParameterDirection.Input;
                        prm.Value = StateID;

                        SqlDataReader dr = cmd.ExecuteReader();

                        List<Entites.City> city = new List<Entites.City>();
                        while (dr.Read())
                        {
                            Entites.City ct = new Entites.City();
                            ct.CityName = dr.GetString(0);
                            ct.StateID = dr.GetInt32(1);
                            city.Add(ct);
                        }

                        dr.Close();
                        con.Close();
                        con.Dispose();

                        return city;
                    }

                }
            }
            catch
            {
                throw;
            }
        }

        public void AddBankDetails(BankDetails bankDetails)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(HRMConString))
                {
                    con.Open();

                    using (SqlDataAdapter da = new SqlDataAdapter())
                    {
                        string query = "select * from EmployeeBankDetails where EmpID='" + bankDetails.EmpId + "'";

                        using (SqlCommand cmd = new SqlCommand(query, con))
                        {
                            var result = cmd.ExecuteScalar();

                            if (result == null)
                            {
                                da.SelectCommand = new SqlCommand();
                                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                                da.SelectCommand.CommandText = "SPBankDetails";
                                da.SelectCommand.Connection = con;
                                da.SelectCommand.Parameters.AddWithValue("@empid", bankDetails.EmpId);
                                da.SelectCommand.Parameters.AddWithValue("@accountType", bankDetails.AccountType);
                                da.SelectCommand.Parameters.AddWithValue("@bankname", bankDetails.BankName);
                                da.SelectCommand.Parameters.AddWithValue("@accno", bankDetails.AccountNo);
                                da.SelectCommand.Parameters.AddWithValue("@country", bankDetails.Country);
                                da.SelectCommand.Parameters.AddWithValue("@ifsc", bankDetails.IFSC);
                                da.SelectCommand.Parameters.AddWithValue("@raccountType", bankDetails.RAccountType);
                                da.SelectCommand.Parameters.AddWithValue("@rbankname", bankDetails.RBankName);
                                da.SelectCommand.Parameters.AddWithValue("@raccno", bankDetails.RAccountNo);
                                da.SelectCommand.Parameters.AddWithValue("@rcountry", bankDetails.RCountry);
                                da.SelectCommand.Parameters.AddWithValue("@rifsc", bankDetails.RIFSC);
                                da.SelectCommand.Parameters.AddWithValue("@accountHolder", bankDetails.AccountHolderName);
                                da.SelectCommand.Parameters.AddWithValue("@raccountHolder", bankDetails.ReimburseAccHolder);
                                da.SelectCommand.Parameters.AddWithValue("@branch", bankDetails.Branch);
                                da.SelectCommand.Parameters.AddWithValue("@rbranch", bankDetails.ReimburseBranch);
                                da.SelectCommand.ExecuteNonQuery();

                            }
                            else
                            {
                                da.UpdateCommand = new SqlCommand();
                                da.UpdateCommand.CommandType = CommandType.StoredProcedure;
                                da.UpdateCommand.CommandText = "SPUpdateBankDetails";
                                da.UpdateCommand.Connection = con;
                                da.UpdateCommand.Parameters.AddWithValue("@empid", bankDetails.EmpId);
                                da.UpdateCommand.Parameters.AddWithValue("@bankname", bankDetails.BankName);
                                da.UpdateCommand.Parameters.AddWithValue("@accno", bankDetails.AccountNo);
                                da.UpdateCommand.Parameters.AddWithValue("@country", bankDetails.Country);
                                da.UpdateCommand.Parameters.AddWithValue("@ifsc", bankDetails.IFSC);
                                da.UpdateCommand.Parameters.AddWithValue("@rbankname", bankDetails.RBankName);
                                da.UpdateCommand.Parameters.AddWithValue("@raccno", bankDetails.RAccountNo);
                                da.UpdateCommand.Parameters.AddWithValue("@rcountry", bankDetails.RCountry);
                                da.UpdateCommand.Parameters.AddWithValue("@rifsc", bankDetails.RIFSC);
                                da.UpdateCommand.Parameters.AddWithValue("@accountHolder", bankDetails.AccountHolderName);
                                da.UpdateCommand.Parameters.AddWithValue("@raccountHolder", bankDetails.ReimburseAccHolder);
                                da.UpdateCommand.Parameters.AddWithValue("@branch", bankDetails.Branch);
                                da.UpdateCommand.Parameters.AddWithValue("@rbranch", bankDetails.ReimburseBranch);
                                da.UpdateCommand.ExecuteNonQuery();
                            }
                        }

                    }
                }
            }
            catch
            {
                throw;
            }
        }

        //public DataTable CountryList()
        //{
        //    try
        //    {
        //        SqlConnection con = new SqlConnection(HRMConString);
        //        SqlCommand cmd = new SqlCommand("select CountryID, CountryName from CountryMaster", con);
        //        con.Open();
        //        cmd.CommandType = CommandType.Text;
        //        SqlDataReader dr = cmd.ExecuteReader();
        //        DataTable dt = null;
        //        if (dr.HasRows)
        //        {
        //            dt = new DataTable("CountryMaster");
        //            dt.Load(dr);
        //            return dt;
        //        }
        //        if (cmd != null)
        //        {
        //            cmd.Dispose();
        //            cmd = null;
        //        }
        //        return dt;
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //}

        public DataTable StateList(int CountryID)
        {
            try
            {
                SqlConnection con = new SqlConnection(HRMConString);
                SqlCommand cmd = new SqlCommand("select StateID, StateName from State Where CountryID=@CountryID", con);
                con.Open();
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@CountryID", SqlDbType.Int).Value = CountryID;
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = null;
                if (dr.HasRows)
                {
                    dt = new DataTable("State");
                    dt.Load(dr);
                    //   status = true;  
                    return dt;
                }
                if (cmd != null)
                {
                    cmd.Dispose();
                    cmd = null;
                }
                return dt;
            }
            catch
            {
                throw;
            }
        }

        public DataTable CityList(int StateID)
        {
            try
            {
                SqlConnection con = new SqlConnection(HRMConString);
                SqlCommand cmd = new SqlCommand("select CityID, CityName from City Where StateID=@StateID", con);
                con.Open();
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@StateID", SqlDbType.Int).Value = StateID;
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = null;
                if (dr.HasRows)
                {
                    dt = new DataTable("City");
                    dt.Load(dr);
                    //   status = true;  
                    return dt;
                }
                if (cmd != null)
                {
                    cmd.Dispose();
                    cmd = null;
                }
                return dt;
            }
            catch
            {
                throw;
            }
        }

        public bool GetBankDetailsById(int empid)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(HRMConString))
                {
                    con.Open();

                    string query = "select * from EmployeeBankDetails where EmpID='" + empid + "'";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        var result = cmd.ExecuteScalar();

                        if (result == null)
                        {
                            return false;
                        }
                        return true;
                    }
                }
            }
            catch
            {
                throw;
            }
        }

        public DataSet GetBankById(int empid)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(HRMConString))
                {
                    con.Open();

                    string query = "select SavingsAccountType,SavingsBankName,SavingsAccountNo,SavingsCountry,SavingsIFSC,AccountHolderName,Branch from EmployeeBankDetails where EmpID='" + empid + "'";

                    using (SqlDataAdapter da = new SqlDataAdapter(query, con))
                    {
                        da.SelectCommand.Connection = con;

                        DataSet ds = new DataSet();
                        da.Fill(ds);
                        return ds;
                    }
                }
            }
            catch
            {
                throw;
            }
        }

        public DataSet GetReimburseBankById(int empid)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(HRMConString))
                {
                    con.Open();

                    string query = "select ReimburseAccountType,ReimburseBankName,ReimburseAccountNo,ReimburseCountry,ReimburseIFSC,ReimburseAccHolder,ReimburseBranch from EmployeeBankDetails where EmpID='" + empid + "'";

                    using (SqlDataAdapter da = new SqlDataAdapter(query, con))
                    {
                        da.SelectCommand.Connection = con;

                        DataSet ds = new DataSet();
                        da.Fill(ds);
                        return ds;
                    }
                }
            }
            catch
            {
                throw;
            }
        }

        public List<BankDetails> UpdateBankById(int empid)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(HRMConString))
                {
                    con.Open();

                    SqlDataReader dr = null;

                    string query = "select * from EmployeeBankDetails where EmpID='" + empid + "'";

                    List<BankDetails> bank = new List<BankDetails>();

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        dr = cmd.ExecuteReader();

                        while (dr.Read())
                        {
                            BankDetails bankDetails = new BankDetails();
                            bankDetails.AccountNo = dr.GetInt64(4);
                            bankDetails.AccountType = dr.GetString(2);
                            bankDetails.BankName = dr.GetString(3);
                            bankDetails.Country = dr.GetString(5);
                            bankDetails.IFSC = dr.GetString(6);
                            bankDetails.RAccountNo = dr.GetInt64(9);
                            bankDetails.RAccountType = dr.GetString(7);
                            bankDetails.RBankName = dr.GetString(8);
                            bankDetails.RCountry = dr.GetString(10);
                            bankDetails.RIFSC = dr.GetString(11);
                            bank.Add(bankDetails);
                        }

                        dr.Close();
                        return bank;
                    }
                }
            }
            catch
            {
                throw;
            }
        }

        public bool CheckEmpId(int empid)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(HRMConString))
                {
                    con.Open();

                    string query = "select EmployeeId from EmployeeMaster where EmployeeId='" + empid + "'";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        var result = cmd.ExecuteScalar();

                        if (result == null)
                        {
                            return false;
                        }
                        return true;
                    }
                }
            }
            catch
            {
                throw;
            }
        }

        public DataSet GetEmployeeDetails(int empid)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(HRMConString))
                {
                    con.Open();

                    string query = "select * from EmployeeMaster where EmployeeId='" + empid + "'";

                    using (SqlDataAdapter da = new SqlDataAdapter(query, con))
                    {
                        da.SelectCommand.Connection = con;
                        DataSet ds = new DataSet();
                        da.Fill(ds);
                        return ds;
                    }
                }
            }
            catch
            {
                throw;
            }
        }

        public void AddEducation(Education education)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(HRMConString))
                {
                    con.Open();

                    using (SqlDataAdapter da = new SqlDataAdapter())
                    {
                        da.SelectCommand = new SqlCommand();
                        da.SelectCommand.CommandType = CommandType.StoredProcedure;
                        da.SelectCommand.CommandText = "SPAddEducationDetails";
                        da.SelectCommand.Connection = con;
                        da.SelectCommand.Parameters.AddWithValue("@empid", education.EmpId);
                        da.SelectCommand.Parameters.AddWithValue("@startdate", education.StartDate);
                        da.SelectCommand.Parameters.AddWithValue("@todate", education.EndDate);
                        da.SelectCommand.Parameters.AddWithValue("@certificate", education.Certificate);
                        da.SelectCommand.Parameters.AddWithValue("@branchstudyone", education.BranchStudyOne);
                        da.SelectCommand.Parameters.AddWithValue("@duration", education.Duration);
                        da.SelectCommand.Parameters.AddWithValue("@educationest", education.EducationalEstimation);
                        da.SelectCommand.Parameters.AddWithValue("@city", education.City);
                        da.SelectCommand.Parameters.AddWithValue("@nameofinstitute", education.NameOfInstitute);
                        da.SelectCommand.Parameters.AddWithValue("@qualification", education.Qualification);
                        da.SelectCommand.Parameters.AddWithValue("@additionalcourse", education.AdditionalCourse);
                        da.SelectCommand.Parameters.AddWithValue("@type", education.Type);
                        da.SelectCommand.Parameters.AddWithValue("@grade", education.Grade);
                        da.SelectCommand.ExecuteNonQuery();
                    }
                }
            }
            catch
            {
                throw;
            }
        }

        public void AddPassport(Passport passport)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(HRMConString))
                {
                    con.Open();

                    using (SqlDataAdapter da = new SqlDataAdapter())
                    {
                        da.SelectCommand = new SqlCommand();
                        da.SelectCommand.CommandType = CommandType.StoredProcedure;
                        da.SelectCommand.CommandText = "SPAddPassportDetails";
                        da.SelectCommand.Connection = con;
                        da.SelectCommand.Parameters.AddWithValue("@empid", passport.EmpID);
                        da.SelectCommand.Parameters.AddWithValue("@passportfor", passport.PassportFor);
                        da.SelectCommand.Parameters.AddWithValue("@Name", passport.Name);
                        da.SelectCommand.Parameters.AddWithValue("@GivenName", passport.GivenName);
                        da.SelectCommand.Parameters.AddWithValue("@surName", passport.Surname);
                        da.SelectCommand.Parameters.AddWithValue("@gender", passport.Gender);
                        da.SelectCommand.Parameters.AddWithValue("@dob", passport.DateofBirth);
                        da.SelectCommand.Parameters.AddWithValue("@pob", passport.PlaceofBirth);
                        da.SelectCommand.Parameters.AddWithValue("@nationality", passport.Nationality);
                        da.SelectCommand.Parameters.AddWithValue("@issuingcountry", passport.PassportIssuingCountry);
                        da.SelectCommand.Parameters.AddWithValue("@passportnum", passport.PassportNo);
                        da.SelectCommand.Parameters.AddWithValue("@issuedate", passport.IssueDate);
                        da.SelectCommand.Parameters.AddWithValue("@expirydate", passport.ExpiryDate);
                        da.SelectCommand.Parameters.AddWithValue("@placeofissue", passport.PlaceofIssue);
                        da.SelectCommand.Parameters.AddWithValue("@renewalapplied", passport.RenewalApplied);
                        da.SelectCommand.ExecuteNonQuery();
                    }
                }

            }
            catch
            {

                throw;
            }
        }

        public void AddIDProof(IDProof idproof)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(HRMConString))
                {
                    con.Open();

                    using (SqlDataAdapter da = new SqlDataAdapter())
                    {
                        da.SelectCommand = new SqlCommand();
                        da.SelectCommand.CommandType = CommandType.StoredProcedure;
                        da.SelectCommand.CommandText = "SPIdProof";
                        da.SelectCommand.Connection = con;
                        da.SelectCommand.Parameters.AddWithValue("@aadhar", idproof.Aadhar);
                        da.SelectCommand.Parameters.AddWithValue("@pan", idproof.PAN);
                        da.SelectCommand.Parameters.AddWithValue("@pran", idproof.PRAN);
                        da.SelectCommand.Parameters.AddWithValue("@uan", idproof.UAN);
                        da.SelectCommand.Parameters.AddWithValue("@pf", idproof.PFnumber);
                        da.SelectCommand.Parameters.AddWithValue("@drivinglicense", idproof.DrivingLicense);
                        da.SelectCommand.Parameters.AddWithValue("@empid", idproof.EmpID);
                        da.SelectCommand.Parameters.AddWithValue("@esic", idproof.ESIC);
                        da.SelectCommand.Parameters.AddWithValue("@voterid", idproof.VoterID);
                        da.SelectCommand.ExecuteNonQuery();
                    }
                }

            }
            catch
            {

                throw;
            }
        }

        public void LoanDetails(Entites.LoanDetails loanDetails)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(HRMConString))
                {
                    con.Open();

                    using (SqlDataAdapter da = new SqlDataAdapter())
                    {
                        string query = "select * from EmployeeLoanDetails where EmpID='" + loanDetails.EmpID + "'";

                        using (SqlCommand cmd = new SqlCommand(query, con))
                        {
                            var result = cmd.ExecuteScalar();

                            if (result == null)
                            {
                                da.SelectCommand = new SqlCommand();
                                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                                da.SelectCommand.CommandText = "SPAddEmployeeLoanDetails";
                                da.SelectCommand.Connection = con;
                                da.SelectCommand.Parameters.AddWithValue("@loantypeid", loanDetails.LoanTypeId);
                                da.SelectCommand.Parameters.AddWithValue("@empid", loanDetails.EmpID);
                                da.SelectCommand.Parameters.AddWithValue("@amount", loanDetails.Amount);
                                da.SelectCommand.Parameters.AddWithValue("@primaryapprover", loanDetails.PrimaryApprover);
                                da.SelectCommand.Parameters.AddWithValue("@note", loanDetails.Note);
                                da.SelectCommand.Parameters.AddWithValue("@payeename", loanDetails.PayeeName);
                                da.SelectCommand.ExecuteNonQuery();
                            }
                            else
                            {
                                da.UpdateCommand = new SqlCommand();
                                da.UpdateCommand.CommandType = CommandType.StoredProcedure;
                                da.UpdateCommand.CommandText = "SPUpdateEmployeeLoanDetails";
                                da.UpdateCommand.Connection = con;
                                da.UpdateCommand.Parameters.AddWithValue("@loantypeid", loanDetails.LoanTypeId);
                                da.UpdateCommand.Parameters.AddWithValue("@empid", loanDetails.EmpID);
                                da.UpdateCommand.Parameters.AddWithValue("@amount", loanDetails.Amount);
                                da.UpdateCommand.Parameters.AddWithValue("@primaryapprover", loanDetails.PrimaryApprover);
                                da.UpdateCommand.Parameters.AddWithValue("@note", loanDetails.Note);
                                da.UpdateCommand.Parameters.AddWithValue("@payeename", loanDetails.PayeeName);
                                da.UpdateCommand.ExecuteNonQuery();
                            }
                        }

                    }
                }
            }
            catch
            {
                throw;
            }
        }

        public DataSet GetLoanDetails(int empid)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(HRMConString))
                {
                    con.Open();

                    string query = "select * from EmployeeLoanDetails where EmpID='" + empid + "'";

                    using (SqlDataAdapter da = new SqlDataAdapter(query, con))
                    {
                        da.SelectCommand.Connection = con;

                        DataSet ds = new DataSet();
                        da.Fill(ds);
                        return ds;
                    }
                }

            }
            catch
            {
                throw;
            }
        }

        public void FamilyNomination(Entites.FamilyNomination familyNomination)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(HRMConString))
                {
                    con.Open();
                    using (SqlDataAdapter da = new SqlDataAdapter())
                    {
                        da.SelectCommand = new SqlCommand();
                        da.SelectCommand.CommandType = CommandType.StoredProcedure;
                        da.SelectCommand.CommandText = "SPAddEmployeeFamily";
                        da.SelectCommand.Connection = con;
                        da.SelectCommand.Parameters.AddWithValue("@empid", familyNomination.EmpID);
                        da.SelectCommand.Parameters.AddWithValue("@relative", familyNomination.Relation);
                        da.SelectCommand.Parameters.AddWithValue("@gender", familyNomination.Gender);
                        da.SelectCommand.Parameters.AddWithValue("@fname", familyNomination.FirstName);
                        da.SelectCommand.Parameters.AddWithValue("@lname", familyNomination.LastName);
                        da.SelectCommand.Parameters.AddWithValue("@initials", familyNomination.Initials);
                        da.SelectCommand.Parameters.AddWithValue("@nameatbirth", familyNomination.NameatBirth);
                        da.SelectCommand.Parameters.AddWithValue("@phone", familyNomination.Phone);
                        da.SelectCommand.Parameters.AddWithValue("@address", familyNomination.Address);
                        da.SelectCommand.Parameters.AddWithValue("@dob", familyNomination.DateofBirth);
                        da.SelectCommand.Parameters.AddWithValue("@pob", familyNomination.PlaceofBirth);
                        da.SelectCommand.Parameters.AddWithValue("@birthcountry", familyNomination.BirthCountry);
                        da.SelectCommand.Parameters.AddWithValue("@nationality", familyNomination.Nationality);
                        da.SelectCommand.ExecuteNonQuery();
                    }
                }
            }
            catch
            {
                throw;
            }
        }

        public DataSet GetFamilyNomination(int empid)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(HRMConString))
                {
                    con.Open();
                    string query = "select * from EmployeeFamilyMaster where EmpID='" + empid + "'";
                    using (SqlDataAdapter da = new SqlDataAdapter(query, con))
                    {
                        da.SelectCommand.Connection = con;
                        DataSet ds = new DataSet();
                        da.Fill(ds);
                        return ds;
                    }
                }
            }
            catch
            {
                throw;
            }
        }

        public DataSet BindAttendance()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(HRMConString))
                {
                    con.Open();

                    string query = "select * from DailyAttendance";

                    using (SqlDataAdapter da = new SqlDataAdapter(query, con))
                    {
                        da.SelectCommand.Connection = con;
                        DataSet ds = new DataSet();
                        da.Fill(ds);
                        return ds;
                    }
                }
            }
            catch
            {
                throw;
            }
        }

        public DataSet GetPaySlipDetails(int empid)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(HRMConString))
                {
                    con.Open();

                    string query = "select EmpID, EmpName, Month, Year from ManagePayslip where EmpID = '" + empid + "'";
                    using (SqlDataAdapter da = new SqlDataAdapter(query, con))
                    {
                        DataSet ds = new DataSet();
                        da.Fill(ds);
                        return ds;
                    }
                }
            }
            catch
            {
                throw;
            }
        }

        public List<Identity> GetEmpid()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(HRMConString))
                {
                    con.Open();

                    string query = "select distinct EmployeeId, ep.EmpID, ep.EmpName from EmployeeMaster inner join EmployeePayroll ep on EmployeeId=ep.EmpID where IsActive='" + 0 + "'";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        SqlDataReader dr = cmd.ExecuteReader();

                        List<Identity> listIdentities = new List<Identity>();
                        while (dr.Read())
                        {
                            Identity idn = new Identity();
                            idn.EmpID = dr.GetInt32(1);
                            idn.EmpName = dr.GetString(2);
                            listIdentities.Add(idn);
                        }
                        dr.Close();
                        con.Close();
                        return listIdentities;
                    }
                }
            }
            catch
            {
                throw;
            }
        }

        public DataSet GetEmployeePayslip(int empid)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(HRMConString))
                {
                    con.Open();

                    string query = "select * from EmployeePayroll where EmpID = '" + empid + "'";
                    using (SqlDataAdapter da = new SqlDataAdapter(query, con))
                    {
                        DataSet ds = new DataSet();
                        da.Fill(ds);
                        return ds;
                    }
                }
            }
            catch
            {
                throw;
            }
        }

        public DataSet GetEmployeePayslip()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(HRMConString))
                {
                    con.Open();

                    string query = "select distinct * from EmployeePayroll";
                    using (SqlDataAdapter da = new SqlDataAdapter(query, con))
                    {
                        DataSet ds = new DataSet();
                        da.Fill(ds);
                        return ds;
                    }
                }
            }
            catch
            {
                throw;
            }
        }

        public void AddPaySlipDetails(int empid, string empname, string month, string year, string currsalary, string compname)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(HRMConString))
                {
                    con.Open();
                    using (SqlDataAdapter da = new SqlDataAdapter())
                    {
                        da.SelectCommand = new SqlCommand();
                        da.SelectCommand.CommandType = CommandType.StoredProcedure;
                        da.SelectCommand.CommandText = "SPAddPayslipDetails";
                        da.SelectCommand.Connection = con;

                        da.SelectCommand.Parameters.AddWithValue("@empid", empid);
                        da.SelectCommand.Parameters.AddWithValue("@empname", empname);
                        da.SelectCommand.Parameters.AddWithValue("@month", month);
                        da.SelectCommand.Parameters.AddWithValue("@year", year);
                        da.SelectCommand.Parameters.AddWithValue("@compname", compname);
                        da.SelectCommand.Parameters.AddWithValue("@currsal", currsalary);
                        da.SelectCommand.ExecuteNonQuery();
                    }
                }
            }
            catch
            {
                throw;
            }
        }

        public void AddNewPayrollDetails(PaySlip payslip)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(HRMConString))
                {
                    con.Open();

                    using (SqlDataAdapter da = new SqlDataAdapter())
                    {
                        da.SelectCommand = new SqlCommand();
                        da.SelectCommand.Connection = con;
                        da.SelectCommand.CommandType = CommandType.StoredProcedure;
                        da.SelectCommand.CommandText = "SPAddEmployeePayroll";

                        da.SelectCommand.Parameters.AddWithValue("@empid", payslip.EmpID);
                        da.SelectCommand.Parameters.AddWithValue("@empname", payslip.EmpName);
                        da.SelectCommand.Parameters.AddWithValue("@compname", payslip.CompName);
                        da.SelectCommand.Parameters.AddWithValue("@designation", payslip.Designation);
                        da.SelectCommand.Parameters.AddWithValue("@profestax", payslip.ProfessionTax);
                        da.SelectCommand.Parameters.AddWithValue("@prevsalary", payslip.PreviousSalary);
                        da.SelectCommand.Parameters.AddWithValue("@increment", payslip.Increment);
                        da.SelectCommand.Parameters.AddWithValue("@currsalary", payslip.CurrentSalary);
                        da.SelectCommand.Parameters.AddWithValue("@child", payslip.Child);
                        da.SelectCommand.Parameters.AddWithValue("@interim", payslip.InterimRelief);
                        da.SelectCommand.Parameters.AddWithValue("@comments", payslip.Comments);
                        da.SelectCommand.ExecuteNonQuery();
                    }
                }
            }
            catch
            {
                throw;
            }
        }

        public DataSet GetEmployeeDetailsPayslip(int empid)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(HRMConString))
                {
                    con.Open();

                    using (SqlDataAdapter da = new SqlDataAdapter())
                    {
                        da.SelectCommand = new SqlCommand();
                        da.SelectCommand.Connection = con;
                        da.SelectCommand.CommandType = CommandType.StoredProcedure;
                        da.SelectCommand.CommandText = "SPGetEmployeeDetailsPayslip";
                        da.SelectCommand.Parameters.AddWithValue("@empid", empid);

                        DataSet ds = new DataSet();
                        da.Fill(ds);
                        return ds;
                    }
                }
            }
            catch
            {
                throw;
            }
        }

        public decimal GetEmployeeGross(int empid)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(HRMConString))
                {
                    con.Open();
                    decimal gross = 0;
                    string query = "select CurrentSalary from EmployeePayroll where EmpID='" + empid + "'";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        SqlDataReader dr = cmd.ExecuteReader();

                        while (dr.Read())
                        {
                            gross = dr.GetDecimal(0);
                        }
                        return gross;
                    }
                }
            }
            catch
            {
                throw;
            }
        }

        public int GetEmployeeChildCount(int empid)
        {
            int amount = 0;

            try
            {
                using (SqlConnection con = new SqlConnection(HRMConString))
                {
                    con.Open();
                    int count = 0;
                    string query = "select Child from EmployeePayroll where EmpID='" + empid + "'";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        SqlDataReader dr = cmd.ExecuteReader();

                        while (dr.Read())
                        {

                            count = dr.GetInt32(0);
                            if (count == 0)
                            {
                                amount = 0;
                            }
                            else if (count == 1)
                            {
                                amount = 100;
                            }
                            else
                            {
                                amount = 200;
                            }
                        }
                        return count;
                    }
                }
            }
            catch
            {
                throw;
            }
        }

        public DataSet GetReportingManagers()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(HRMConString))
                {
                    con.Open();

                    string query = "select EmpName from EmployeeRegistration where Designation=1";

                    using (SqlDataAdapter da = new SqlDataAdapter(query, con))
                    {
                        da.SelectCommand.Connection = con;
                        DataSet ds = new DataSet();
                        da.Fill(ds);
                        return ds;
                    }
                }
            }
            catch
            {
                throw;
            }
        }

        public DataSet GetDepartments()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(HRMConString))
                {
                    con.Open();

                    string query = "select DepartmentType,DepartmentID from DepartmentMaster";

                    using (SqlDataAdapter da = new SqlDataAdapter(query, con))
                    {
                        da.SelectCommand.Connection = con;
                        DataSet ds = new DataSet();
                        da.Fill(ds);
                        return ds;
                    }
                }
            }
            catch
            {
                throw;
            }
        }

        public bool GetEmployeeNominationDetailsById(int empid)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(HRMConString))
                {
                    con.Open();

                    string query = "select * from EmployeeFamilyMaster where EmpID='" + empid + "'";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        var result = cmd.ExecuteScalar();

                        if (result == null)
                        {
                            return false;
                        }
                        return true;
                    }
                }
            }
            catch
            {
                throw;
            }
        }

        public DataSet GetLoanTypes()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(HRMConString))
                {
                    con.Open();

                    string query = "select LoanID,LoanType from LoanMaster";

                    using (SqlDataAdapter da = new SqlDataAdapter(query, con))
                    {
                        da.SelectCommand.Connection = con;
                        DataSet ds = new DataSet();
                        da.Fill(ds);
                        return ds;
                    }
                }
            }
            catch
            {
                throw;
            }
        }

        public DataSet CountryList()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(HRMConString))
                {
                    con.Open();

                    string query = "select CountryName from CountryMaster";

                    using (SqlDataAdapter da = new SqlDataAdapter(query, con))
                    {
                        da.SelectCommand.Connection = con;
                        DataSet ds = new DataSet();
                        da.Fill(ds);
                        return ds;
                    }
                }
            }
            catch
            {
                throw;
            }
        }

        public void AddDepartment(Department department)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(HRMConString))
                {
                    con.Open();

                    using (SqlDataAdapter da = new SqlDataAdapter())
                    {
                        da.SelectCommand = new SqlCommand();
                        da.SelectCommand.CommandType = CommandType.StoredProcedure;
                        da.SelectCommand.CommandText = "SPAddDepartment";
                        da.SelectCommand.Connection = con;
                        da.SelectCommand.Parameters.AddWithValue("@departmenttype", department.DepartmentType);
                        da.SelectCommand.ExecuteNonQuery();
                    }
                }
            }
            catch
            {
                throw;
            }
        }

        public void AddLeaveTypes(LeaveTypes leavetypes)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(HRMConString))
                {
                    con.Open();

                    using (SqlDataAdapter da = new SqlDataAdapter())
                    {
                        da.SelectCommand = new SqlCommand();
                        da.SelectCommand.CommandType = CommandType.StoredProcedure;
                        da.SelectCommand.CommandText = "SPAddLeaveTypes";
                        da.SelectCommand.Connection = con;
                        da.SelectCommand.Parameters.AddWithValue("@leavetype", leavetypes.LeaveType);
                        da.SelectCommand.ExecuteNonQuery();
                    }
                }
            }
            catch
            {
                throw;
            }
        }

        public void AddLoanTypes(LoanTypes loantypes)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(HRMConString))
                {
                    con.Open();

                    using (SqlDataAdapter da = new SqlDataAdapter())
                    {
                        da.SelectCommand = new SqlCommand();
                        da.SelectCommand.CommandType = CommandType.StoredProcedure;
                        da.SelectCommand.CommandText = "SPAddLoanTypes";
                        da.SelectCommand.Connection = con;
                        da.SelectCommand.Parameters.AddWithValue("@loantype", loantypes.LoanType);
                        da.SelectCommand.ExecuteNonQuery();
                    }
                }
            }
            catch
            {
                throw;
            }
        }

        public void AddGraduation(Graduation graduation)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(HRMConString))
                {
                    con.Open();

                    using (SqlDataAdapter da = new SqlDataAdapter())
                    {
                        da.SelectCommand = new SqlCommand();
                        da.SelectCommand.CommandType = CommandType.StoredProcedure;
                        da.SelectCommand.CommandText = "SPAddGraduation";
                        da.SelectCommand.Connection = con;
                        da.SelectCommand.Parameters.AddWithValue("@degreetype", graduation.DegreeType);
                        da.SelectCommand.ExecuteNonQuery();
                    }
                }
            }
            catch
            {
                throw;
            }
        }

        public void AddPostGraduation(PostGraduation postgraduation)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(HRMConString))
                {
                    con.Open();

                    using (SqlDataAdapter da = new SqlDataAdapter())
                    {
                        da.SelectCommand = new SqlCommand();
                        da.SelectCommand.CommandType = CommandType.StoredProcedure;
                        da.SelectCommand.CommandText = "SPAddPostGraduation";
                        da.SelectCommand.Connection = con;
                        da.SelectCommand.Parameters.AddWithValue("@pgtype", postgraduation.PGType);
                        da.SelectCommand.ExecuteNonQuery();
                    }
                }
            }
            catch
            {
                throw;
            }
        }

        public void AddDoctorate(Doctorate doctorate)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(HRMConString))
                {
                    con.Open();

                    using (SqlDataAdapter da = new SqlDataAdapter())
                    {
                        da.SelectCommand = new SqlCommand();
                        da.SelectCommand.CommandType = CommandType.StoredProcedure;
                        da.SelectCommand.CommandText = "SPAddDoctorate";
                        da.SelectCommand.Connection = con;
                        da.SelectCommand.Parameters.AddWithValue("@doctoratetype", doctorate.DoctorateType);
                        da.SelectCommand.ExecuteNonQuery();
                    }
                }
            }
            catch
            {
                throw;
            }
        }

        public void AddRelation(Relation relation)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(HRMConString))
                {
                    con.Open();

                    using (SqlDataAdapter da = new SqlDataAdapter())
                    {
                        da.SelectCommand = new SqlCommand();
                        da.SelectCommand.CommandType = CommandType.StoredProcedure;
                        da.SelectCommand.CommandText = "SPAddRelation";
                        da.SelectCommand.Connection = con;
                        da.SelectCommand.Parameters.AddWithValue("@relationtype", relation.RelationType);
                        da.SelectCommand.ExecuteNonQuery();
                    }
                }
            }
            catch
            {
                throw;
            }
        }

        public DataSet GetNationality()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(HRMConString))
                {
                    con.Open();

                    string query = "select NationalityType from NationalityMaster";

                    using (SqlDataAdapter da = new SqlDataAdapter(query, con))
                    {
                        da.SelectCommand.Connection = con;
                        DataSet ds = new DataSet();
                        da.Fill(ds);
                        return ds;
                    }
                }
            }
            catch
            {
                throw;
            }
        }

        public DataSet GetEmployeePassport(int empid)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(HRMConString))
                {
                    con.Open();
                    string query = "select * from EmployeePassport where EmpID='" + empid + "'";
                    using (SqlDataAdapter da = new SqlDataAdapter(query, con))
                    {
                        da.SelectCommand.Connection = con;
                        DataSet ds = new DataSet();
                        da.Fill(ds);
                        return ds;
                    }
                }
            }
            catch
            {
                throw;
            }
        }

        public bool GetEmpPassportById(int empid)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(HRMConString))
                {
                    con.Open();

                    string query = "select * from EmployeePassport where EmpID='" + empid + "'";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        var result = cmd.ExecuteScalar();

                        if (result == null)
                        {
                            return false;
                        }
                        return true;
                    }
                }
            }
            catch
            {
                throw;
            }
        }

        public void EmployeeRegistration(Employee employee)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(HRMConString))
                {
                    con.Open();

                    using (SqlDataAdapter da = new SqlDataAdapter())
                    {
                        da.SelectCommand = new SqlCommand();
                        da.SelectCommand.CommandType = CommandType.StoredProcedure;
                        da.SelectCommand.CommandText = "SPEmployeeRegistration";
                        da.SelectCommand.Connection = con;

                        da.SelectCommand.Parameters.AddWithValue("@empid", employee.EmpID);
                        da.SelectCommand.Parameters.AddWithValue("@efname", employee.FirstName);
                        da.SelectCommand.Parameters.AddWithValue("@doj", employee.DOJ);
                        da.SelectCommand.Parameters.AddWithValue("@department", employee.Department);
                        da.SelectCommand.Parameters.AddWithValue("@role", employee.Designation);
                        da.SelectCommand.Parameters.AddWithValue("@email", employee.Email);
                        da.SelectCommand.Parameters.AddWithValue("@reportingmgr", employee.ReportingManager);
                        da.SelectCommand.Parameters.AddWithValue("@newrole", employee.Role);
                        da.SelectCommand.ExecuteNonQuery();
                    }
                }
            }
            catch
            {
                throw;
            }
        }

        public DataSet GetDetailsEmployeeRegistration(int empid)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(HRMConString))
                {
                    con.Open();

                    string query = "select DOJ,Department, Designation, Email, ReportingManager,Role from EmployeeRegistration where EmpId='" + empid + "'";

                    using (SqlDataAdapter da = new SqlDataAdapter(query, con))
                    {
                        da.SelectCommand.Connection = con;
                        DataSet ds = new DataSet();
                        da.Fill(ds);
                        return ds;
                    }
                }
            }
            catch
            {
                throw;
            }
        }

        public bool GetEducationDetailsById(int empid)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(HRMConString))
                {
                    con.Open();

                    string query = "select Education,BranchStudy1,NameofInstitute,DurationOfCourse from EmployeeEducation where EmpID='" + empid + "'";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        var result = cmd.ExecuteScalar();

                        if (result == null)
                        {
                            return false;
                        }
                        return true;
                    }
                }
            }
            catch
            {
                throw;
            }
        }

        public DataSet GetEducationById(int empid)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(HRMConString))
                {
                    con.Open();

                    string query = "select * from EmployeeEducation where EmpID='" + empid + "'";

                    using (SqlDataAdapter da = new SqlDataAdapter(query, con))
                    {
                        da.SelectCommand.Connection = con;

                        DataSet ds = new DataSet();
                        da.Fill(ds);
                        return ds;
                    }
                }
            }
            catch
            {
                throw;
            }
        }

        public List<Education> UpdateEducationById(int empid)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(HRMConString))
                {
                    con.Open();

                    SqlDataReader dr = null;

                    string query = "select * from EmployeeEducation where EmpID='" + empid + "'";

                    List<Education> edu = new List<Education>();

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        dr = cmd.ExecuteReader();

                        while (dr.Read())
                        {
                            Education education = new Education();
                            education.StartDate = dr.GetDateTime(4);
                            education.EndDate = dr.GetDateTime(5);
                            education.Certificate = dr.GetString(2);
                            education.Qualification = dr.GetString(3);
                            education.BranchStudyOne = dr.GetString(5);
                            education.BranchStudyTwo = dr.GetString(5);
                            education.Duration = dr.GetInt32(6);
                            education.EducationalEstimation = dr.GetString(9);
                            education.NameOfInstitute = dr.GetString(5);
                            education.City = dr.GetString(7);
                            education.Type = dr.GetString(8);
                            education.Grade = dr.GetString(5);
                            education.AdditionalCourse = dr.GetString(10);

                            edu.Add(education);
                        }

                        dr.Close();
                        return edu;
                    }
                }
            }
            catch
            {
                throw;
            }
        }

        public DataSet GetIDEmployeeRegistration()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(HRMConString))
                {
                    con.Open();

                    string query = "select EmpId from EmployeeRegistration";
                    using (SqlDataAdapter da = new SqlDataAdapter(query, con))
                    {
                        da.SelectCommand.Connection = con;

                        DataSet ds = new DataSet();
                        da.Fill(ds);
                        return ds;
                    }
                }
            }
            catch
            {
                throw;
            }
        }

        public DataSet GetIDProofDetails(int empid)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(HRMConString))
                {
                    con.Open();
                    string query = "select * from IDProof where EmpID='" + empid + "'";

                    using (SqlDataAdapter da = new SqlDataAdapter(query, con))
                    {
                        da.SelectCommand.Connection = con;
                        DataSet ds = new DataSet();
                        da.Fill(ds);
                        return ds;
                    }
                }
            }
            catch
            {
                throw;
            }
        }

        public void UpdateIDProofDetails(int empid, string pan, string pran, string uan, string license, string voterid, string esic, string adhaar)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(HRMConString))
                {
                    con.Open();

                    string query = "update IDProof set Aadhar='" + adhaar + "',PAN='" + pan + "', PRAN='" + pran + "', UAN='" + uan + "', DrivingLicense='" + license + "', ESIC='" + esic + "', VoterID='" + voterid + "' where EmpID='" + empid + "'";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch
            {
                throw;
            }
        }

        public DataSet GetEmpName()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(HRMConString))
                {
                    con.Open();

                    string query = "select (RTRIM(EmpName)+','+ CAST(LTRIM(EmpId) AS nvarchar(20))) as EmpName FROM [HumanResource].[dbo].[EmployeeRegistration]";

                    using (SqlDataAdapter da = new SqlDataAdapter(query, con))
                    {
                        da.SelectCommand.Connection = con;

                        DataSet ds = new DataSet();
                        da.Fill(ds);
                        return ds;
                    }
                }
            }
            catch
            {
                throw;
            }
        }

        public DataSet GetEmpDetails(int empid)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(HRMConString))
                {
                    con.Open();

                    string query = "select EFname,ELname,DOJ,DOB,Email,Department,ReportingManager from EmployeeMaster where EmployeeId='" + empid + "'";

                    using (SqlDataAdapter da = new SqlDataAdapter(query,con))
                    {
                        da.SelectCommand.Connection = con;

                        DataSet ds = new DataSet();
                        da.Fill(ds);
                        return ds;
                    }
                }
            }
            catch
            {
                throw;
            }
        }

        public DataSet GetAllDesignations()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(HRMConString))
                {
                    con.Open();

                    string query = "select * from DesignationMaster";

                    using (SqlDataAdapter da = new SqlDataAdapter(query,con))
                    {
                        da.SelectCommand.Connection = con;

                        DataSet ds = new DataSet();
                        da.Fill(ds);
                        return ds;
                    }
                }
            }
            catch 
            {                
                throw;
            }
        }
    }
}
