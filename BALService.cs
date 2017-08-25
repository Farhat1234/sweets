using HRMDAL.Entites;
using HRMDAL.Repositries;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMBAL
{
    public class BALService
    {
        AddEmployeeRepositry addempRepo;
        LoginRepositry userlog;
        ApplyLeaveRepositry appleavrepo;
        DailyAttendRepsitry dailatt;
        JobPostingRepositry jobs;

        public BALService()
        {
            try
            {
                this.userlog = new LoginRepositry();
                this.addempRepo = new AddEmployeeRepositry();
                this.appleavrepo = new ApplyLeaveRepositry();
                this.dailatt = new DailyAttendRepsitry();
                this.jobs = new JobPostingRepositry();
            }
            catch
            {
                throw;
            }
        }

        public void AddEmployee(HRMDAL.Entites.Employee emp)
        {
            try
            {
                addempRepo.AddEmployee(emp);
            }
            catch
            {
                throw;
            }
        }

        public List<HRMDAL.Entites.Employee> RetriveEmpIDImage(int EmpID)
        {
            try
            {
                return addempRepo.RetriveEmpIDImage(EmpID);
            }
            catch
            {
                throw;
            }
        }

        public List<HRMDAL.Entites.StateCity> GetStates()
        {
            try
            {
                return addempRepo.GetStates();
            }
            catch
            {
                throw;
            }
        }

        public List<HRMDAL.Entites.City> GetCity(int StateID)
        {
            try
            {
                return addempRepo.GetCity(StateID);
            }
            catch
            {
                throw;
            }
        }

        public void AddBankDetails(BankDetails bank)
        {
            try
            {
                addempRepo.AddBankDetails(bank);
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
                return addempRepo.CountryList();
            }
            catch
            {
                throw;
            }
        }

        public DataTable StateList(int CountryID)
        {
            try
            {
                return addempRepo.StateList(CountryID);
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
                return addempRepo.CityList(StateID);
            }
            catch
            {
                throw;
            }
        }

        public DataSet GetEmployeeInfo(int empid)
        {
            try
            {
                return addempRepo.GetEmployeeDetails(empid);
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
                return addempRepo.CheckEmpId(empid);
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
                return addempRepo.GetBankDetailsById(empid);
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
                return addempRepo.GetBankById(empid);
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
                return addempRepo.GetReimburseBankById(empid);
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
                return addempRepo.UpdateBankById(empid);
            }
            catch
            {
                throw;
            }
        }

        public void AddEducationDetails(Education edu)
        {
            try
            {
                addempRepo.AddEducation(edu);
            }
            catch
            {
                throw;
            }
        }

        public void AddPassport(Passport pass)
        {
            try
            {
                addempRepo.AddPassport(pass);
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
                addempRepo.AddIDProof(idproof);
            }
            catch
            {

                throw;
            }
        }

        public void LoanDetails(LoanDetails loanDetails)
        {
            try
            {
                addempRepo.LoanDetails(loanDetails);
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
                return addempRepo.GetLoanDetails(empid);
            }
            catch
            {
                throw;
            }

        }

        public void FamilyNomination(FamilyNomination familyNomination)
        {
            try
            {
                addempRepo.FamilyNomination(familyNomination);
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
                return addempRepo.GetFamilyNomination(empid);
            }
            catch
            {
                throw;
            }
        }

        public DataSet GetPayslipDetails(int empid)
        {
            try
            {
               return addempRepo.GetPaySlipDetails(empid);
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
               return addempRepo.GetEmpid();
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
                return addempRepo.GetEmployeePayslip(empid);
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
                return addempRepo.GetEmployeePayslip();
            }
            catch
            {
                throw;
            }
        }

        public void AddPayslip(int empid, string empname, string month, string year, string currsalary, string compname)
        {
            try
            {
                addempRepo.AddPaySlipDetails(empid, empname, month, year, currsalary, compname);
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
                addempRepo.AddNewPayrollDetails(payslip);
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
               return addempRepo.GetEmployeeDetailsPayslip(empid);
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
                return addempRepo.GetEmployeeGross(empid);
            }
            catch
            {                
                throw;
            }
        }

        public int GetEmployeeChildCount(int empid)
        {
            try
            {
                return addempRepo.GetEmployeeChildCount(empid);
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
                return addempRepo.GetReportingManagers();
            }
            catch 
            {                
                throw;
            }
        }

        public bool LoginRep(int empID, string password)
        {
            try
            {
                return userlog.LoginRep(empID,password);
            }
            catch
            {                
                throw;
            }
        }

        public void Add(int empid, string password)
        {
            try
            {
                userlog.AddCredentials(empid,password);
            }
            catch
            {                
                throw;
            }
        }

        public HRMDAL.Entites.Login GetRoleID(int empid, string password)
        {
            try
            {
                return userlog.GetRoleByUserId(empid, password);
            }
            catch
            {                
                throw;
            }
        }

        public void ApplyLeav(HRMDAL.Entites.ApplyLeave applev)
        {
            try
            {
                appleavrepo.ApplyLeav(applev);
            }
            catch
            {
                throw;
            }
        }

        public System.Data.DataSet GetLeaveQuota()
        {
            try
            {
                return appleavrepo.GetLeaveQuota();
            }
            catch
            {
                throw;
            }
        }

        public System.Data.DataSet GetLeaveHistory(int empId)
        {
            try
            {
                return appleavrepo.GetLeaveHistory(empId);
            }
            catch
            {
                throw;
            }
        }

        public System.Data.DataSet GetAllLeavesPending()
        {
            try
            {
                return appleavrepo.GetAllPendingLeaves();
            }
            catch 
            {                
                throw;
            }
        }

        public void ApproveLeaves(int empid, DateTime fromdate)
        {
            try
            {
                appleavrepo.ApproveLeaves(empid, fromdate);
            }
            catch
            {                
                throw;
            }
        }

        public void DailyAttend(HRMDAL.Entites.DailyAttendance att)
        {
            try
            {
                dailatt.DailyAttendance(att);
            }
            catch 
            {                
                throw;
            }
        }

        public void OnDutyApply(HRMDAL.Entites.ApplyOnDuty aod)
        {
            try
            {
                dailatt.ApplyOnDuty(aod);
            }
            catch
            {
                throw;
            }
        }

        public System.Data.DataSet GetOnDutyHistory(int empId)
        {
            try
            {
                return dailatt.GetOnDutyHistory(empId);
            }
            catch
            {
                throw;
            }
        }

        public DataSet GetAttendanceRecord(int empId, DateTime startdate, DateTime enddate)
        {
            try
            {
                return dailatt.GetAttendanceRecord(empId, startdate, enddate);
            }
            catch
            {
                throw;
            }
        }

        public string GetApproverByID(int empId)
        {
            try
            {
                return dailatt.GetApproverByID(empId);
            }
            catch
            {                
                throw;
            }
        }

        public void Posting(HRMDAL.Entites.JobPosting job)
        {
            try
            {
                jobs.JobPost(job);
            }
            catch
            {                
                throw;
            }
        }

        public System.Data.DataSet GetAllJobs()
        {
            try
            {
                return jobs.ListOfJobs();
            }
            catch
            {                
                throw;
            }
        }

        public  DataSet GetDepartments()
        {
            try
            {
                return addempRepo.GetDepartments();
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
                return addempRepo.GetEmployeeNominationDetailsById(empid);
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
                return addempRepo.GetNationality();
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
                return addempRepo.GetEmployeePassport(empid);
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
                return addempRepo.GetEmpPassportById(empid);
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
                return addempRepo.GetLoanTypes();
            }
            catch
            {                
                throw;
            }
        }

        public DataSet GetNIOCategory()
        {
            try
            {
                return dailatt.GetNIOCategory();
            }
            catch 
            {                
                throw;
            }
        }

        public DataSet GetLeaveTypes()
        {
            try
            {
                return dailatt.GetLeaveTypes();
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
                addempRepo.AddDepartment(department);
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
                addempRepo.AddDoctorate(doctorate);
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
                addempRepo.AddGraduation(graduation);
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
                addempRepo.AddLeaveTypes(leavetypes);
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
                addempRepo.AddLoanTypes(loantypes);
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
                addempRepo.AddPostGraduation(postgraduation);
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
                addempRepo.AddRelation(relation);
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
                addempRepo.EmployeeRegistration(employee);
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
               return addempRepo.GetDetailsEmployeeRegistration(empid);
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
                return addempRepo.GetEducationDetailsById(empid);
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
                return addempRepo.GetEducationById(empid);
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
                return addempRepo.GetIDEmployeeRegistration();
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
                return addempRepo.GetIDProofDetails(empid);
            }
            catch
            {
                throw;
            }
        }

        public void  UpdateIDProofDetails(int empid, string pan,string pran, string uan, string license, string voterid, string esic, string adhaar)
        {
            try
            {
                addempRepo.UpdateIDProofDetails(empid,pan,pran,uan,license,voterid,esic,adhaar);
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
                return addempRepo.GetEmpName();
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
                return addempRepo.GetEmpDetails(empid);
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
               return addempRepo.GetAllDesignations();
            }
            catch
            {                
                throw;
            }
        }
    }
}
