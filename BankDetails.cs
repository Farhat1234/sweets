using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HRMDAL.Entites
{
    public class BankDetails
    {
        public int EmpId { get; set; }

        public string AccountType { get; set; }

        public string AccountHolderName { get; set; }

        public string BankName { get; set; }

        public string Branch { get; set; }

        public long AccountNo { get; set; }

        public string Country { get; set; }

        public string IFSC { get; set; }

        public string RAccountType { get; set; }


        public string ReimburseAccHolder { get; set; }

        public string RBankName { get; set; }

        public string ReimburseBranch { get; set; }

        public long RAccountNo { get; set; }

        public string RCountry { get; set; }

        public string RIFSC { get; set; }

    }
}
