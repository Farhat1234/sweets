using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
namespace HRMDAL.Entites
{
   public class EmployeeEdit
    {
       [DataMember]
	   public int EmpID{get;set;}
       [DataMember]
	   public decimal BankAC{get;set;}
       [DataMember]
       public int PFno {get;set;}
       [DataMember]
	  public string PanNo{get;set;}
       [DataMember]
	 public string Dept {get;set;}
       [DataMember]
	public string Designation {get;set;}
       [DataMember]
	public string Category{get;set;}
       [DataMember]
	public string FirstApp{get;set;}
       [DataMember]
	public string SecndApp{get;set;}
       [DataMember]
	public string RprtigMgr{get;set;}
       [DataMember]
	public string WeekOF{get;set;}
       [DataMember]
	public string CurntShif{get;set;}
       [DataMember]
	public string FatherName{get;set;}
       [DataMember]
	public string MotherName{get;set;}
       [DataMember]
	public decimal AadharNo {get;set;}
       [DataMember]
	public decimal DrivingLCNo{get;set;}
       [DataMember]
	public decimal EmergncyPhne{get;set;}
       [DataMember]
	public string AlternateEmail{get;set;}
       [DataMember]
	public string MotherTongue{get;set;}
       [DataMember]
	public string MaritalStus{get;set;}
       [DataMember]
	public string BlodGrp{get;set;}
       [DataMember]
	public string Nationality{get;set;}
       [DataMember]
	public string Religion{get;set;}
       [DataMember]
	public string IdentificationMark{get;set;}
       [DataMember]
	public string PCaddr{get;set;}
       [DataMember]
	public string PCcity{get;set;}
       [DataMember]
	public string PCstate{get;set;}
       [DataMember]
	public decimal PCpincode{get;set;}
       [DataMember]
	public string CCaddr{get;set;}
       [DataMember]
	public string CCcity{get;set;}
       [DataMember]
	public string CCstate{get;set;}
       [DataMember]
	public decimal CCpincode{get;set;}
       [DataMember]
	public string PassportNo{get;set;}
       [DataMember]
	public string Name{get;set;}
       [DataMember]
	public DateTime  IssueDate{get;set;}
       [DataMember]
	public DateTime ExpiryDate{get;set;}


    }
    
}
